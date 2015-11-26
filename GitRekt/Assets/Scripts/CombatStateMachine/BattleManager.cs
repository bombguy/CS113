using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour {
   
    public   List<basePlayer> playerParty;
    public   List<baseEnemy> enemyParty;

    public   basePlayer selectedUnit;
    public   basePlayer buffTarget;
    public   baseEnemy attackTarget;
    public   baseSkill skill;
    
    public   int actions;
    public   int turnCounter;
    
    //GUI Handlers
    public  ActionBar[] actionBars;
    public  ActionBar activeBar;


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
	}
    public void checkSelectedUnit() { 
        
    }
    public void checkActiveActionBar() {
        if (activeBar.hasSelected) {
            skill = activeBar.selected_skill.current_skill;
            Debug.Log("SKILL CHOSEN:" +skill.skillName);
        }

    }
    
    public void endAction() {

        selectedUnit = null;
        buffTarget = null;
        attackTarget = null;
        skill = null;
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
