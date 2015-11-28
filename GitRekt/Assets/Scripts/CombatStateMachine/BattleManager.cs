using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour {
    public basePlayer _selectedUnit;
    public basePlayer _buffTarget;
    public baseEnemy _attackTarget;
    public baseSkill _skill;
   
    public List<basePlayer> playerParty;
    public List<baseEnemy> enemyParty;   
    public   int actions;
    public   int turnCounter;

    //Bools for control
    public  bool skill_active;
    public  bool selected_unit;
    public  bool target_unit;
    public  bool buff_unit;
    //GUI Handlers
    public  ActionBar[] actionBars;
    public  ActionBar activeBar;

    public PanelController playerPanel;
    public enemyPanelController enemyPanel;
	void Awake () {
        playerParty = new List<basePlayer>();
        enemyParty = new List<baseEnemy>();


	}
    void InitBattle() {
        //LoadInformation.LoadAllInformation();
        turnCounter = 1;
        actions = 4;

        for (int i = 0; i < GameInformation.players.Length; ++i){
            playerParty.Add(GameInformation.players[i].deepCopy());
            actionBars[i].loadActionBar(playerParty[i]);
        }
    }

	void Update () {
        checkSelectedUnit();
        checkActiveActionBar();
        checkTarget();
	}
    public void checkSelectedUnit() {
        if (playerPanel.hasSelected)
        {
            _selectedUnit = playerPanel._currentPlayer._player;
            selected_unit = true;
            playerPanel.hasSelected = false;
            Debug.Log("UNIT SELECTED: " + _selectedUnit.name);
        }
    }
    public void checkActiveActionBar() {
        if (activeBar.hasSelected) {
            _skill = activeBar.selected_skill.current_skill;
            skill_active = true;
            Debug.Log("SKILL CHOSEN:" +_skill.skillName);
        }

    }
    public void checkTarget() {
        if (enemyPanel.hasSelected) {
            _attackTarget = enemyPanel._currentEnemy._enemy;
            target_unit = true;
            enemyPanel.hasSelected = false;
            Debug.Log("ENEMY CHOSEN:" + _attackTarget.name);
        }
    }
    public void endAction() {
        _selectedUnit = null;
        _buffTarget = null;
        _attackTarget = null;
        _skill = null;
        skill_active = false;
        target_unit = false;
        buff_unit = false;
        selected_unit = false;
        --actions;
    }
    public void beginTurn()
    {
        // For each action bar check the cooldowns.
        for (int i = 0; i < actionBars.Length; ++i)
            actionBars[i].checkCoolDowns();
    }
    public void endTurn()
    {
        ++turnCounter;
        actions = 4;
    }
    public void endBattle()
    {
        SaveInformation.SaveAllInformation();
        ChangeScene.ChangeToScene("Map");
    }
    public void deadUnit(basePlayer unit) {
        playerParty.Remove(unit);
        Destroy(unit);
    }
    public void deadUnit(baseEnemy unit) {
        enemyParty.Remove(unit);
        Destroy(unit);
    }

}
