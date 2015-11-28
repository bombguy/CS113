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
    playerButton _currentPlayer;
    bool hasSelected;
    // Use this for initialization
    void Awake() { 
        _playerButtons = GetComponentsInChildren<playerButton>();
        _currentPlayer = _playerButtons[_playerButtons.Length - 1];
    }
    void Start(){}
    

    public playerButton[] getPlayerButtons() { return _playerButtons; }
    public void setPlayerButtons(basePlayer[] players)
    {
        for (int i = 0; 0 < players.Length; ++i)
        {
            _playerButtons[i].setButton(players[i]);
        }
    }
    public basePlayer getPlayer() { return _currentPlayer.getPlayer(); }
    public void applyPlayerSelection() { 
        _currentPlayer.buttonDisable();
    }
    public void enablePlayers() {
        for (int i = 0; i < _playerButtons.Length; ++i) 
            _playerButtons[i].buttonEnable();
    }
    public void resetSelected() { hasSelected = false; }
    public bool isSelected() { return hasSelected; }

    // Update is called once per frame
    void Update()
    {
        updateSelected();
    }

    void updateSelected()
    {
        for (int i = 0; i < _playerButtons.Length; ++i)
        {
            if (_playerButtons[i].isSelected())
            {
                _currentPlayer.setButton(_playerButtons[i].getPlayer());
                _playerButtons[i].resetSelected();
                hasSelected = true;
            }
        }
    }
}