﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class skill_button : MonoBehaviour {
    Button skillButton;
    Image skillImage;
    Text skillName;
    baseSkill current_skill;
    
    //cooldowns
    bool onCoolDown;
    bool test;
    int cooldown_duration;

    // Use this for initialization
    void Start()
    {
        skillImage = GetComponent<Image>();
        skillButton = GetComponent<Button>();
        skillName = GetComponentInChildren<Text>();
        cooldown_duration = 0;
        onCoolDown = !skillButton.interactable;
        test = true;
    }


    // Update is called once per frame
    void Update()
    {    }

    //Skill Selected but possibly not one used. 
    public void skillSelected()
    {
        if (test == true)
            skillUsed();
        else
            BattleManager.skill = current_skill;
    }

    public void skillUsed()
    {
        applyCooldown();    //Put Skill on Cooldown.
    }
    
    public void checkCooldown()
    {
        if (onCoolDown)
        {
            if (BattleManager.turnCounter % cooldown_duration == 0)
                clearCooldown();
        }
    }
    
    public void setSkill(baseSkill in_skill) {
        addSkilltoButton(in_skill);
    }


    //Private
    void addSkilltoButton(baseSkill in_skill)
    {
        current_skill = in_skill;
        skillImage.sprite = Resources.Load<Sprite>("Skill/" + current_skill.skillName.ToLower());
        skillName.text = in_skill.skillName;
        skillButton.image = skillImage;
        cooldown_duration = current_skill.skillCoolDown;
    }

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