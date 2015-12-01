using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour {
    baseSkill _noSkill;
    skill_button[] _buttons;
    
    public bool _hasSelected;
    public skill_button _selectedButton;
    public baseSkill _skill;
    public basePlayer _unit;

	void Awake(){
        _buttons = GetComponentsInChildren<skill_button>();
    }
    void Start() {
        _selectedButton = _buttons[_buttons.Length - 1];
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
        _unit = unit;

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

    //Used to updateCooldowns after turns
    public void updateCooldowns()
    {
        for (int i = 0; i < _buttons.Length; ++i)
            _buttons[i].updateCooldown();
    }
    //Used to hide and Show the ActionBar
    public void hideActionBar() {
        for (int i = 0; i < _buttons.Length; ++i) {
            _buttons[i].hideButton();
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
                _skill = _buttons[i]._skill;
                _selectedButton.setButton(_buttons[i]._skill);
                _buttons[i].selected = false;
                _hasSelected = true;
            }
                
        }
    }
   
}
