using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class combatStateMachine:MonoBehaviour {

    public enum CombatStates {START,PLAYER,ENEMY,GOAL};
    private CombatStates currentState;
    private basePlayer[] playerParty;
    private basePlayer[] enemyParty;
    private bool goal; // used to check if we hit a goal state
    
    void Start () {
        currentState = CombatStates.START;
        goal = false;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(currentState);
        switch (currentState) {
            case (CombatStates.START):
                //toDo:generate everything
                break;
            case (CombatStates.PLAYER):
                //Choose character
                //character chosen = chooseCharacter(chosen)
                //character target = chooseEnemy(chosen)
                //
                //Pick ability
                //Skill ability(Button press)
                // combat takes place
                //Status effects
                //Check for goal
                break;
            case (CombatStates.ENEMY):
                //Choose character
                //Pick ability
                //Status effects
                //Check for goal
                break;
            case (CombatStates.GOAL):
                //Determine win or loss
                // if too complex may just split into two states (WIN/LOST)
                break;
        }
	}
    public CombatStates CurrentState { get; set; }
    public basePlayer[] PlayerParty { get; set; }
    public basePlayer[] EnemyParty { get; set; }
    public bool Goal { get; set; }
    
    //Combat functions
    public void characterSelect() { }
    public void enemySelect() { }
    public void chooseAbility() { }
    public void combat() { }
    public void victory() { }
    public void loss() { }
    public void changeState(bool goal)
    {
        if (goal == false)
            switch (currentState)
            {
                case (CombatStates.START):
                    currentState = CombatStates.PLAYER;
                    break;
                case (CombatStates.PLAYER):
                    currentState = CombatStates.ENEMY;
                    break;
                case (CombatStates.ENEMY):
                    currentState = CombatStates.PLAYER;
                    break;
            }
        else
            currentState = CombatStates.GOAL;
    }
}
