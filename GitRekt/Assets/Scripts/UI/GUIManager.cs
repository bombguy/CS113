using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

    static PanelController playerPanel;
    static enemyPanelController enemyPanel;
    
    public static basePlayer _unit;
    public static baseSkill _skill;
    public static basePlayer _buffUnit;
    public static baseEnemy _enemy;

    public static bool action;
    public static bool attack;

    void Awake() {
        playerPanel = GetComponentInChildren<PanelController>();
        enemyPanel = GetComponentInChildren<enemyPanelController>();
    }
    public static void updateUnit(basePlayer unit) {
        if (_unit == null && _skill == null)
            _unit = unit;
        // selected same unit before selecting skill
        else if (_unit == unit && _skill == null)
        {
            _unit = null;
        }
        // selected different unit before selecting skill
        else if (_unit != unit && _skill == null) {
            _unit = unit;
        }
        // selected a buff target that may be itself.
        else if (_unit != null && _skill != null)
        {
            _buffUnit = unit;
            action = true;
            attack = false;
        }
    }
    public static void updateSkill(baseSkill skill) {
        _skill = skill;
        //Buff Spell Target only Players
        if (skill.targetPlayer == true && skill.targetEnemy == false)
        {
            playerPanel.enableTargetMode();
            enemyPanel.disableTargetMode();
        }
        //Any other spell is considered hostile. Target enemies
        else {
            enemyPanel.enableTargetMode();
            playerPanel.enemyTargetMode();
        }
    }
    public static void updateTarget(baseEnemy enemy){
        if (_skill != null) {
            _enemy = enemy;
            action = true;
            attack = true;  
        }  
    }
    //Load in GUI based on players and enemies
    public static void loadGUI(basePlayer[] players, baseEnemy[] enemies)
    {
        playerPanel.setPlayerButtons(players);
        //enemyPanel.setEnemyButtons(enemies);
        //Debug.Log("GUI Loaded.");
    }

    //handle turn and action logic
    public static void endAction() {
        if (_buffUnit != null)
        {
            playerPanel.endAction(_unit);
        }
        else
            playerPanel.endAction();

        enemyPanel.endAction();
        action = false;
        attack = false;
        _unit = null;
        _skill = null;
        _buffUnit = null;
        _enemy = null;

        playerPanel.disableTargetMode();
        enemyPanel.disableTargetMode();
        
    }
    public static void endTurn() { 
    //Force all triggers to false.
        action = false;
        attack = false;
    }
    public static void beginTurn() {
        playerPanel.beginTurn();
        enemyPanel.disableTargetMode();
    }
    
    //Death Functions- Basically make sure they cannot be interacted with.
    public static void deadUnit(basePlayer unit)
    {
        playerPanel.fetchPlayerButton(unit).buttonDisable();
    }
    public static void deadUnit(baseEnemy unit)
    {
        unit.currentHP = -1;
        enemyPanel.fetchEnemyButton(unit).buttonDisable(); 
    }
}
