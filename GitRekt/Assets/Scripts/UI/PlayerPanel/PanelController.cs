using UnityEngine;
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
    public bool skillSelected;
    
    void Awake() {
        _playerButtons = GetComponentsInChildren<playerButton>();
    }
    void Start(){
        skillSelected = true;
        hasSelected = false;
    }
    public void setPlayerButtons(basePlayer[] players) {
        for (int i = 0; i < _playerButtons.Length; ++i) {
            _playerButtons[i].setButton(players[i]);
        }
    }
    public void disablePlayer() { 
        //_currentPlayerButton.buttonDisable();
    }
    public void enablePlayers() {
        for (int i = 0; i < _playerButtons.Length; ++i) 
            _playerButtons[i].buttonEnable();
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
    // Update is called once per frame
    void Update()
    {
        updateUnit();
        updateSkill();
        updateDebug();
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
                skillSelected = true;
            }
        }
    }
    //Logic to displayActionBars and capture user input.
    void updateUnit()
    {
        for (int i = 0; i < _playerButtons.Length; ++i)
        {
            if (_playerButtons[i].selected)
            {
                if (_currentPlayer == null)
                {
                    _currentPlayer = _playerButtons[i]._player;
                    _playerButtons[i].showActionBar();
                    _playerButtons[i].selected = false;
                    hasSelected = true;
                    _currentSkill = null;
                }
                else if (_currentPlayer == _playerButtons[i]._player) {
                    _currentPlayer = null;
                    _playerButtons[i].hideActionBar();
                    _playerButtons[i].selected = false;
                    hasSelected = false;
                    _currentSkill = null;
                    skillSelected = false;
                }
                else if (_currentPlayer != _playerButtons[i]._player) {
                    fetchActionBar(_currentPlayer).hideActionBar();
                    _currentPlayer = _playerButtons[i]._player;
                    _playerButtons[i].showActionBar();
                    _playerButtons[i].selected = false;
                    hasSelected = true;
                    _currentSkill = null;
                    skillSelected = false;
                }
            }
        }
    }
}