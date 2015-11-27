using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour {
    public skill_button[] skills;
    public skill_button selected_skill;
    public basePlayer current_unit;
    public bool hasSelected;
 
	void Awake(){
    
    }
    // Use this for initialization
	void Start () {
        //ToDo add unit ie each unit has its own actionBar.
        testActionBar();
	}
	
	// Update is called once per frame
	void Update () {
        updateSelected();
	}
    //Public Methods
    public void checkCoolDowns() {
        for (int i=0; i < skills.Length; ++i)
            skills[i].checkCooldown();
    }
    public void loadActionBar(basePlayer unit)
    {
        current_unit = unit;
        skills[0].addSkilltoButton(unit.skill1);
        skills[1].addSkilltoButton(unit.skill2);
        skills[2].addSkilltoButton(unit.skill3);
        skills[3].addSkilltoButton(unit.skill4);
        skills[4].addSkilltoButton(unit.basicAttack);
    }
    public void updateSelected() {
        for (int i = 0; i < skills.Length; ++i)
            if (skills[i].selected)
            {
                selected_skill.addSkilltoButton(skills[i].current_skill);
                skills[i].selected = false;
                hasSelected = true;
            }
    }
    //private
    void testActionBar() {
        baseSkill[] test_skills = new baseSkill[5];
        test_skills[0] = new Arrays();
        test_skills[1] = new Hash();
        test_skills[2] = new BreakAndContinue();
        test_skills[3] = new IfElse();
        test_skills[4] = new BasicAttack();
        for (int i = 0; i < 5; ++i)
            skills[i].addSkilltoButton(test_skills[i]);
        selected_skill.addSkilltoButton(new NoSkill());

    }
    
}
