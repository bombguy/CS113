using UnityEngine;
using System.Collections;

/*
    GUI for battles
    Player Decesions will be ran through here
    UI workflow:
        if(touch player)
            if(Spell choice)
                if(Target choice)
                    conduct combat
*/
public class BattleGUI : MonoBehaviour {

    private string playerName;
    private int playerHealth;
    
     

	// Use this for initialization
	void Start () {
        playerName = GameInformation.Player.PlayerName;
        playerHealth = GameInformation.Player.Health;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    

    void OnGUI()
    {
        if (CombatStateMachine.currentState == CombatStateMachine.CombatStates.PLAYER)
            DisplayPlayerChoices();

    }

    private void DisplayPlayerChoices(){
        if (GUI.Button(new Rect(Screen.width - 500, Screen.height - 50, 100, 30), "Spell1")){
            CombatStateMachine.currentState = CombatStateMachine.CombatStates.ENEMY;
        }
        if (GUI.Button(new Rect(Screen.width - 400, Screen.height - 50, 100, 30), "Spell2")){
            CombatStateMachine.currentState = CombatStateMachine.CombatStates.ENEMY;
        }
        if (GUI.Button(new Rect(Screen.width - 300, Screen.height - 50, 100, 30), "Spell3")){
            CombatStateMachine.currentState = CombatStateMachine.CombatStates.ENEMY;
        }
        if (GUI.Button(new Rect(Screen.width - 200, Screen.height - 50, 100, 30), "Spell4")){
            CombatStateMachine.currentState = CombatStateMachine.CombatStates.ENEMY;
        }
        if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 50, 100, 30), "Basic Attack")){
            CombatStateMachine.currentState = CombatStateMachine.CombatStates.ENEMY;
        }
    }
}
