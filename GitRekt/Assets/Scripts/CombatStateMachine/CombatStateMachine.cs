using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatStateMachine:MonoBehaviour{

    public AI enemy;
    public enum CombatStates {PLAYERSELECT,PLAYERATTACK,PLAYERHEAL,ENEMY,WIN,LOSE};
    public static CombatStates CurrentState;
    private bool goal; 
    void Start () {
        enemy = GetComponent<AI>();
        
        for (int i = 0; i < GameInformation.enemies.Length; i++) {
			GameInformation.enemies[i] = new C();
		}
        goal = false;
        CurrentState = CombatStates.PLAYERSELECT;
    }
	
	void Update () {
        Debug.Log(CurrentState);
        switch (CurrentState) {
            case (CombatStates.PLAYERSELECT):
                //Check Unit selected. Handled in displaySkillx
                break;
            case(CombatStates.PLAYERATTACK):
                StartCoroutine("playerAttack");
                checkVictory(); // Also passes the turn. We might want to change that
                break;
            case(CombatStates.PLAYERHEAL):
                StartCoroutine("playerHeal");
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
            BattleManager.endTurn();
            CurrentState = CombatStates.ENEMY;
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
    IEnumerator playerAttack() {
        playerAttack(BattleManager.selectedUnit, BattleManager.attackTarget, BattleManager.skill);
        yield return null;
    }
    IEnumerator playerHeal() {
        playerHeal(BattleManager.selectedUnit, BattleManager.healTarget, BattleManager.skill);
        yield return null;
    }
    private void EnemyAttack(baseEnemy attacker, basePlayer target){
        int damage = attacker.basicAttack.cast(attacker.attack);
        target.currentHP -= damage;
        if (target.currentHP <= 0)
            target.currentHP = 0;
    }
    /*
     * Player attacks a target
     * casts the skill according the players attack
     * This can change by adding some logic to check what level/school the attack is in
     * something like
     *  case(skill category = skill category x):
     *     dmg = skill.cast(attackers skill level
     *     break;
     *   repeat until all 4 spells and basic attack are included
     *   
     * Same thing said about healz
     */
    private void playerAttack(basePlayer attacker, baseEnemy target, baseSkill skill) {
        int damage = skill.cast(attacker.attack);
        target.currentHP -= damage;
        if (target.currentHP <= 0)
            Destroy(target);
    }
    private void playerHeal(basePlayer healer, basePlayer target, baseSkill skill) {
        int heal = skill.cast(healer.defense);
        target.currentHP += heal;
        if (target.currentHP > target.maxHP)
            target.currentHP = target.maxHP;
    }
}
