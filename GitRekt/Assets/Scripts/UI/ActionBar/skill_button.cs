using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class skill_button : MonoBehaviour {
    Button skillButton;
    Image skillImage;
    Text skillName;
    public baseSkill current_skill;
    public bool selected;
    //cooldowns
    bool onCoolDown;
    int cooldown_duration;

    // Use this for initialization
    void Start()
    {
        skillImage = GetComponent<Image>();
        skillButton = GetComponent<Button>();
        skillName = GetComponentInChildren<Text>();
        cooldown_duration = 0;
        onCoolDown = !skillButton.interactable;
        selected = false;
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

    public void skillUsed()
    {
        applyCooldown();    //Put Skill on Cooldown.
    }
    
    public void checkCooldown()
    {
        if (onCoolDown)
        {
            if (cooldown_duration == 0)
                clearCooldown();
            else
                --cooldown_duration;
        }
    }
    public void addSkilltoButton(baseSkill in_skill)
    {
        current_skill = in_skill;
        skillImage.sprite = Resources.Load<Sprite>("Skill/" + current_skill.skillName.ToLower());
        skillName.text = in_skill.skillName;
        skillButton.image = skillImage;
        cooldown_duration = current_skill.skillCoolDown;
    }

    //private
    void applyCooldown()
    {
        onCoolDown = true;
        skillButton.interactable = false;
    }
    void clearCooldown()
    {
        onCoolDown = false;
        skillButton.interactable = true;
    }
}
