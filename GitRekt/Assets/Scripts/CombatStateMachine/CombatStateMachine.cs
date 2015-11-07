using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatStateMachine:MonoBehaviour {

    public enum CombatStates {START,PLAYERSELECT,PLAYERACTION,PLAYERTARGET,ENEMY,GOAL};
    public static CombatStates CurrentState;
    private bool goal; // used to check if we hit a goal state
    private CombatStartState startState = new CombatStartState();

    void Start () {
        CurrentState = CombatStates.START;
		for (int i = 0; i < GameInformation.enemies.Length; i++) {
			GameInformation.enemies[i] = new C();
		}
        goal = false;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(CurrentState);
        switch (CurrentState) {
            case (CombatStates.START):
                //toDo:generate everything
                startState.PrepareBattle();
                CurrentState = CombatStates.PLAYERSELECT;
                break;
            case (CombatStates.PLAYERSELECT):
                /*event driven state machine?
                */
				if(goal)
					CurrentState = CombatStates.GOAL;
                break;
            case (CombatStates.ENEMY):
                //Choose character
                //Pick ability
                //Status effects
                //Check for goal
				if(goal)
					CurrentState = CombatStates.GOAL;
                break;
            case (CombatStates.GOAL):
                //Determine win or loss
                // if too complex may just split into two states (WIN/LOST)
                break;
        }
	}
    public void victory() { }
    public void loss() { }
    
}
