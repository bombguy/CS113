﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BattlePanel : MonoBehaviour {
    Image background;
    Text battleStats;
    basePlayer _unit;
    baseEnemy _enemyUnit;
    void Awake() {
        battleStats = GetComponentInChildren<Text>();
        background = GetComponent<Image>();
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void setBattlePanel(basePlayer unit) {
        _unit = unit;
        if (unit.effected)
        {
            battleStats.text =
               _unit.name + "\n\n" +
               "HP :" + _unit.currentHP + "/" + _unit.maxHP + " Attack :" + _unit.attack + "\n" +
               "Status Effect : " + _unit.effect.ToString() + "\n" +
               "Duration :" + _unit.duration + "\n" +
               "Network Mastery: " + _unit.networkMastery;
        }
        else
            battleStats.text =
                _unit.name + "\n\n" +
                "HP :" + _unit.currentHP + "/" + _unit.maxHP + " Attack :" + _unit.attack + "\n" +
                "Status Effect : " + _unit.effect.ToString() + "\n" +
                "Network Mastery :" + _unit.networkMastery;
    }
    public void setBattlePanel(baseEnemy unit) {
        _enemyUnit = unit;
        if (_enemyUnit.effected)
            battleStats.text =
                _enemyUnit.name + "\n\n" +
                "HP :" + _enemyUnit.currentHP + "/" + _enemyUnit.maxHP + "\n" +
                "Status Effect : " + _enemyUnit.effect.ToString() + "\n"+
                "Duration: "+_enemyUnit.duration;
        else
            battleStats.text =
                _enemyUnit.name + "\n\n" +
                "HP :" + _enemyUnit.currentHP + "/" + _enemyUnit.maxHP + "\n" +
                "Status Effect : " + _enemyUnit.effect.ToString() + "\n";
    }
    public void updateBattlePanel() {
        if (_unit != null)
        {
            if (_unit.effected)
            {
                battleStats.text =
                   _unit.name + "\n \n" +
                   "HP :" + _unit.currentHP + "/" + _unit.maxHP + "\n" +
                   "Attack :" + _unit.attack + "\n" +
                   "Defense :" + _unit.defense + "\n" +
                   "Status Effect : " + _unit.effect.ToString() + "\n" +
                   "Duration :" + _unit.duration + "\n";
            }
            else
                battleStats.text =
                    _unit.name + "\n\n" +
                   "HP :" + _unit.currentHP + "/" + _unit.maxHP + "\n" +
                   "Attack :" + _unit.attack + "\n" +
                   "Defense :" + _unit.defense + "\n" +
                    "Status Effect : " + _unit.effect.ToString() + "\n";
        }
        else {
            if (_enemyUnit.effected)
                battleStats.text =
                    _enemyUnit.name + "\n" +
                    "HP :" + _enemyUnit.currentHP + "/" + _enemyUnit.maxHP + "\n" +
                    "Status Effect : " + _enemyUnit.effect.ToString() + "\n" +
                    "Duration: " + _enemyUnit.duration;
            else
                battleStats.text =
                    _enemyUnit.name + "\n \n" +
                    "HP :" + _enemyUnit.currentHP + "/" + _enemyUnit.maxHP + "\n" +
                    "Status Effect : " + _enemyUnit.effect.ToString() + "\n";
        }

    }
    public void hidePanel() {
        background.enabled = false;
        battleStats.enabled = false;
    }
    public void showPanel() {
        background.enabled = true;
        battleStats.enabled = true;
    }
}
