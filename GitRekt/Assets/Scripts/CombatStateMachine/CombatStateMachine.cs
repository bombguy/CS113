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
		SKIP - ?
     */
    private void enemyTarget(basePlayer attacker, baseEnemy target, baseSkill skill) {
        //target.currentHP -= skill.cast(attacker,target);
        /*
        if(attacker.effected)
            if (attacker.effect_skill.additionalEffect.status ==)

        if (skill.hasAdditionalEffect) { 
            
        }
        if (target.currentHP <= 0)
            Destroy(target);
        */
    }
    private void playerTarget(basePlayer healer, basePlayer target, baseSkill skill) {
        target.currentHP+=skill.cast(healer, target);
        if (target.currentHP > target.maxHP)
            target.currentHP = target.maxHP;
    }


}
