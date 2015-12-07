using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*
 * PanelController Responsibility:
 * Load in the Players
 * Pass whatever button is pressed.
 */
public class PanelController : MonoBehaviour
{
    bool[] _interactableStates; // Use parallel arrays to set interactable states for player/player targeting
    playerButton[] _playerButtons;
    basePlayer _currentPlayer;
    Text playerInformation;

    void Awake() {
        _playerButtons = GetComponentsInChildren<playerButton>();
    }
    void Start(){

    }
    public void setPlayerButtons(basePlayer[] players) {
        for (int i = 0; i < _playerButtons.Length; ++i) {
            _playerButtons[i].setButton(players[i]);
        }
    }
    public void endAction() {
        fetchActionBar(_currentPlayer).endAction();
        fetchPlayerButton(_currentPlayer).buttonDisable();
        _currentPlayer = null;
        for (int i = 0; i < _playerButtons.Length; ++i) {
            _playerButtons[i]._playerBattleStats.updateBattlePanel();
        }
    }
    //Ends an action when _currentPlayer is a target of a buff.
    public void endAction(basePlayer unit) {
        fetchActionBar(unit).endAction();
        fetchPlayerButton(unit).buttonDisable();
        fetchActionBar(_currentPlayer).hideActionBar();
        _currentPlayer = null;
        for (int i = 0; i < _playerButtons.Length; ++i)
        {
            _playerButtons[i]._playerBattleStats.updateBattlePanel();
        }
    }
    public void Targeting() { 
        
    }
    public void beginTurn() {
        //Start of each turn update Cooldowns and enable all buttons to press.
        for (int i = 0; i < _playerButtons.Length; ++i)
        {
            if (_playerButtons[i]._player.currentHP > 0)
            {
                _playerButtons[i].buttonEnable();
                _interactableStates[i] = true;
                _playerButtons[i]._actionBar.updateCooldowns();
                _playerButtons[i]._playerBattleStats.updateBattlePanel();
            }
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

    
    // Late update after Update is called once per frame
    void Update() {
        updateUnit();
    }
    //Logic to displayActionBars.
    void updateUnit()
    {
        // each player Button
        for (int i = 0; i < _playerButtons.Length; ++i)
        {
            //Check if they are selected
            if (_playerButtons[i]._selected)
            {
                /*
                * Cases:
                 * -No player selected
                 * -Current player is reselected
                 * -Player different then current player selected.
                */ 
                if (_currentPlayer == null)
                {
                    _currentPlayer = _playerButtons[i]._player;
                    _playerButtons[i]._actionBar.displayActionBar();
                    _playerButtons[i]._selected = false;
                }
                else if (_currentPlayer == _playerButtons[i]._player)
                {
                    _currentPlayer = null;
                    _playerButtons[i]._actionBar._skill = null;
                    _playerButtons[i]._actionBar.hideActionBar();
                    _playerButtons[i]._selected = false;
                }
                else if (_currentPlayer != _playerButtons[i]._player)
                {
                    fetchActionBar(_currentPlayer).hideActionBar();
                    _currentPlayer = _playerButtons[i]._player;
                    _playerButtons[i]._actionBar.displayActionBar();
                    _playerButtons[i]._selected = false;
                }
                //Debug.Log("Unit chosen " + _currentPlayer);
            }
        }
    }
}