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
    
    playerButton[] _players;
    basePlayer _currentPlayer;
    Text playerInformation;

    void Awake() {
        _players = GetComponentsInChildren<playerButton>();
        
    }
    void Start(){

    }
  
    public void setPlayerButtons(basePlayer[] players) {
        for (int i = 0; i < _players.Length; ++i) {
            _players[i].setButton(players[i]);
        }
    }
    public void endAction() {
        for (int i = 0; i < _players.Length; ++i) {
            _players[i]._playerBattleStats.updateBattlePanel();
            if (_currentPlayer == _players[i]._player) {
                _players[i]._takenAction = true;
                _players[i].endAction();
                fetchActionBar(_currentPlayer).endAction();
            }
        }
        _currentPlayer = null;
    }
    //Ends an action when _currentPlayer is a target of a buff.
    public void endAction(basePlayer caster) {
        for (int i = 0; i < _players.Length; ++i)
        {
            if (_currentPlayer == _players[i]._player) {

                _players[i]._actionBar.hideActionBar();
            }

            if (caster == _players[i]._player) {
                _players[i]._takenAction = true;
                _players[i].endAction();
                _players[i]._actionBar.endAction();
            }
            _players[i]._playerBattleStats.updateBattlePanel();
        }
        _currentPlayer = null;
    }
    
    public void beginTurn() {
        //Start of each turn update Cooldowns and enable all buttons to press.
        for (int i = 0; i < _players.Length; ++i)
        {
            if (_players[i]._player.currentHP > 0)
            {
                _players[i]._takenAction = false;
                _players[i].buttonEnable();
                _players[i]._actionBar.updateCooldowns();
                _players[i]._playerBattleStats.updateBattlePanel();
            }
        }
    }
    public int count() {
        return _players.Length;
    }

    public void enableTargetMode() {
        for (int i = 0; i < _players.Length; ++i) {
            _players[i].buttonEnable();
        }
    }
    public void disableTargetMode() {
        for (int i = 0; i < _players.Length; ++i) {
            if (_players[i]._takenAction == true)
                _players[i].buttonDisable();
            else
                _players[i].buttonEnable();
        }
    }
    public void enemyTargetMode() {
        for (int i = 0; i < _players.Length; ++i) {
            _players[i].buttonDisable();
        }
    }
    public ActionBar fetchActionBar(basePlayer unit) {
        for (int i = 0; i < _players.Length; ++i) {
            if (_players[i]._player == unit) {
                return _players[i]._actionBar;
            }
        }
        return _players[0]._actionBar;
    }
    public playerButton fetchPlayerButton(basePlayer unit) {
        for (int i = 0; i < _players.Length; ++i) {
            if (_players[i]._player == unit)
                return _players[i];
        }
        return _players[0];
    }

    
    // Late update after Update is called once per frame
    void Update() {
        updateUnit();
    }
    //Logic to displayActionBars.
    void updateUnit()
    {
        // each player Button
        for (int i = 0; i < _players.Length; ++i)
        {
            //Check if they are selected
            if (_players[i]._selected)
            {
                /*
                * Cases:
                 * -No player selected
                 * -Current player is reselected
                 * -Player different then current player selected.
                */ 
                if (_currentPlayer == null)
                {
                    _currentPlayer = _players[i]._player;
                    _players[i]._actionBar.displayActionBar();
                    _players[i]._selected = false;
                }
                else if (_currentPlayer == _players[i]._player)
                {
                    _currentPlayer = null;
                    _players[i]._actionBar._skill = null;
                    _players[i]._actionBar.hideActionBar();
                    _players[i]._selected = false;
                }
                else if (_currentPlayer != _players[i]._player)
                {
                    fetchActionBar(_currentPlayer).hideActionBar();
                    _currentPlayer = _players[i]._player;
                    _players[i]._actionBar.displayActionBar();
                    _players[i]._selected = false;
                }
                //Debug.Log("Unit chosen " + _currentPlayer);
            }
        }
    }
}