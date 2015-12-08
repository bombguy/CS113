using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour {
    skill_button[] _buttons;
    
    public bool _hasSelected;
    public baseSkill _skill;

    public void endAction() {
        for (int i = 0; i < _buttons.Length; ++i) {
            if (_buttons[i]._skill == _skill)
            {
                _buttons[i].applyCooldown();

            }
        }
        _hasSelected = false;
        _skill = null;
        hideActionBar();
    }
    public void updateCooldowns() {
        for (int i = 0; i < _buttons.Length; ++i) {
            _buttons[i].updateCooldown();
        }
    }
    
	void Awake(){
        _buttons = GetComponentsInChildren<skill_button>();
    }
    void Start() {
        testActionBar();
    }
    public void testActionBar() {
            _buttons[0].setButton(new FireWall());
            _buttons[1].setButton(new FunctionsWithOutput());
            _buttons[2].setButton(new Arrays());
            _buttons[3].setButton(new DDOS());
            _buttons[4].setButton(new BasicAttack());
    }

    public void setActionBar(basePlayer unit)
    {

        if (unit.skill1.skillName == "-") {

        }
        else{
            _buttons[0].setButton(unit.skill1);
            _buttons[1].setButton(unit.skill2);
            _buttons[2].setButton(unit.skill3);
            _buttons[3].setButton(unit.skill4);
            _buttons[4].setButton(unit.basicAttack);
        }
    }

    //Used to hide and Show the ActionBar
    public void hideActionBar() {
        for (int i = 0; i < _buttons.Length; ++i) {
            _buttons[i].hideButton();
            _buttons[i]._skillPanel.hidePanel();
        }
        GetComponent<Image>().enabled = false;
    }
    public void displayActionBar() {
        for (int i = 0; i < _buttons.Length; ++i) {
            _buttons[i].displayButton();
        }
        GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
	void Update () {
        updateSelected();
	}
    public void updateSelected() {
        for (int i = 0; i < _buttons.Length; ++i) {
            if (_buttons[i].selected)
            {
                if (_skill == null) {
                    _skill = _buttons[i]._skill;
                    _buttons[i].selected = false;
                    _hasSelected = true;    
                }
                else if (_skill == _buttons[i]._skill)
                {
                    _skill = null;
                    _buttons[i].selected = false;
                    _hasSelected = false;
                }
                else {
                    _skill = _buttons[i]._skill;
                    _buttons[i].selected = false;
                    _hasSelected = true;
                }
            }
                
        }
    }
   
}
