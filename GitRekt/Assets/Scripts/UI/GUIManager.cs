using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

    PanelController playerPanel;
    enemyPanelController enemyPanel;
    
    public basePlayer _unit;
    public baseSkill _skill;
    public basePlayer _buffUnit;
    public baseEnemy _enemy;

    public bool action;
    public bool attack;

    void Awake() {
        playerPanel = GetComponentInChildren<PanelController>();
        enemyPanel = GetComponentInChildren<enemyPanelController>();
    }
    
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
    //Update the PlayerPanel choice.
    public void updatePlayerPanel()
    {
        //Check if player unit has been selected
        if (playerPanel.hasSelected){
            //No unit selected
            if (_unit == null){
                _unit = playerPanel._currentPlayer;
                _skill = playerPanel._currentSkill;
            }
            //Unit selected again
            else if (_unit == playerPanel._currentPlayer){
                _unit = null;
                _skill = null;
            }
            //Unit Different from the original target
            else if(_unit != null && _unit!=playerPanel._currentPlayer){
                //Check if target mode is on.
                if (playerPanel.targetMode){
                    //If spell can target player. Take action. Else do nothing
                    if (_skill.targetPlayer){
                        _buffUnit = playerPanel._currentPlayer;
                        playerPanel.hasSelected = false;
                        action = true;
                        attack = false;
                    }
                    else{
                        Debug.Log("Attempted to use a spell that cannot be casted on a player unit.");
                    }
                }
                //Target mode is off. so _unit and _skill change.
                else {
                    _unit = playerPanel._currentPlayer;
                    _skill = playerPanel._currentSkill;
                }
            }
            playerPanel.hasSelected = false;
        }
    }
    //update the enemyPanel choice.
    public void updateEnemyPanel() {
        if (enemyPanel._hasSelected)
        {
            if (_skill == null)
            {
                _enemy = enemyPanel._selectedEnemy;
            }
            else if (_skill.targetEnemy)
            {
                _enemy = enemyPanel._selectedEnemy;
                action = true;
                attack = true;
            }
            else
                Debug.Log("Cant buff an enemy Player.");
            enemyPanel._hasSelected = false;
                
        }
    }

    //handle turn and action logic
    public void endAction() {
        playerPanel.endAction();
    }
    public void endTurn() { 
    //Force all triggers to false.
        action = false;
        attack = false;
        for (int i = 0; i < playerPanel.count(); ++i)
            playerPanel.endTurn();
    }
    public void beginTurn() {
        playerPanel.beginTurn();
    }
    // Update is called once per frame
	void Update () {
        updateGUI();
    }
}
