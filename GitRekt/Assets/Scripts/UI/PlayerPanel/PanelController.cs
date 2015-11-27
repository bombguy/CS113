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
    public playerButton current_unit;
    public bool hasSelected;
	// Use this for initialization
	void Start () {

	}
    //Public Methods
    public void testPanel()
    {
        _playerButtons = new playerButton[5];
        _playerButtons[0].addUnitToButton(new ls());
        _playerButtons[1].addUnitToButton(new mkdir());
        _playerButtons[2].addUnitToButton(new rmdir());
        _playerButtons[3].addUnitToButton(new sudo());

    }
    // Update is called once per frame
	void Update () {
        checkSelected();
	}
    void checkSelected() {
        for (int i = 0; i < _playerButtons.Length; ++i) {
            if (_playerButtons[i].selected)
            {
                current_unit.addUnitToButton(_playerButtons[i].unit);
                _playerButtons[i].selected = false;
                hasSelected = true;
            }
        }
    }
}
