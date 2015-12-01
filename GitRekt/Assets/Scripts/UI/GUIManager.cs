using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

    PanelController playerPanel;
    enemyPanelController enemyPanel;
    
    basePlayer _unit;
    baseSkill _skill;
    basePlayer _buffUnit;
    baseEnemy _enemy;

    bool action;
    bool attack;

    void Awake() {
        playerPanel = GetComponentInChildren<PanelController>();
        enemyPanel = GetComponentInChildren<enemyPanelController>();
    }
    public void resetAttack() { attack = false; }
    public bool hasAttack() { return attack; } // if True we are attacking. If false we are buffing.
    public void resetAction() { action = false; }
    public bool hasAction() { return action; }
    
    //Getters for BattleManager
    public basePlayer getUnit() { return _unit; }
    public baseSkill getSkill() { return _skill; }
    public baseEnemy getEnemy() { return _enemy; }
    public basePlayer getBuffed() { return _buffUnit; }
    
    //Load in GUI based on players and enemies
    public void loadGUI(basePlayer[] players, baseEnemy[] enemies)
    {
        Debug.Log("In Load GUI");
        for (int i = 0; i < players.Length; ++i)
            Debug.Log("Player :" + players[i]);
            playerPanel.setPlayerButtons(players);
        enemyPanel.setEnemyButtons(enemies);
    }
    //Update The GUI with a chance of setting off an action.
    public void updateGUI(){
        updatePlayerPanel();
        updateEnemyPanel();
    }
    //check if display bar has picked a skll yet.
    //Update the PlayerPanel choice.
    public void updatePlayerPanel()
    {
        if (playerPanel.hasSelected)
        {
            if (_unit == null)
            {
                _unit = playerPanel._currentPlayer;
                
            }
            else if (_unit == playerPanel._currentPlayer)
            {
                _unit = null;
                _skill = null;
               
            }
            else if(_unit != null && _skill == null && _unit!=playerPanel._currentPlayer){
                _unit = playerPanel._currentPlayer;
            }
            else
            {
                if (_skill != null && _skill.targetPlayer)
                {
                    _buffUnit = playerPanel._currentPlayer;
                    action = true;
                    attack = false;
                }
                else
                    Debug.LogError("Tried to Attack friendly Unit with Damaging Spell");
            }
            playerPanel.hasSelected = false;
        }
    }
    //update the enemyPanel choice.
    public void updateEnemyPanel() {
        if (enemyPanel._hasSelected)
        {
            if (_skill != null && _skill.targetEnemy)
            {
                _enemy = enemyPanel._selectedEnemy;
                action = true;
                attack = true;
            }
            else
                Debug.Log("Attempted to Buff a EnemyTarget");
            enemyPanel._hasSelected = false;
        }
    }
    //Used to find the right actionBar when updating the displayBar
    public void updateActionBar() { 
        
    }

    //Applys an action to the GUI
    
    public void endAction(){
        playerPanel.disablePlayer();
        action = false;
    }
    //Usedon end turn.
    public void beginTurn() {
        playerPanel.enablePlayers();
    }
    public void endTurn() { }
    // Update is called once per frame
	void Update () {    
    }
}
