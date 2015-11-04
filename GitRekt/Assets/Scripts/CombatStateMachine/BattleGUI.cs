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
    private string playerHealthLabel;
     

	// Use this for initialization
	void Start () {
        playerName = "Test";
        playerHealth = 100;
        playerHealthLabel = playerHealth.ToString();
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    public int PlayerHealth { get; set; }
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), playerHealthLabel);
        if (CombatStateMachine.CurrentState == CombatStateMachine.CombatStates.PLAYER)
            DisplayPlayerChoices();

    }

    private void DisplayPlayerChoices(){
        if (GUI.Button(new Rect(Screen.width - 500, Screen.height - 50, 100, 30), "Spell1")){
            CombatStateMachine.CurrentState = CombatStateMachine.CombatStates.ENEMY;
        }
        if (GUI.Button(new Rect(Screen.width - 400, Screen.height - 50, 100, 30), "Spell2")){
            CombatStateMachine.CurrentState = CombatStateMachine.CombatStates.ENEMY;
        }
        if (GUI.Button(new Rect(Screen.width - 300, Screen.height - 50, 100, 30), "Spell3")){
            CombatStateMachine.CurrentState = CombatStateMachine.CombatStates.ENEMY;
        }
        if (GUI.Button(new Rect(Screen.width - 200, Screen.height - 50, 100, 30), "Spell4")){
            CombatStateMachine.CurrentState = CombatStateMachine.CombatStates.ENEMY;
        }
        if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 50, 100, 30), "Basic Attack")){
            playerHealth = Utilities.combat(playerHealth, 10);
            playerHealthLabel = playerHealth.ToString();
            CombatStateMachine.CurrentState = CombatStateMachine.CombatStates.ENEMY;
        }
    }
}
