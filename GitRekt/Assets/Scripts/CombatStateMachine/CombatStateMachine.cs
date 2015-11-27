using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CombatStateMachine : MonoBehaviour
{
    public AI enemy;
    public enum CombatStates { STARTTURN,PLAYERSELECT, PLAYERENEMY, PLAYERPLAYER, ENEMY, WIN, LOSE };
    public static CombatStates CurrentState;
    public BattleManager battleManager;
    private bool goal;
    void Start()
    {
        battleManager = GetComponent<BattleManager>();
        Random.seed = 0;
        enemy = GetComponent<AI>();
        goal = false;
        CurrentState = CombatStates.PLAYERSELECT;
    }

    void Update()
    {
        Debug.Log(CurrentState);
        switch (CurrentState)
        {
            case(CombatStates.STARTTURN):
                battleManager.beginTurn();
                CurrentState = CombatStates.PLAYERSELECT;
                break;
            case (CombatStates.PLAYERSELECT):
                //Check Unit selected.
                if (battleManager.skill_active && battleManager.target_unit && battleManager.selected_unit)
                {
                    CurrentState = CombatStates.PLAYERENEMY;
                }
                else if (battleManager.skill_active && battleManager.buff_unit && battleManager.selected_unit)
                {
                    CurrentState = CombatStates.PLAYERPLAYER;
                }
                break;
            case (CombatStates.PLAYERENEMY):
                StartCoroutine("player_target_enemy");
                checkWin();
                battleManager.endAction();
                if (battleManager.actions == 0)
                    battleManager.endTurn();
                    CurrentState = CombatStates.ENEMY;
                break;
            case (CombatStates.PLAYERPLAYER):
                StartCoroutine("player_target_player");
                battleManager.endAction();
                if (battleManager.actions == 0)
                    battleManager.endTurn();
                    CurrentState = CombatStates.ENEMY;
                break;
            case (CombatStates.ENEMY):
                StartCoroutine("enemyAction");
                if (goal)
                    CurrentState = CombatStates.LOSE;
                else
                    CurrentState = CombatStates.STARTTURN;
                break;
            case (CombatStates.LOSE):
                loss();
                break;
            case (CombatStates.WIN):
                win();
                break;
        }
    }
    private void win()
    {
        //pass back application to map
        SaveInformation.SaveAllInformation();
        ChangeScene.ChangeToScene("Map");
    }
    private void loss()
    {
        //pass back application to map
        battleManager.endBattle();
    }
    private void checkWin()
    {
        if (battleManager.enemyParty.Count == 0)
            goal = true;
        if (goal)
        {
            battleManager.endTurn();
            CurrentState = CombatStates.WIN;
        }
        else
        {
            battleManager.endAction();
            if (battleManager.actions == 0)
            {
                battleManager.endTurn();
                CurrentState = CombatStates.ENEMY;
            }
            else
                CurrentState = CombatStates.PLAYERSELECT;
        }
    }
    /*
     * Coroutine stops the update function so we can decide what the hell the enemy is doing.
     * enemyAction works as the following: choose a random attacker (For now)
     * Attack the lowest health Target
     * We can also add animations in here or whatever.
     * Apply attack in EnemyAttack:
     *  -TODO if enemy has more then one spell. Choose one. Basic Attack for now
     *  -TODO here. Decide what happens when a player unit dies
     *  
     */
    
    /*
     * Aglorithm:
     * Check what we are interacting with. Player or Enemy Target?
     *  Check what effect are on the Attacking Unit.
     *      Process those effects.
     *  Carry out attack.
     *      Apply new effects if need be.
     */
    //Player targeted Enemy
    IEnumerator player_target_enemy()
    {
        switch (battleManager._selectedUnit.effect)
        {
            // All possible states
            case (basePlayer.Status.ATTACK):
                decreaseEffect(battleManager._selectedUnit, battleManager._skill);
                playerAttack(battleManager._selectedUnit, battleManager._attackTarget, battleManager._skill);
                break;
            case (basePlayer.Status.CONFUSED):
                unitConfused(battleManager._selectedUnit, battleManager._attackTarget, battleManager._skill);
                break;
            case (basePlayer.Status.DEFENSE):
                decreaseEffect(battleManager._selectedUnit, battleManager._skill);
                playerAttack(battleManager._selectedUnit, battleManager._attackTarget, battleManager._skill);
                break;
            case (basePlayer.Status.DOT):
                unitDOTed(battleManager._selectedUnit, battleManager._skill);
                playerAttack(battleManager._selectedUnit, battleManager._attackTarget, battleManager._skill);
                break;
            case (basePlayer.Status.SKIP):
                unitSkipped(battleManager._selectedUnit,battleManager._attackTarget,battleManager._skill);
                if (!battleManager._selectedUnit.effected)
                    playerAttack(battleManager._selectedUnit, battleManager._attackTarget, battleManager._skill);
                break;
            case (basePlayer.Status.STUN):
                unitStunned(battleManager._selectedUnit,battleManager._skill);
                break;
            default:
                playerAttack(battleManager._selectedUnit, battleManager._attackTarget, battleManager._skill);
                break;
        }
        yield return null;
    }
    //Player targeted other player
    IEnumerator player_target_player()
    {
        switch (battleManager._selectedUnit.effect)
        {
            //All possible states our players can be in
            case (basePlayer.Status.ATTACK):
                decreaseEffect(battleManager._selectedUnit, battleManager._skill);
                playerBuff(battleManager._selectedUnit, battleManager._buffTarget, battleManager._skill);
                break;
            case (basePlayer.Status.CONFUSED):
                unitConfused(battleManager._selectedUnit, battleManager._buffTarget, battleManager._skill);
                break;
            case (basePlayer.Status.DEFENSE):
                decreaseEffect(battleManager._selectedUnit, battleManager._skill);
                playerBuff(battleManager._selectedUnit, battleManager._attackTarget, battleManager._skill);
                break;
            case (basePlayer.Status.DOT):
                unitDOTed(battleManager._selectedUnit, battleManager._skill);
                playerBuff(battleManager._selectedUnit, battleManager._attackTarget, battleManager._skill);
                break;
            case (basePlayer.Status.SKIP):
                unitSkipped(battleManager._selectedUnit, battleManager._attackTarget, battleManager._skill);
                if (!battleManager._selectedUnit.effected)
                    playerBuff(battleManager._selectedUnit, battleManager._attackTarget, battleManager._skill);
                break;
            case (basePlayer.Status.STUN):
                unitStunned(battleManager._selectedUnit,battleManager._skill);
                break;
            default:
                playerBuff(battleManager._selectedUnit, battleManager._buffTarget, battleManager._skill);
                break;
        }
        yield return null;
    }
    IEnumerator enemyAction()
    {
        for (int i = 0; i < battleManager.actions; i++)
        {
            baseEnemy attacker = battleManager.enemyParty[Random.Range(0, GameInformation.enemies.Length)];
            basePlayer target = enemy.lowestHealthTarget(battleManager.playerParty);
            enemyTurnPhase(attacker, target, attacker.basicAttack);
        }
        yield return null;
    }

    //Attack states
    //Player Attack States
    private void playerAttack(basePlayer unit, baseEnemy target, baseSkill skill)
    {
        //AOE target. Might have to look at how we Destory Units. Because bookkeeping
        if (skill.additionalEffect.status == baseSkill.Effect.Status.AOE && skill.targetEnemy)
            AOEattack(unit, target, skill);
        else
        {
            //Single Target - Check if GODed
            if (target.effect == baseEnemy.Status.GOD)
            {
                target.currentHP -= 0;
                Debug.Log("God Moded");
                clearEffect(target, skill);
            }
            else
            {
                target.currentHP -= skill.cast(unit, target);
                if (target.currentHP >= 0)
                    if (!target.effected)
                        applyEffect(target, skill);
                    else
                        battleManager.deadUnit(target);
            }
        }
        Debug.Log("Attack Successful");
    }
    private void playerAttack(basePlayer unit, basePlayer target, baseSkill skill)
    {
        //AOE target. Might have to look at how we Destory Units. Because bookkeeping
        if (skill.additionalEffect.status == baseSkill.Effect.Status.AOE && skill.targetEnemy)
            AOEattack(unit, target, skill);
        else
        {
            //Single Target - Check if GODed
            if (target.effect == basePlayer.Status.GOD)
            {
                target.currentHP -= 0;
                Debug.Log("God Moded");
                clearEffect(target, skill);
            }
            else
            {
                target.currentHP -= skill.cast(unit, target);
                if (target.currentHP >= 0)
                    if (!target.effected)
                        applyEffect(target, skill);
                    else
                        battleManager.deadUnit(target);
            }
        }
        Debug.Log("Attack Successful");
    }
    private void playerBuff(basePlayer unit, basePlayer target, baseSkill skill)
    {
        if (!target.effected)
        {
            if (skill.additionalEffect.status == baseSkill.Effect.Status.ATTACK && skill.targetPlayer)
            {
                target.attack += skill.cast(unit, target);
                applyEffect(target, skill);
            }
            else if (skill.additionalEffect.status == baseSkill.Effect.Status.DEFENSE && skill.targetPlayer)
            {
                target.defense += skill.cast(unit, target);
                applyEffect(target, skill);
            }
        }
        else if (skill.additionalEffect.status == baseSkill.Effect.Status.HEAL && skill.targetPlayer)
        {
            target.currentHP += skill.cast(unit, target);
            //Check here for effects. HOTS?
        }
    }
    private void playerBuff(basePlayer unit, baseEnemy target, baseSkill skill)
    {
        if (!target.effected)
        {
            if (skill.additionalEffect.status == baseSkill.Effect.Status.ATTACK && skill.targetPlayer)
            {
                target.attack += skill.cast(unit, target);
                applyEffect(target, skill);
            }
            else if (skill.additionalEffect.status == baseSkill.Effect.Status.DEFENSE && skill.targetPlayer)
            {
                target.defense += skill.cast(unit, target);
                applyEffect(target, skill);
            }
        }
        else if (skill.additionalEffect.status == baseSkill.Effect.Status.HEAL && skill.targetPlayer)
        {
            target.currentHP += skill.cast(unit, target);
            //Check here for effects. HOTS?
        }
    }
    //Enemy Turn States
    private void enemyTurnPhase(baseEnemy unit, basePlayer target, baseSkill skill)
    {
        // All possible states
        switch (unit.effect)
        {
            case (baseEnemy.Status.ATTACK):
                decreaseEffect(unit, skill);
                enemyAttack(unit, target, skill);
                break;
            case (baseEnemy.Status.CONFUSED):
                unitConfused(unit, target, skill);
                break;
            case (baseEnemy.Status.DEFENSE):
                decreaseEffect(unit, skill);
                enemyAttack(unit, target, skill);
                break;
            case (baseEnemy.Status.DOT):
                unitDOTed(unit, skill);
                enemyAttack(unit, target, skill);
                break;
            case (baseEnemy.Status.SKIP):
                unitSkipped(unit, target, battleManager._skill);
                if (!unit.effected)
                    enemyAttack(unit, target, skill);
                break;
            case (baseEnemy.Status.STUN):
                unitStunned(unit, skill);
                break;
            default:
                enemyAttack(unit, target, skill);
                break;
        }
    }
    private void enemyAttack(baseEnemy attacker, basePlayer target, baseSkill skill)
    {
        if (target.effect == basePlayer.Status.GOD)
        {
            target.currentHP -= 0;
            clearEffect(target, skill);
        }
        else
        {
            target.currentHP -= skill.cast(attacker, target);
            if (skill.hasAdditionalEffect)
                if (target.currentHP <= 0)
                    battleManager.deadUnit(target);
                else if (!target.effected)
                    applyEffect(target, skill);
        }
    }
    private void enemyAttack(baseEnemy attacker, baseEnemy target, baseSkill skill)
    {
        if (target.effect == baseEnemy.Status.GOD)
        {
            target.currentHP -= 0;
            clearEffect(target, skill);
        }
        else
        {
            target.currentHP -= skill.cast(attacker, target);
            if (skill.hasAdditionalEffect)
                if (target.currentHP <= 0)
                    battleManager.deadUnit(target);
                else if (!target.effected)
                    applyEffect(target, skill);
        }
    }
    //AOE Attack states
    private void AOEattack(basePlayer unit, baseEnemy target, baseSkill skill)
    {
        int enemiesLeft = battleManager.enemyParty.Count;
        for (int i = 0; i < enemiesLeft; ++i)
        {
            if (battleManager.enemyParty[i] != null)
            {
                battleManager.enemyParty[i].currentHP -= skill.cast(unit, battleManager.enemyParty[i]);
                if (battleManager.enemyParty[i].currentHP <= 0)
                {
                    battleManager.deadUnit(battleManager.enemyParty[i]);
                }
            }
        }
    }
    private void AOEattack(basePlayer unit, basePlayer target, baseSkill skill)
    {
        int playersLeft = battleManager.playerParty.Count;
        for (int i = 0; i < playersLeft; ++i)
        {
            if (battleManager.playerParty[i] != null)
            {
                battleManager.playerParty[i].currentHP -= skill.cast(unit, battleManager.playerParty[i]);
                if (battleManager.playerParty[i].currentHP <= 0)
                {
                    battleManager.deadUnit(battleManager.playerParty[i]);
                }
            }
        }
    }
    private void AOEattack(baseEnemy unit, basePlayer target, baseSkill skill)
    {
        int playersLeft = battleManager.playerParty.Count;
        for (int i = 0; i < playersLeft; ++i)
        {
            if (battleManager.playerParty[i] != null)
            {
                battleManager.playerParty[i].currentHP -= skill.cast(unit, battleManager.playerParty[i]);
                if (battleManager.playerParty[i].currentHP <= 0)
                {
                    battleManager.deadUnit(battleManager.playerParty[i]);
                }
            }
        }
    }
    private void AOEattack(baseEnemy unit, baseEnemy target, baseSkill skill)
    {
        int enemiesLeft = battleManager.enemyParty.Count;
        for (int i = 0; i < enemiesLeft; ++i)
        {
            if (battleManager.enemyParty[i] != null)
            {
                battleManager.enemyParty[i].currentHP -= skill.cast(unit, battleManager.enemyParty[i]);
                if (battleManager.enemyParty[i].currentHP <= 0)
                {
                    battleManager.deadUnit(battleManager.enemyParty[i]);
                }
            }
        }
    }
    //Status Effect System helper Functions
    private void clearEffect(basePlayer unit,baseSkill skill)
    {
        if (unit.effect == basePlayer.Status.ATTACK)
            unit.attack -= skill.additionalEffect.power;
        else if (unit.effect == basePlayer.Status.DEFENSE)
            unit.defense -= skill.additionalEffect.power;
        unit.effect = basePlayer.Status.NONE;
        unit.duration = 0;
        unit.effected = false;
        unit.effective_skill = null;
    }
    private void clearEffect(baseEnemy unit, baseSkill skill)
    {
        if (unit.effect == baseEnemy.Status.ATTACK)
            unit.attack -= skill.additionalEffect.power;
        else if (unit.effect == baseEnemy.Status.DEFENSE)
            unit.defense -= skill.additionalEffect.power;
        unit.effect = baseEnemy.Status.NONE;
        unit.duration = 0;
        unit.effected = false;
        unit.effective_skill = null;
    }
    private void applyEffect(baseEnemy unit, baseSkill skill)
    {
        unit.effect = (baseEnemy.Status)skill.additionalEffect.status;
        unit.duration = 0;
        unit.effected = true;
        unit.effective_skill = skill;
    }
    private void applyEffect(basePlayer unit, baseSkill skill)
    {
        unit.effect = (basePlayer.Status)skill.additionalEffect.status;
        unit.duration = skill.additionalEffect.duration;
        unit.effected = true;
        unit.effective_skill = skill;
    }
    private void decreaseEffect(basePlayer unit, baseSkill skill) {
        if (unit.duration == 0)
        {
            clearEffect(unit,skill);
        }
        --unit.duration;
    }
    private void decreaseEffect(baseEnemy unit, baseSkill skill) {
        if (unit.duration == 0)
        {
            clearEffect(unit, skill);
        }
        --unit.duration;
    }
    /*
     * Effects. These effect units in some way or another
        STUN - skip turn
        CONFUSED - Pokemon style. attack may hit anyone
        AOE - AOE effect
        HEAL - Heal target
        DOT - Damage over time
        GOD - Block next attack
        ATTACK - Buff only once, last x turns
        DEFENSE - Buff only once, last y turns
        SKIP - skip turn for build up of attack. Keep at 0 until we actually cast the spell.
     */
    private void unitConfused(basePlayer unit, baseEnemy target, baseSkill skill)
    {
        // Attacks random target here
        int coin = Random.Range(0, 1);
        if (coin == 0)
        {
            //Attack allies 
            int unitIndex = Random.Range(0, battleManager.playerParty.Count);
            --unit.duration;
            if (battleManager.playerParty[unitIndex] != null)
                playerAttack(unit, battleManager.playerParty[unitIndex], skill);
        }
        else
        {
            // Attack Enemy 
            int unitIndex = Random.Range(0, battleManager.enemyParty.Count);
            --unit.duration;
            if (battleManager.enemyParty[unitIndex] != null)
                playerAttack(unit, battleManager.enemyParty[unitIndex], skill);
        }

    }
    private void unitConfused(basePlayer unit, basePlayer target, baseSkill skill){
        // Attacks random target here
        int coin = Random.Range(0, 1);
        if (coin == 0)
        {
            //Attack allies - No Effect applied (For Now)
            int unitIndex = Random.Range(0, battleManager.playerParty.Count);
            --unit.duration;
            if (battleManager.playerParty[unitIndex] != null)
                playerBuff(unit, battleManager.playerParty[unitIndex], skill);
        }
        else
        {
            // Attack Enemy - No Effect applied (For Now)
            int unitIndex = Random.Range(0, battleManager.enemyParty.Count);
            --unit.duration;
            if (battleManager.enemyParty[unitIndex] != null)
                playerBuff(unit, battleManager.enemyParty[unitIndex], skill);
        }
    
    }
    private void unitConfused(baseEnemy unit, basePlayer target, baseSkill skill)
    {
        int coin = Random.Range(0, 1);
        if (coin == 0)
        {
            //Attack allies - No Effect applied (For Now)
            int unitIndex = Random.Range(0, battleManager.playerParty.Count);
            --unit.duration;
            if (battleManager.playerParty[unitIndex] != null)
                enemyAttack(unit, battleManager.enemyParty[unitIndex],unit.basicAttack);
        }
        else
        {
            // Attack Enemy - No Effect applied (For Now)
            int unitIndex = Random.Range(0, battleManager.enemyParty.Count);
            --unit.duration;
            if (battleManager.enemyParty[unitIndex] != null)
                enemyAttack(unit, battleManager.playerParty[unitIndex], unit.basicAttack);
        }

    }
    private void unitStunned(basePlayer unit,baseSkill skill)
    {
        // Stunned effect. Actions minus/ Player doesnt take turn
        --unit.duration;
        if (unit.duration == 0)
            clearEffect(unit,skill);
        // Maybe some text here. For now in debug log
        Debug.Log("UNIT STUNNED! CANT ATTACK THIS ACTION TAKING AWAY 1 ACTION POINT");
    }
    private void unitStunned(baseEnemy unit,baseSkill skill)
    {
        // Stunned effect. Actions minus/ Player doesnt take turn
        --battleManager.actions;
        --unit.duration;
        if (unit.duration == 0)
            clearEffect(unit,skill);
        // Maybe some text here. For now in debug log
        Debug.Log("unit stunned");
    }
    private void unitDOTed(basePlayer unit,baseSkill skill)
    {
        //Apply DOT on turn attacking before attack, check for health.
        --battleManager.actions;
        if (unit.duration == 0){
            clearEffect(unit,skill);
        }
        else{
            unit.currentHP -= skill.additionalEffect.power;
            --unit.duration;
        }
    }
    private void unitDOTed(baseEnemy unit,baseSkill skill)
    {
        //check for 0
        --battleManager.actions;
        if (unit.duration == 0){
            clearEffect(unit,skill);
        }
        //Apply DOT on turn attacking before attack
        else{
            unit.currentHP -= skill.additionalEffect.power;
            --unit.duration;
        }
        
        if (unit.currentHP <= 0)
            battleManager.deadUnit(unit);
        
    }
    private void unitSkipped(basePlayer unit,baseEnemy target, baseSkill skill) {
        if (unit.duration == 0)
        {
            unit.currentHP -= skill.cast(unit, target);
            clearEffect(target,skill);
        }
        else
            --unit.duration;
        --battleManager.actions;
    }
    private void unitSkipped(baseEnemy unit,basePlayer target,baseSkill skill) {
        if (unit.duration == 0)
        {
            unit.currentHP -= skill.cast(unit, target);
            clearEffect(target,skill);
        }
        else
            --unit.duration;
        --battleManager.actions;
    }
}