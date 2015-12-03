﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour {
    public static basePlayer _unit;
    public static basePlayer _buffTarget;
    public static baseEnemy _attackTarget;
    public static baseSkill _skill;
   
    public static List<basePlayer> playerParty;
    public static List<baseEnemy> enemyParty;
    public static int actions;
    public static int turnCounter;

    public static bool playerPlayer;
    public static bool playerEnemy;
    //CombatStateMachine
    CombatStateMachine csm;
	void Awake () {
        playerParty = new List<basePlayer>();
        enemyParty = new List<baseEnemy>();
        csm = GetComponent<CombatStateMachine>();
	}
    void Start() {
        testBattle();
        csm.updateMachine();
    }
    void InitBattle() {
        LoadInformation.LoadAllInformation();
        turnCounter = 1;
        actions = 4;
        for(int i = 0; i<GameInformation.players.Length;++i)
            playerParty.Add(GameInformation.players[i]);
        for (int i = 0; i < GameInformation.enemies.Length; ++i)
            enemyParty.Add(GameInformation.enemies[i]);    
        GUIManager.loadGUI(playerParty.ToArray(), enemyParty.ToArray());
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

        GUIManager.loadGUI(playerParty.ToArray(), enemyParty.ToArray());
    }

	void Update () {
	}
    void LateUpdate() {
        updateBM();   
    }
    public void updateBM() {
        if (GUIManager.action) {
            if (GUIManager.attack == true) {
                _unit = GUIManager._unit;
                _skill = GUIManager._skill;
                _attackTarget = GUIManager._enemy;
                playerEnemy = true;
                csm.updateMachine();
            }
            else {
                _unit = GUIManager._unit;
                _skill = GUIManager._skill;
                _buffTarget = GUIManager._buffUnit;
                playerPlayer = true;
                csm.updateMachine();
            }
        }
    }

    public static void endAction() {
        playerEnemy = false;
        playerPlayer = false;
        actions--;
        Debug.Log("BattleManager endAction() Actions =" + actions);
        GUIManager.endAction();
        //Debug.LogError("After gui.EndAction");
    }
    public static void beginTurn()
    {
        Debug.Log("BattleManager Begin Turn :" + turnCounter);
        Debug.Log("Players Health :");
        for (int i = 0; i < playerParty.Count; ++i)
            Debug.Log(playerParty[i].name +" "+ playerParty[i].currentHP);
        Debug.Log("Enemies Health :");
        for (int i = 0; i < enemyParty.Count; ++i)
            Debug.Log(enemyParty[i].name +" "+ enemyParty[i].currentHP);
        GUIManager.beginTurn();
    }
    public static void endTurn() {
        ++turnCounter;
        actions = 4;
        Debug.Log("BattleManager End Turn :" + turnCounter);
        GUIManager.endTurn();
    }
    
    public static void endBattle()
    {
        SaveInformation.SaveAllInformation();
        ChangeScene.ChangeToScene("Map");
    }
    public static void deadUnit(basePlayer unit) {
        playerParty.Remove(unit);
        Destroy(unit);
    }
    public static void deadUnit(baseEnemy unit) {
        enemyParty.Remove(unit);
        Destroy(unit);
    }

}
