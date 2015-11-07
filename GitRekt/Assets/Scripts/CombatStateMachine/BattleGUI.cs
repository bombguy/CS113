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
	private basePlayer[] players;
	private baseEnemy[] enemies;

	private basePlayer selectedPlayer;
	private baseSkill selectedSkill;
	private baseGameObject selectedTarget;

	// Use this for initialization
	void Start () {
		players = GameInformation.players;
		enemies = GameInformation.enemies;
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    void OnGUI()
    {
		//test
		DisplayEnemies();
		DisplayPlayers();

        if (CombatStateMachine.CurrentState == CombatStateMachine.CombatStates.PLAYERSELECT) {
			GUI.Label (new Rect (20, Screen.height / 4 - 30, 100, 30), "Choose Player");
			DisplayPlayers();
		}
		if (CombatStateMachine.CurrentState == CombatStateMachine.CombatStates.PLAYERACTION) {
			DisplayPlayerChoices();
		}
		if (CombatStateMachine.CurrentState == CombatStateMachine.CombatStates.PLAYERTARGET) {
			GUI.Label (new Rect (Screen.width-170, Screen.height/4-30, 100, 30), "Choose Target");
			DisplayEnemies();
			DisplayPlayers();
		}
		if (CombatStateMachine.CurrentState == CombatStateMachine.CombatStates.ENEMY)
			test();

    }
	private void test() {
		if (GUI.Button (new Rect (Screen.width - 500, Screen.height - 50, 100, 30), "Player Turn")) {
			CombatStateMachine.CurrentState = CombatStateMachine.CombatStates.PLAYERSELECT;
		}
	}

	private void DisplayPlayers() {
		int i = 0;
		foreach (basePlayer player in players) {
			if (GUI.Button(new Rect(20, Screen.height / (4-i), 150, 30), player.name + "\nHP: " + player.currentHP.ToString()  + " / " + player.maxHP.ToString())) {
				selectedPlayer = player;
				CombatStateMachine.CurrentState = CombatStateMachine.CombatStates.PLAYERACTION;
			}
			i++;
		}
	}

	private void DisplayEnemies() {
		int i = 0;
		foreach (baseEnemy enemy in enemies) {
			if (enemy.name.Length > 0) {
				if (GUI.Button(new Rect(Screen.width-170, Screen.height / (4-i), 150, 30), enemy.name + "\nHP: " + enemy.currentHP.ToString()  + " / " + enemy.maxHP.ToString())) {
					selectedTarget = enemy;
					print ("target: " + (selectedTarget as baseEnemy).name + " HP: " + (selectedTarget as baseEnemy).currentHP);
					print ("skill: " + selectedSkill.skillName + " damage: " + selectedSkill.cast(selectedPlayer.attack));
					(selectedTarget as baseEnemy).currentHP = (selectedTarget as baseEnemy).currentHP - selectedSkill.cast(selectedPlayer.attack);
					CombatStateMachine.CurrentState = CombatStateMachine.CombatStates.ENEMY;
				}
			}
			i++;
		}
	}

    private void DisplayPlayerChoices(){
        if (GUI.Button(new Rect(Screen.width - 500, Screen.height - 50, 100, 30), selectedPlayer.skill1.skillName)){
			if (selectedPlayer.skill1.skillName != "-") {
				selectedSkill = selectedPlayer.skill1;
            	CombatStateMachine.CurrentState = CombatStateMachine.CombatStates.PLAYERTARGET;
			}
        }
		if (GUI.Button(new Rect(Screen.width - 400, Screen.height - 50, 100, 30), selectedPlayer.skill1.skillName)){
			if (selectedPlayer.skill2.skillName != "-") {
				selectedSkill = selectedPlayer.skill1;
				CombatStateMachine.CurrentState = CombatStateMachine.CombatStates.PLAYERTARGET;
			}
		}
		if (GUI.Button(new Rect(Screen.width - 300, Screen.height - 50, 100, 30), selectedPlayer.skill1.skillName)){
			if (selectedPlayer.skill3.skillName != "-") {
				selectedSkill = selectedPlayer.skill1;
				CombatStateMachine.CurrentState = CombatStateMachine.CombatStates.PLAYERTARGET;
			}
		}
		if (GUI.Button(new Rect(Screen.width - 200, Screen.height - 50, 100, 30), selectedPlayer.skill1.skillName)){
			if (selectedPlayer.skill4.skillName != "-") {
				selectedSkill = selectedPlayer.skill1;
				CombatStateMachine.CurrentState = CombatStateMachine.CombatStates.PLAYERTARGET;
			}
		}
		if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 50, 100, 30), selectedPlayer.basicAttack.skillName)){
			if (selectedPlayer.basicAttack.skillName != "-") {
				selectedSkill = selectedPlayer.basicAttack;
				CombatStateMachine.CurrentState = CombatStateMachine.CombatStates.PLAYERTARGET;
			}
		}
    }
}
