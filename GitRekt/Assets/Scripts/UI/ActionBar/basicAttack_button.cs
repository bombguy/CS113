using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class basicAttack_button : MonoBehaviour {
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
        if (test == true)
            testButton();
    }


    // Update is called once per frame
    void Update()
    {
        //updateSkill();
    }
    //Public Functions
    //Spell Selected but possibly not one used. 
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
    //Private
    void updateSkill()
    {
        if (BattleManager.selectedUnit == null) { }
        else
        {
            if (current_skill == null)
                addSkilltoButton(BattleManager.selectedUnit.basicAttack);
            else if (current_skill != BattleManager.selectedUnit.basicAttack)
                addSkilltoButton(BattleManager.selectedUnit.basicAttack);
        }
    }
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
    void testButton() {
        baseSkill test = new BasicAttack();
        addSkilltoButton(test);
    }
}
