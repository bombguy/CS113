using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CombatStateMachine : MonoBehaviour
{
    public AI enemy;
    public enum CombatStates { STARTTURN,PLAYERSELECT, PLAYERENEMY, PLAYERPLAYER, ENEMY, WIN, LOSE };
    public static CombatStates CurrentState;
    private bool goal;
    int actions;
    void Start()
    {
        Random.seed = 0;
        enemy = GetComponent<AI>();
        goal = false;
        CurrentState = CombatStates.STARTTURN;
    }

    void Update()
    {
        updateMachine();
    }
    public void updateMachine() {
        //Debug.Log(CurrentState);
        switch (CurrentState)
        {
            case (CombatStates.STARTTURN):
                BattleManager.beginTurn();
                Debug.Log("(CSM)  ST -> PS");
                actions = BattleManager.playerParty.Count;
                CurrentState = CombatStates.PLAYERSELECT;
                break;
            case (CombatStates.PLAYERSELECT):
                //Check Unit selected.
                if (BattleManager.playerEnemy== true)
                {
                    Debug.Log("(CSM) PS->PE");
                    CurrentState = CombatStates.PLAYERENEMY;
                    BattleManager.playerEnemy = false;
           
                }
                else if (BattleManager.playerPlayer== true)
                {
                    Debug.Log("(CSM) PS->PP");
                    CurrentState = CombatStates.PLAYERPLAYER;
                    BattleManager.playerPlayer = false;
                }
                break;
            case (CombatStates.PLAYERENEMY):
                --actions; 
                StartCoroutine("player_target_enemy");
                checkWin();
                StartCoroutine("endAction");
                Debug.Log("ACTIONS : "+ actions);
                if (actions == 0)
                {
                    Debug.Log("(CSM) PE->E");
                    BattleManager.endTurn();
                    CurrentState = CombatStates.ENEMY;
                }
                else
                {
                    Debug.Log("(CSM) PE->PS");
                    CurrentState = CombatStates.PLAYERSELECT;
                }
                break;
            case (CombatStates.PLAYERPLAYER):
                --actions;
                StartCoroutine("player_target_player");
                StartCoroutine("endAction");
                if (actions == 0)
                {
                    Debug.Log("(CSM) PP->E");
                    BattleManager.endTurn();
                    CurrentState = CombatStates.ENEMY;
                }
                else
                {
                    Debug.Log("(CSM) PP->PS");
                    CurrentState = CombatStates.PLAYERSELECT;
                }
                break;
            case (CombatStates.ENEMY):
                actions = BattleManager.enemyParty.Count;
                for (int i = 0; i < actions; ++i )
                    StartCoroutine("enemyTurn");
                if (goal)
                {
                    Debug.Log("(CSM) E->GOAL(L)");
                    CurrentState = CombatStates.LOSE;
                }
                else
                {
                    Debug.Log("(CSM) E->ST");
                    CurrentState = CombatStates.STARTTURN;
                }
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
        BattleManager.endBattle();
    }
    private void loss()
    {
        //pass back application to map
        BattleManager.endBattle();
    }
    private void checkWin()
    {
        if (BattleManager.enemyParty.Count == 0)
            goal = true;
        if (goal)
        {
            Debug.Log("(CSM) PE->GOAL(W)");
            BattleManager.endTurn();
            CurrentState = CombatStates.WIN;
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
        switch (BattleManager._unit.effect)
        {
            // All possible states
            case (basePlayer.Status.ATTACK):
                decreaseEffect(BattleManager._unit, BattleManager._skill);
                playerAttack(BattleManager._unit, BattleManager._attackTarget, BattleManager._skill);
                break;
            case (basePlayer.Status.CONFUSED):
                unitConfused(BattleManager._unit, BattleManager._attackTarget, BattleManager._skill);
                break;
            case (basePlayer.Status.DEFENSE):
                decreaseEffect(BattleManager._unit, BattleManager._skill);
                playerAttack(BattleManager._unit, BattleManager._attackTarget, BattleManager._skill);
                break;
            case (basePlayer.Status.DOT):
                unitDOTed(BattleManager._unit, BattleManager._skill);
                playerAttack(BattleManager._unit, BattleManager._attackTarget, BattleManager._skill);
                break;
            case (basePlayer.Status.SKIP):
                unitSkipped(BattleManager._unit, BattleManager._attackTarget, BattleManager._skill);
                if (!BattleManager._unit.effected)
                    playerAttack(BattleManager._unit, BattleManager._attackTarget, BattleManager._skill);
                break;
            case (basePlayer.Status.STUN):
                unitStunned(BattleManager._unit, BattleManager._skill);
                break;
            default:
                playerAttack(BattleManager._unit, BattleManager._attackTarget, BattleManager._skill);
                break;
        }
        yield return null;
    }
    //Player targeted other player
    IEnumerator player_target_player()
    {
        switch (BattleManager._unit.effect)
        {
            //All possible states our players can be in
            case (basePlayer.Status.ATTACK):
                decreaseEffect(BattleManager._unit, BattleManager._skill);
                playerBuff(BattleManager._unit, BattleManager._buffTarget, BattleManager._skill);
                break;
            case (basePlayer.Status.CONFUSED):
                unitConfused(BattleManager._unit, BattleManager._buffTarget, BattleManager._skill);
                break;
            case (basePlayer.Status.DEFENSE):
                decreaseEffect(BattleManager._unit, BattleManager._skill);
                playerBuff(BattleManager._unit, BattleManager._attackTarget, BattleManager._skill);
                break;
            case (basePlayer.Status.DOT):
                unitDOTed(BattleManager._unit, BattleManager._skill);
                playerBuff(BattleManager._unit, BattleManager._attackTarget, BattleManager._skill);
                break;
            case (basePlayer.Status.SKIP):
                unitSkipped(BattleManager._unit, BattleManager._attackTarget, BattleManager._skill);
                if (!BattleManager._unit.effected)
                    playerBuff(BattleManager._unit, BattleManager._attackTarget, BattleManager._skill);
                break;
            case (basePlayer.Status.STUN):
                unitStunned(BattleManager._unit, BattleManager._skill);
                break;
            default:
                playerBuff(BattleManager._unit, BattleManager._buffTarget, BattleManager._skill);
                break;
        }
        yield return null;
    }
    IEnumerator enemyTurn()
    {
        actions = BattleManager.enemyParty.Count;
        Debug.Log("In enemy Action");
        Debug.Log("Actions Left: " + actions);
        
        baseEnemy attacker = BattleManager.enemyParty[Random.Range(0, BattleManager.enemyParty.Count)];
        basePlayer target = enemy.lowestHealthTarget(BattleManager.playerParty);
        enemyAction(attacker, target, attacker.basicAttack);
        
        yield return null;
    }

    IEnumerator endAction() {
        BattleManager.endAction();
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
                Debug.Log("(CSM) Player Attack Player/Enemy-> Damage = 0; Reason: GodModed");
                clearEffect(target, skill);
            }
            else
            {
                int damage = skill.cast(unit);
                Debug.Log("(CSM) Player Attack -> Damage =" + damage);
                target.currentHP -= damage;
                if (target.currentHP >= 0)
                    if (!target.effected)
                        applyEffect(target, skill);
                    else
                        BattleManager.deadUnit(target);
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
                Debug.Log("(CSM) PlayerAttack Player/Player Damage = 0; God Moded");
                clearEffect(target, skill);
            }
            else
            {
                target.currentHP -= skill.cast(unit);
                if (target.currentHP >= 0)
                    if (!target.effected)
                        applyEffect(target, skill);
                    else
                        BattleManager.deadUnit(target);
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

                target.attack += skill.additionalEffect.power;
                applyEffect(target, skill);
            }
            else if (skill.additionalEffect.status == baseSkill.Effect.Status.DEFENSE && skill.targetPlayer)
            {
                target.defense += skill.additionalEffect.power;
                applyEffect(target, skill);
            }
        }
        else if (skill.additionalEffect.status == baseSkill.Effect.Status.HEAL && skill.targetPlayer)
        {
            target.currentHP += skill.cast(unit);
            //Check here for effects. HOTS?
        }
    }
    private void playerBuff(basePlayer unit, baseEnemy target, baseSkill skill)
    {
        if (!target.effected)
        {
            if (skill.additionalEffect.status == baseSkill.Effect.Status.ATTACK && skill.targetPlayer)
            {
                target.attack += skill.additionalEffect.power;
                applyEffect(target, skill);
            }
            else if (skill.additionalEffect.status == baseSkill.Effect.Status.DEFENSE && skill.targetPlayer)
            {
                target.defense += skill.additionalEffect.power;
                applyEffect(target, skill);
            }
        }
        else if (skill.additionalEffect.status == baseSkill.Effect.Status.HEAL && skill.targetPlayer)
        {
            target.currentHP += skill.cast(unit);
            //Check here for effects. HOTS?
        }
    }
    //Enemy Turn States
    private void enemyAction(baseEnemy unit, basePlayer target, baseSkill skill)
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
                unitSkipped(unit, target, BattleManager._skill);
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
            target.currentHP -= skill.cast(attacker);
            if (skill.hasAdditionalEffect)
                if (target.currentHP <= 0)
                    BattleManager.deadUnit(target);
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
            target.currentHP -= skill.cast(attacker);
            if (skill.hasAdditionalEffect)
                if (target.currentHP <= 0)
                    BattleManager.deadUnit(target);
                else if (!target.effected)
                    applyEffect(target, skill);
        }
    }
    //AOE Attack states
    private void AOEattack(basePlayer unit, baseEnemy target, baseSkill skill)
    {
        int enemiesLeft = BattleManager.enemyParty.Count;
        int damage = skill.cast(unit);
        for (int i = 0; i < enemiesLeft; ++i)
        {
            if (BattleManager.enemyParty[i] != null)
            {
                BattleManager.enemyParty[i].currentHP -= damage;
                if (BattleManager.enemyParty[i].currentHP <= 0)
                {
                    BattleManager.deadUnit(BattleManager.enemyParty[i]);
                }
            }
        }
    }
    private void AOEattack(basePlayer unit, basePlayer target, baseSkill skill)
    {
        int playersLeft = BattleManager.playerParty.Count;
        int damage = skill.cast(unit);
        for (int i = 0; i < playersLeft; ++i)
        {
            if (BattleManager.playerParty[i] != null)
            {
                BattleManager.playerParty[i].currentHP -= damage;
                if (BattleManager.playerParty[i].currentHP <= 0)
                {
                    BattleManager.deadUnit(BattleManager.playerParty[i]);
                }
            }
        }
    }
    private void AOEattack(baseEnemy unit, basePlayer target, baseSkill skill)
    {
        int playersLeft = BattleManager.playerParty.Count;
        int damage = skill.cast(unit);
        for (int i = 0; i < playersLeft; ++i)
        {
            if (BattleManager.playerParty[i] != null)
            {
                BattleManager.playerParty[i].currentHP -= damage;
                if (BattleManager.playerParty[i].currentHP <= 0)
                {
                    BattleManager.deadUnit(BattleManager.playerParty[i]);
                }
            }
        }
    }
    private void AOEattack(baseEnemy unit, baseEnemy target, baseSkill skill)
    {
        int enemiesLeft = BattleManager.enemyParty.Count;
        int damage = skill.cast(unit);
        for (int i = 0; i < enemiesLeft; ++i)
        {
            if (BattleManager.enemyParty[i] != null)
            {
                BattleManager.enemyParty[i].currentHP -= damage;
                if (BattleManager.enemyParty[i].currentHP <= 0)
                {
                    BattleManager.deadUnit(BattleManager.enemyParty[i]);
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
            int unitIndex = Random.Range(0, BattleManager.playerParty.Count);
            --unit.duration;
            if (BattleManager.playerParty[unitIndex] != null)
                playerAttack(unit, BattleManager.playerParty[unitIndex], skill);
        }
        else
        {
            // Attack Enemy 
            int unitIndex = Random.Range(0, BattleManager.enemyParty.Count);
            --unit.duration;
            if (BattleManager.enemyParty[unitIndex] != null)
                playerAttack(unit, BattleManager.enemyParty[unitIndex], skill);
        }

    }
    private void unitConfused(basePlayer unit, basePlayer target, baseSkill skill){
        // Attacks random target here
        int coin = Random.Range(0, 1);
        if (coin == 0)
        {
            //Attack allies - No Effect applied (For Now)
            int unitIndex = Random.Range(0, BattleManager.playerParty.Count);
            --unit.duration;
            if (BattleManager.playerParty[unitIndex] != null)
                playerBuff(unit, BattleManager.playerParty[unitIndex], skill);
        }
        else
        {
            // Attack Enemy - No Effect applied (For Now)
            int unitIndex = Random.Range(0, BattleManager.enemyParty.Count);
            --unit.duration;
            if (BattleManager.enemyParty[unitIndex] != null)
                playerBuff(unit, BattleManager.enemyParty[unitIndex], skill);
        }
    
    }
    private void unitConfused(baseEnemy unit, basePlayer target, baseSkill skill)
    {
        int coin = Random.Range(0, 1);
        if (coin == 0)
        {
            //Attack allies - No Effect applied (For Now)
            int unitIndex = Random.Range(0, BattleManager.playerParty.Count);
            --unit.duration;
            if (BattleManager.playerParty[unitIndex] != null)
                enemyAttack(unit, BattleManager.enemyParty[unitIndex],unit.basicAttack);
        }
        else
        {
            // Attack Enemy - No Effect applied (For Now)
            int unitIndex = Random.Range(0, BattleManager.enemyParty.Count);
            --unit.duration;
            if (BattleManager.enemyParty[unitIndex] != null)
                enemyAttack(unit, BattleManager.playerParty[unitIndex], unit.basicAttack);
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
        --unit.duration;
        if (unit.duration == 0)
            clearEffect(unit,skill);
        // Maybe some text here. For now in debug log
        Debug.Log("unit stunned");
    }
    private void unitDOTed(basePlayer unit,baseSkill skill)
    {
        //Apply DOT on turn attacking before attack, check for health.
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
        if (unit.duration == 0){
            clearEffect(unit,skill);
        }
        //Apply DOT on turn attacking before attack
        else{
            unit.currentHP -= skill.additionalEffect.power;
            --unit.duration;
        }
        
        if (unit.currentHP <= 0)
            BattleManager.deadUnit(unit);
        
    }
    private void unitSkipped(basePlayer unit,baseEnemy target, baseSkill skill) {
        if (unit.duration == 0)
        {
            unit.currentHP -= skill.cast(unit);
            clearEffect(target,skill);
        }
        else
            --unit.duration;
    }
    private void unitSkipped(baseEnemy unit,basePlayer target,baseSkill skill) {
        if (unit.duration == 0)
        {
            unit.currentHP -= skill.cast(unit);
            clearEffect(target,skill);
        }
        else
            --unit.duration;
    }
}