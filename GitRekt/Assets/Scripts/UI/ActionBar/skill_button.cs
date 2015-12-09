using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class skill_button : MonoBehaviour {
    public Button _skillButton;
    public Image _skillImage;
    public skillPanel _skillPanel;
    public baseSkill _skill;

    public bool onCoolDown;
    public int cooldown_duration;

    public bool selected;


    void Awake() {
        _skillButton = GetComponent<Button>();
        _skillImage = GetComponent<Image>();
        _skillPanel = GetComponentInChildren<skillPanel>();
    }
    // Use this for initialization
    void Start()
    {
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
    public void onPointerEnter() {
        _skillPanel.showPanel();
    }
    public void onPointerExit() {
        _skillPanel.hidePanel();
    }
    //public methods
    public void skillSelected()
    {
        selected = true;
        GUIManager.updateSkill(_skill);
    }
    //Cooldown System
    public void applyCooldown()
    {
        onCoolDown = true;
        _skillButton.interactable = false;
    }
    public void clearCooldown()
    {
        onCoolDown = false;
        _skillButton.interactable = true;
    }
    public void updateCooldown()
    {
        if (onCoolDown)
        {
            //Mod math forces us to add 1 to the cooldown_duration. ie. cooldown = 1; n%1 = 0. 
            if (BattleManager.turnCounter % (cooldown_duration + 1) == 0)
                clearCooldown();
        }
    }
    public void setButton(baseSkill in_skill)
    {
        _skill = in_skill;
        if (_skill.skillName == "Basic Attack")
            _skillButton.image.sprite = Resources.Load<Sprite>("Skill/Basic Attack");
        else
            _skillButton.image.sprite = in_skill.skillIcon;

        _skillPanel.setSkillPanel(in_skill);
        cooldown_duration = _skill.skillCoolDown;
        _skillPanel.hidePanel();
    }
    public void hideButton() {
        _skillButton.enabled = false;
        _skillImage.enabled = false;
        _skillPanel.hidePanel();
    }
    public void displayButton() {
        _skillButton.enabled = true;
        _skillImage.enabled = true;
    }
    

}
