using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatStateMachine:MonoBehaviour {

    public enum CombatStates {START,PLAYER,ENEMY,GOAL};
    public static CombatStates CurrentState;
    public basePlayer[] PlayerParty { get; set; }
    public basePlayer[] EnemyParty { get; set; }
    private bool goal; // used to check if we hit a goal state
    private CombatStartState startState = new CombatStartState();

    void Start () {
        CurrentState = CombatStates.START;
        goal = false;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(CurrentState);
        switch (CurrentState) {
            case (CombatStates.START):
                //toDo:generate everything
                startState.PrepareBattle();
                CurrentState = CombatStates.PLAYER;
                break;
            case (CombatStates.PLAYER):
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

    //Combat functions
    public void combat(basePlayer friendly,basePlayer target, baseSkill skill) {
        //Algorithm:
        target.Health = target.Health - ((skill.Power * friendly.Attack) + friendly.Attack); 
    }
    public void victory() { }
    public void loss() { }
    
}
