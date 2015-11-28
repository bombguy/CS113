using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour {
    baseSkill _noSkill;
    skill_button[] _buttons;
    skill_button _selectedButton;
    basePlayer _unit;
    bool _hasSelected;
	void Awake(){
        _buttons = GetComponentsInChildren<skill_button>();
        _selectedButton = _buttons[_buttons.Length-1];
    }
    public void setBlank() {
        _noSkill = new NoSkill();
        for (int i = 0; i < _buttons.Length; ++i)
            _buttons[i].setButton(_noSkill);
    }
    public skill_button[] getButtons(){return _buttons;}
    public skill_button getSelectedButton() { return _selectedButton; }
    public basePlayer getUnit() { return _unit; }
    public baseSkill getSkill() { return _selectedButton.getSkill(); }
    public void setActionBar(basePlayer unit)
    {
        _unit = unit;
        _buttons[0].setButton(unit.skill1);
        _buttons[1].setButton(unit.skill2);
        _buttons[2].setButton(unit.skill3);
        _buttons[3].setButton(unit.skill4);
        _buttons[4].setButton(unit.basicAttack);
    }
    public void setActionBar(ActionBar inputBar){
        _buttons = inputBar.getButtons();
        _selectedButton = inputBar.getSelectedButton();
        _unit = inputBar.getUnit();
        _hasSelected = inputBar.hasSelected();
    }
    public ActionBar getActionBar() { return this; }
    public bool hasSelected() { return _hasSelected; }
    public void resetSelected() { _hasSelected = false; }
    public void applySkillSelection() {
        _selectedButton.skillUsed();
    }

    public void updateCooldowns()
    {
        for (int i = 0; i < _buttons.Length; ++i)
            _buttons[i].updateCooldown();
    }
    // Use this for initialization
	void Start () {
        //ToDo add unit ie each unit has its own actionBar.
        _hasSelected = false;
        _noSkill = new NoSkill();
	}
	
	// Update is called once per frame
	void Update () {
        updateSelected();
	}
    public void updateSelected() {
        for (int i = 0; i < _buttons.Length; ++i) {
            if (_buttons[i].isSelected())
            {
                _selectedButton.setButton(_buttons[i].getSkill());
                _hasSelected = true;
            }
                
        }
    }
   
}
