﻿using UnityEngine;
using System.Collections;
/*
 * PanelController Responsibility:
 * Load in the Players
 * Pass whatever button is pressed.
 */
public class PanelController : MonoBehaviour
{
    playerButton[] _playerButtons;
    
    //public basePlayer[] _players;
    
    public basePlayer _currentPlayer;
    public baseSkill _currentSkill;

    public bool hasSelected;
    public bool targetMode;
    void Awake() {
        _playerButtons = GetComponentsInChildren<playerButton>();
    }
    void Start(){
        hasSelected = false;
        targetMode = false;
    }
    public void setPlayerButtons(basePlayer[] players) {
        for (int i = 0; i < _playerButtons.Length; ++i) {
            _playerButtons[i].setButton(players[i]);
        }
    }
    public void endAction() {
        // Put skill on cooldown, disable player Button
        playerButton _current = fetchPlayerButton(_currentPlayer);
        _current._actionBar.applyCoolDown(); // Apply CoolDown
        _current.buttonDisable();
        _current.hideActionBar();
        
    }
    public void endTurn() {
        hasSelected = false;
        targetMode = false;
        //might have to set basePlayer and baseSkill back to null here.
    }
    public void beginTurn() {
        //Start of each turn update Cooldowns and enable all buttons to press.
        for (int i = 0; i < _playerButtons.Length; ++i)
        {
            _playerButtons[i].buttonEnable();
            _playerButtons[i]._actionBar.updateCooldowns();
        }


    }
    public int count() {
        return _playerButtons.Length;
    }
    public ActionBar fetchActionBar(basePlayer unit) {
        for (int i = 0; i < _playerButtons.Length; ++i) {
            if (_playerButtons[i]._player == unit) {
                return _playerButtons[i]._actionBar;
            }
        }
        return _playerButtons[0]._actionBar;
    }
    public playerButton fetchPlayerButton(basePlayer unit) {
        for (int i = 0; i < _playerButtons.Length; ++i) {
            if (_playerButtons[i]._player == unit)
                return _playerButtons[i];
        }
        return _playerButtons[0];
    }
    // Update is called once per frame
    void Update()
    {
        updateUnit();
        updateSkill();
        //updateDebug();
    }
    void updateDebug() {
        if (_currentPlayer != null)
            Debug.Log("Current Player:" + _currentPlayer);
        if (_currentPlayer != null)
            Debug.Log("Current Skill :" + _currentSkill);   
    }
    //Logic to update skill choice by actionbar. 
    void updateSkill() {
        ActionBar toUpdate = fetchActionBar(_currentPlayer);
        if (toUpdate != null) {
            if (toUpdate._hasSelected) {
                _currentSkill = toUpdate._skill;
                toUpdate._hasSelected = false;
                hasSelected = true;
                targetMode = true;
            }
        }
    }
    //Logic to displayActionBars and capture user input.
    void updateUnit()
    {
        // each player Button
        for (int i = 0; i < _playerButtons.Length; ++i)
        {
            //Check if they are selected
            if (_playerButtons[i].selected)
            {
                // Check if we attempting to target a player
                if (targetMode == false)
                {
                    // If not. Then we are selecting a unit to take action
                    if (_currentPlayer == null)
                    {
                        _currentPlayer = _playerButtons[i]._player;
                        _playerButtons[i].showActionBar();
                        _playerButtons[i].selected = false;
                        _currentSkill = null;
                    }
                    else if (_currentPlayer == _playerButtons[i]._player)
                    {
                        _currentPlayer = null;
                        _playerButtons[i].hideActionBar();
                        _playerButtons[i].selected = false;
                        hasSelected = false;
                        _currentSkill = null;
                    }
                    else
                    {
                        fetchActionBar(_currentPlayer).hideActionBar();
                        _currentPlayer = _playerButtons[i]._player;
                        _playerButtons[i].showActionBar();
                        _playerButtons[i].selected = false;
                        hasSelected = true;
                        _currentSkill = null;
                    }
                }
                //Target Mode on. Meaning were attempting to target a player.
                else {
                    _currentPlayer = _playerButtons[i]._player;
                    hasSelected = true;
                }
            }
        }
    }
}