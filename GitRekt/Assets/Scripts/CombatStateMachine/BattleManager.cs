using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour {
    public CombatStateMachine stateMachine;
    
    public static basePlayer selectedUnit;
    public static basePlayer healTarget;
    public static baseEnemy attackTarget;
    public static baseSkill skill;
	
	void Awake () {
        stateMachine = GetComponent<CombatStateMachine>();
        InitBattle();
	}
    void InitBattle() {
        selectedUnit = null;
        healTarget = null;
        attackTarget = null;
        skill = null;
    }
	/*
     * Update checks every frame if our touch events are finsihed. If so
     * We go to the coroutine In either Player heal or Player Attack. 
     */
	void Update () {
        if (attackTarget != null && skill != null && selectedUnit != null)
            CombatStateMachine.CurrentState = CombatStateMachine.CombatStates.PLAYERATTACK;
        else if (selectedUnit != null && healTarget != null && selectedUnit != null)
            CombatStateMachine.CurrentState = CombatStateMachine.CombatStates.PLAYERHEAL;
	}
    public static void endTurn() {
        selectedUnit = null;
        healTarget = null;
        attackTarget = null;
        skill = null;
    }

}
