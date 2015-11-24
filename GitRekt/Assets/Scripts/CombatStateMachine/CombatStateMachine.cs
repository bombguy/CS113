using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatStateMachine:MonoBehaviour{

    public AI enemy;
    public enum CombatStates {PLAYERSELECT,PLAYERENEMY,PLAYERPLAYER,ENEMY,WIN,LOSE};
    public static CombatStates CurrentState;
    private bool goal; 
    void Start () {
        Random.seed = 0;
        enemy = GetComponent<AI>();
        goal = false;
        CurrentState = CombatStates.PLAYERSELECT;
    }
	
	void Update () {
        Debug.Log(CurrentState);
        switch (CurrentState) {
            case (CombatStates.PLAYERSELECT):
                //Check Unit selected. Handled in displaySkillx
                break;
            case(CombatStates.PLAYERENEMY):
               StartCoroutine("enemyTarget");
               checkVictory(); // Also passes the turn. We might want to change that
                break;
            case(CombatStates.PLAYERPLAYER):
                StartCoroutine("playerTarget");
                checkVictory();
                break;
            case (CombatStates.ENEMY):
                StartCoroutine("enemyAction");
                if (goal)
                    CurrentState = CombatStates.LOSE;
                else
                    CurrentState = CombatStates.PLAYERSELECT;
                break;
            case (CombatStates.LOSE):
                break;
            case (CombatStates.WIN):
                break;
        }
	}
    private void checkVictory()
    {
        if (BattleManager.enemyParty.Count == 0)
            goal = true;
        if (goal){
            BattleManager.endTurn();
            CurrentState = CombatStates.WIN;
        }
        else{
            --BattleManager.actions;
            if(BattleManager.actions == 0){
                BattleManager.endTurn();
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
    IEnumerator enemyAction() {
        baseEnemy attacker = GameInformation.enemies[Random.Range(0, GameInformation.enemies.Length)];
        basePlayer target = enemy.lowestHealthTarget(GameInformation.players);
        EnemyAttack(attacker, target);
        goal = true;
        for (int i = 0; i < GameInformation.players.Length; ++i)
            if (GameInformation.players[i].currentHP > 0)
                goal = false;
        yield return null;
    }
    IEnumerator enemyTarget()
    {
        enemyTarget(BattleManager.selectedUnit, BattleManager.attackTarget, BattleManager.skill);
        yield return null;
    }
    IEnumerator playerTarget() {
        playerTarget(BattleManager.selectedUnit, BattleManager.healTarget, BattleManager.skill);
        yield return null;
    }
    private void EnemyAttack(baseEnemy attacker, basePlayer target){
		attacker.basicAttack.cast (attacker, target);
        if (target.currentHP <= 0)
            target.currentHP = 0;
    }

    private void clearEffect(basePlayer unit) {
        unit.effect = basePlayer.Status.NONE;
        unit.duration = 0;
        unit.effected = false;
    }
    private void clearEffect(baseEnemy unit) {
        unit.effect = baseEnemy.Status.NONE;
        unit.duration = 0;
        unit.effected = false;
    }
    private void applyEffect(baseEnemy unit, baseSkill skill) {
        unit.effect = (baseEnemy.Status)skill.additionalEffect.status;
        unit.duration = 0;
        unit.effected = false;
    }
    private void applyEffect(basePlayer unit, baseSkill skill) {
        unit.effect = (basePlayer.Status)skill.additionalEffect.status;
        unit.duration = skill.additionalEffect.duration;
        unit.effected = true;
    }
    //PLAYER ATTACKING ENEMY CHECK WHATS GOING ON, apply effects
    /*
     * Effects. These effect units in some way or another
      	STUN - skip turn
		CONFUSED - Pokemon style. attack may hit anyone
		AOE - AOE effect
		HEAL - Heal target
		DOT - Damage over time
		GOD - ?
		ATTACK - ?
		DEFENSE - ?
		SKIP - skip turn for build up of attack.
     */
    private void unitStunned(basePlayer unit) {
        // Stunned effect. Actions minus/ Player doesnt take turn
        --BattleManager.actions;
        --unit.duration;
        if (unit.duration == 0)
            clearEffect(unit);
        // Maybe some text here. For now in debug log
        Debug.Log("UNIT STUNNED! CANT ATTACK THIS ACTION TAKING AWAY 1 ACTION POINT");
    }
    private void unitStunned(baseEnemy unit)
    {
        // Stunned effect. Actions minus/ Player doesnt take turn
        --BattleManager.actions;
        --unit.duration;
        if (unit.duration == 0)
            clearEffect(unit);
        // Maybe some text here. For now in debug log
        Debug.Log("UNIT STUNNED! CANT ATTACK THIS ACTION TAKING AWAY 1 ACTION POINT");
    }
    private void unitConfused(basePlayer unit,baseEnemy target, baseSkill skill) { 
        // Attacks random target here
        int coin = Random.Range(0,1);
        if (coin == 0) { 
            //Attack allies - No Effect applied (For Now)
            int unitIndex = Random.Range(0,BattleManager.playerParty.Count);
            BattleManager.playerParty[unitIndex].currentHP -= skill.cast(unit, target);
        }
        else
        {
            // Attack Enemy - No Effect applied (For Now)
            int unitIndex = Random.Range(0, BattleManager.enemyParty.Count);
            BattleManager.enemyParty[unitIndex].currentHP -= skill.cast(unit, target);

        }

    }
    private void unitConfused(baseEnemy unit, basePlayer target, baseSkill skill) {
        // Attacks random target here
        int coin = Random.Range(0, 1);
        if (coin == 0)
        {
            //Attack allies - No Effect applied (For Now)
            int unitIndex = Random.Range(0, BattleManager.enemyParty.Count);
            BattleManager.enemyParty[unitIndex].currentHP -= skill.cast(unit, target);
        }
        else
        {
            // Attack Enemy - No Effect applied (For Now)
            int unitIndex = Random.Range(0, BattleManager.playerParty.Count);
            BattleManager.playerParty[unitIndex].currentHP -= skill.cast(unit, target);
        }

    }
    private void AOEAttack(baseEnemy unit, List<basePlayer> playerParty,baseSkill skill) { 
        // Whatever attack happens here the whole team gets effected
    }
    private void AOEAttack(basePlayer unit,List<baseEnemy> enemyParty,baseSkill skill) { 
        //Whatever attack happens here the whole enemy team gets effected
    }
    private void AOEDefend(basePlayer unit, List<basePlayer> playerParty,baseSkill skill) { 
        //Defend spells for the player Party
    }
    private void AOEDefend(baseEnemy unit, List<baseEnemy> enemyParty, baseSkill skill) { 
        //AOEDefend spells for the enemy Party
    }
    private void unitDOTed(basePlayer unit) { 
        //Apply DOT on turn attacking before attack
    }
    private void unitDOTed(baseEnemy unit) {
        //Apply DOT on turn attacking before attack
    }
    private void unitGODed(basePlayer unit) { 
        // some effect GOD 
    }
    private void unitGODed(baseEnemy unit) { 
        // some effect GOD
    }
    private void unitSkipped(basePlayer unit) { }
    private void unitSkipped(baseEnemy unit){}

    /*
     * Flow:
     * Check what we are interacting with. Player or Enemy Target?
     *  Check what effect are on the Attacking Unit.
     *      Process those effects.
     *  Carry out attack.
     *      Apply new effects if need be.
     *  Repeat process
     */
    private void enemyTarget(basePlayer attacker, baseEnemy target, baseSkill skill) {
        //target.currentHP -= skill.cast(attacker,target);
        if (attacker.effected)
        {
            switch (attacker.effect) { 
                case(basePlayer.Status.AOE):
                    break;
                case(basePlayer.Status.ATTACK):
                    break;
                case(basePlayer.Status.CONFUSED):
                    unitConfused(attacker,target,skill);
                    break;
                case(basePlayer.Status.DEFENSE):
                    break;
                case(basePlayer.Status.DOT):
                    break;
                case(basePlayer.Status.GOD):
                    break;
                case(basePlayer.Status.HEAL):
                    break;
                case(basePlayer.Status.SKIP):
                    break;
                case(basePlayer.Status.STUN):
                    unitStunned(attacker);
                    break;
            }
        }
        //Not Affacted carry out attack and see if we apply a debuff or something
        else{
            if(!target.effected){
                target.currentHP -= skill.cast(attacker,target);
                --BattleManager.actions;
                if (target.currentHP > 0)
                {
                    if (skill.hasAdditionalEffect)
                    {
                        applyEffect(target, skill);
                    }
                }
                else {
                    BattleManager.deadUnit(target);
                }
            }
            else{
                // Target is already effected, If we want to have more then 1 effect per character need a data struct
                target.currentHP -= skill.cast(attacker,target);
                --BattleManager.actions;
            }
            
        }
    }
    private void playerTarget(basePlayer unit, basePlayer target, baseSkill skill) {
        if (unit.effected)
        {
            switch (unit.effect)
            {
                case (basePlayer.Status.AOE):
                    break;
                case (basePlayer.Status.ATTACK):
                    break;
                case (basePlayer.Status.CONFUSED):
                    break;
                case (basePlayer.Status.DEFENSE):
                    break;
                case (basePlayer.Status.DOT):
                    break;
                case (basePlayer.Status.GOD):
                    break;
                case (basePlayer.Status.HEAL):
                    break;
                case (basePlayer.Status.SKIP):
                    break;
                case (basePlayer.Status.STUN):
                    break;
            }
        }
        //Not Affacted carry out heal and see if we apply a buff or something
        else
        {
            if (!target.effected)
            {
                target.currentHP += skill.cast(unit, target);
                --BattleManager.actions;
                if (skill.hasAdditionalEffect)
                    applyEffect(unit, skill);
            }
            else
            {
                // Target is already under some buff, If we want to have more then 1 effect per character we can do this
                target.currentHP += skill.cast(unit, target);
                --BattleManager.actions;
            }

        }       
    }


}
