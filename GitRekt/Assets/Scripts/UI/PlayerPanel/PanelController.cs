using UnityEngine;
using System.Collections;
/*
 * PanelController Responsibility:
 * Check if a unit is selected:
 *      Pass selected unit/ current_unit to GUI Manager
 * 
 *
 * 
 */
public class PanelController : MonoBehaviour {
    public playerButton[] _playerButtons;
    public playerButton _currentPlayer;
    public bool hasSelected;
	// Use this for initialization
	void Start () {
       
	}
    //Public Methods

    // Update is called once per frame
	void Update () {
        checkSelected();
	}
    void checkSelected() {
        for (int i = 0; i < _playerButtons.Length; ++i) {
            if (_playerButtons[i].selected)
            {
                _currentPlayer.addUnitToButton(_playerButtons[i]._player);
                _playerButtons[i].selected = false;
                hasSelected = true;
            }
        }
    }
}
