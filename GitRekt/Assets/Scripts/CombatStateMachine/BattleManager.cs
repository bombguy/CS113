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
        _gui = GameObject.Find("GUIManager").GetComponentInChildren<GUIManager>();
	}
    void Start() {
        testBattle();
    }
    void InitBattle() {
        LoadInformation.LoadAllInformation();
        turnCounter = 1;
        actions = 4;
        for(int i = 0; i<GameInformation.players.Length;++i)
            playerParty.Add(GameInformation.players[i]);
        for (int i = 0; i < GameInformation.enemies.Length; ++i)
            enemyParty.Add(GameInformation.enemies[i]);
        
        _gui.loadGUI(playerParty.ToArray(), enemyParty.ToArray());
    }
    void testBattle() {
        turnCounter = 1;
        actions = 4;
        basePlayer ls = gameObject.AddComponent<ls>();
        basePlayer mkdir = gameObject.AddComponent<mkdir>();
        basePlayer rmdir = gameObject.AddComponent<rmdir>();
        basePlayer sudo = gameObject.AddComponent<sudo>();
        playerParty.Add(ls);
        playerParty.Add(mkdir);
        playerParty.Add(rmdir);
        playerParty.Add(sudo);

        baseEnemy c = gameObject.AddComponent<C>();
        baseEnemy cpp = gameObject.AddComponent<Cpp>();
        baseEnemy c2= gameObject.AddComponent<C>();
        baseEnemy python= gameObject.AddComponent<Python>();
        enemyParty.Add(c);
        enemyParty.Add(cpp);
        enemyParty.Add(c2);
        enemyParty.Add(python);

        _gui.loadGUI(playerParty.ToArray(), enemyParty.ToArray());
    }

	void Update () {
        _gui.updateGUI();
        updateBM();
	}
    public void updateBM() {
        if (_gui.action) {
            _selectedUnit = _gui._unit;
            _skill = _gui._skill;
            if (_gui.attack)
            {
                _attackTarget = _gui._enemy;
                playerPlayer = true;
            }
            else
            {
                _buffTarget = _gui._buffUnit;
                playerEnemy = true;
            }
        }
    }

    public void endAction() {
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
