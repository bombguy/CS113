using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
    ActionBar[] actionBars;
    ActionBar displayBar;

    PanelController playerPanel;
    enemyPanelController enemyPanel;
    
    basePlayer _unit;
    baseSkill _skill;
    basePlayer _buffUnit;
    baseEnemy _enemy;

    bool action;
    bool attack;

    void Awake() { 
        actionBars = GetComponentsInChildren<ActionBar>();
        playerPanel = GetComponentInChildren<PanelController>();
        enemyPanel = GetComponentInChildren<enemyPanelController>();
    }
    // Use this for initialization
	void Start () {
	}
    public bool hasAttack() { return attack; } // if True we are attacking. If false we are buffing.
    public bool hasAction() { return action; }
    public basePlayer getUnit() { return _unit; }
    public baseSkill getSkill() { return _skill; }
    public baseEnemy getEnemy() { return _enemy; }
    public basePlayer getBuffed() { return _buffUnit; }
    
    //Load in GUI based on players and enemies
    public void loadGUI(basePlayer[] players, baseEnemy[] enemies)
    {
        for (int i = 0; i < players.Length; ++i)
        {
            actionBars[i].setActionBar(players[i]);
        }
        displayBar = actionBars[actionBars.Length - 1];
        playerPanel.setPlayerButtons(players);
        enemyPanel.setEnemyButtons(enemies);
    }
    //Update TheG UI with a chance of setting off an action.
    public void updateGUI(){
        updatePlayerPanel();
        updateDisplayBar();
        updateActiveBar();
        updateEnemyPanel();
    }
    //Update the DisplayActionBar
    public void updateDisplayBar() {
        if (_unit == null) {
            displayBar.setBlank();
        }
        if (_unit != null)
            displayBar.setActionBar(fetchActionBar(_unit));
    }
    //check if display bar has picked a skll yet.
    public void updateActiveBar() {
        if (displayBar.hasSelected()) {
            _skill = displayBar.getSkill();
            displayBar.resetSelected();
        }
    }
    //Update the PlayerPanel choice.
    public void updatePlayerPanel()
    {
        if (playerPanel.isSelected())
        {
            if (_unit == null)
            {
                _unit = playerPanel.getPlayer();
            }
            else if (_unit == playerPanel.getPlayer())
            {
                _unit = null;
            }
            else
            {
                if (_skill != null && _skill.targetPlayer)
                {
                    _buffUnit = playerPanel.getPlayer();
                    action = true;
                    attack = false;
                }
                else
                    Debug.LogError("Tried to Attack friendly Unit with Damaging Spell");
            }
            playerPanel.resetSelected();
        }
    }
    //update the enemyPanel choice.
    public void updateEnemyPanel() {
        if (enemyPanel.hasSelected)
        {
            if (_skill != null && _skill.targetEnemy)
            {
                _enemy = enemyPanel.getEnemy();
                action = true;
                attack = true;
            }
            else
                Debug.Log("Attempted to Buff a EnemyTarget");
            enemyPanel.resetSelected();
        }
    }
    //Used to find the right actionBar when updating the displayBar
    ActionBar fetchActionBar(basePlayer unit) {
        for (int i = 0; i < actionBars.Length; ++i) {
            if (unit == actionBars[i].getUnit())
                return actionBars[i];
        }
        return actionBars[0];
    }
    //Applys an action to the GUI
    public void endAction(){
        playerPanel.applyPlayerSelection();
        displayBar.applySkillSelection();
        fetchActionBar(_unit).setActionBar(displayBar);
        action = false;
    }
    //Usedon end turn.
    public void beginTurn() {
        playerPanel.enablePlayers();
        displayBar.setBlank();
    }
    public void endTurn() { }
    // Update is called once per frame
	void Update () {
        
    }

    void updateDebug()
    {
        Debug.Log("Unit " + _unit.name);
        Debug.Log("Skill " + _skill.skillName);
    }
}
