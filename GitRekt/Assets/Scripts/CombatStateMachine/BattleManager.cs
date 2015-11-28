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

    public bool playerPlayer;
    public bool playerEnemy;

    //GUI Manager
    public GUIManager _gui;
	void Awake () {
        playerParty = new List<basePlayer>();
        enemyParty = new List<baseEnemy>();
        _gui = GetComponent<Canvas>().GetComponentInChildren<GUIManager>();

	}
    void InitBattle() {
        LoadInformation.LoadAllInformation();
        turnCounter = 1;
        actions = 4;
        for(int i = 0; i<GameInformation.players.Length;++i)
            playerParty.Add(GameInformation.players[i]);
        for (int i = 0; i < GameInformation.enemies.Length; ++i)
            //enemyParty.Add(GameInformation.enemies[i]);
            enemyParty.Add(new C());
        
        _gui.loadGUI(playerParty.ToArray(), enemyParty.ToArray());

    }

	void Update () {
        _gui.updateGUI();
        updateBM();
	}
    public void updateBM() {
        if (_gui.hasAction()) {
            _selectedUnit = _gui.getUnit();
            _skill = _gui.getSkill();
            if (_gui.hasAttack())
            {
                _attackTarget = _gui.getEnemy();
                playerPlayer = true;
            }
            else
            {
                _buffTarget = _gui.getBuffed();
                playerEnemy = true;
            }
        }
    }

    public void endAction() {
        _selectedUnit = null;
        _buffTarget = null;
        _attackTarget = null;
        _skill = null;
        playerEnemy = false;
        playerPlayer = false;
        --actions;
        _gui.endAction();
    }
    public void beginTurn()
    {
        ++turnCounter;
        actions = 4;
        _gui.beginTurn();
    }
    public void endTurn() {
        _gui.endTurn();
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
