using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class skill_button : MonoBehaviour {
    Button _skillButton;
    baseSkill _skill;
    bool selected;
    //cooldowns
    bool onCoolDown;
    int cooldown_duration;

    // Use this for initialization
    void Start()
    {
        _skillButton = GetComponent<Button>();
        _skill = new NoSkill();
        cooldown_duration = 0;
        onCoolDown = false;
        selected = false;
        cooldown_duration = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    //public methods
    public void skillSelected()
    {
        selected = true;
    }
    public Button getButton() { return _skillButton; }
    public bool isSelected() { return selected; }
    public void skillUsed()
    {
        applyCooldown();    //Put Skill on Cooldown.
    }
    public void updateCooldown()
    {
        if (onCoolDown)
        {
            if (cooldown_duration == 0)
                clearCooldown();
            else
                --cooldown_duration;
        }
    }
    public void setButton(baseSkill in_skill)
    {
        _skill = in_skill;
        _skillButton.image.sprite = Resources.Load<Sprite>("Skill/" + _skill.skillName.ToLower());
        _skillButton.GetComponentInChildren<Text>().text = in_skill.skillName;
        cooldown_duration = _skill.skillCoolDown;
    }
    public void setButton(skill_button inButton) {
        this._skillButton = inButton.getButton();
        this._skill = inButton.getSkill();
        this.selected = inButton.isSelected();
        this.onCoolDown = inButton.getCoolDown();
        this.cooldown_duration = inButton.getCoolDownDuration();
    }
    public baseSkill getSkill() { return _skill; }
    public bool getCoolDown() { return onCoolDown; }
    public int getCoolDownDuration() { return cooldown_duration; }
    //private
    void applyCooldown()
    {
        onCoolDown = true;
        _skillButton.interactable = false;
    }
    void clearCooldown()
    {
        onCoolDown = false;
        _skillButton.interactable = true;
    }
}
