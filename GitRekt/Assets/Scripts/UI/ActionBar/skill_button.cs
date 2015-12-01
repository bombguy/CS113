using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class skill_button : MonoBehaviour {
    Button _skillButton;
    Image _skillImage;
    Text _skillName;
    Text _skillDescription;

    bool onCoolDown;
    int cooldown_duration;

    public baseSkill _skill;
    public bool selected;


    void Awake() {
        _skillButton = GetComponent<Button>();
        _skillImage = GetComponent<Image>();
        _skillName = _skillButton.GetComponentsInChildren<Text>()[0];
        _skillDescription = _skillButton.GetComponentsInChildren<Text>()[1];
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
        _skillButton.GetComponentsInChildren<Text>()[1].enabled = true;        
    }
    public void onPointerExit() {
        _skillButton.GetComponentsInChildren<Text>()[1].enabled = false;     
    }
    //public methods
    public void skillSelected()
    {
        selected = true;
    }
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
        _skillName.text = in_skill.skillName;
        _skillDescription.text = in_skill.skillDescription;
        _skillButton.GetComponentsInChildren<Text>()[1].enabled = false;
        cooldown_duration = _skill.skillCoolDown;
    }
    public void hideButton() {
        _skillButton.enabled = false;
        _skillImage.enabled = false;
        _skillName.enabled = false;
        _skillDescription.enabled = false;
    }
    public void displayButton() {
        _skillButton.enabled = true;
        _skillImage.enabled = true;
        _skillName.enabled = true;
    }
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
