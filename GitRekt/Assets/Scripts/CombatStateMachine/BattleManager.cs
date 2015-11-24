using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour {
    public CombatStateMachine stateMachine;

    public static List<basePlayer> playerParty;
    public static List<baseEnemy> enemyParty;

    public static basePlayer selectedUnit;
    public static basePlayer healTarget;
    public static baseEnemy attackTarget;
    public static baseSkill skill;

    public static int actions;
    public static int turnCounter;	
	void Awake () {
        stateMachine = GetComponent<CombatStateMachine>();
        playerParty = new List<basePlayer>();
        InitBattle();
	}
    void InitBattle() {
        selectedUnit = null;
        healTarget = null ;
        attackTarget = null;
        skill = null;
        turnCounter = 1;
        actions = 4;

        for (int i = 0; i < GameInformation.players.Length; ++i)
            playerParty.Add(GameInformation.players[i].deepCopy());

        if (GameInformation.level == 1)
            for (int i = 0; i < GameInformation.enemies.Length; ++i)
                enemyParty.Add(new C());
        else if (GameInformation.level == 2)
            for (int i = 0; i < GameInformation.enemies.Length; ++i)
                enemyParty.Add(new Cpp());
        else if (GameInformation.level == 3)
            for (int i = 0; i < GameInformation.enemies.Length; ++i)
                enemyParty.Add(new Python());
        else if (GameInformation.level == 4)
            for (int i = 0; i < GameInformation.enemies.Length; ++i)
                enemyParty.Add(new RubyOnRails());
    }
	/*
     * Update checks every frame if our touch events are finsihed. If so
     * We go to the coroutine In either Player heal or Player Attack. 
     */
	void Update () {
        while (CombatStateMachine.CurrentState == CombatStateMachine.CombatStates.PLAYERSELECT)
        {
            if (attackTarget != null && skill != null && selectedUnit != null)
            {
                CombatStateMachine.CurrentState = CombatStateMachine.CombatStates.PLAYERENEMY;
            }
            else if (selectedUnit != null && healTarget != null && selectedUnit != null)
            {
                CombatStateMachine.CurrentState = CombatStateMachine.CombatStates.PLAYERPLAYER;
            }
        }
	}

    public static void endTurn() {
        selectedUnit = null;
        healTarget = null;
        attackTarget = null;
        skill = null;
        ++turnCounter;
        actions = 4;
        if (CombatStateMachine.CurrentState == CombatStateMachine.CombatStates.PLAYERENEMY || CombatStateMachine.CurrentState == CombatStateMachine.CombatStates.PLAYERPLAYER)
            CombatStateMachine.CurrentState = CombatStateMachine.CombatStates.ENEMY;
        else
            CombatStateMachine.CurrentState = CombatStateMachine.CombatStates.PLAYERSELECT;
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
