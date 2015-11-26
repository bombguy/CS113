using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour {
    public skill_button[] skills;
    public basePlayer current_unit;
	void Awake(){

    }
    // Use this for initialization
	void Start () {
        //ToDo add unit ie each unit has its own actionBar.
        testActionBar();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void checkCoolDowns() {
        for (int i=0; i < skills.Length; ++i)
            skills[i].checkCooldown();
    }
    void testActionBar() {
        baseSkill[] test_skills = new baseSkill[5];
        test_skills[0] = new Arrays();
        test_skills[1] = new Hash();
        test_skills[2] = new BreakAndContinue();
        test_skills[3] = new IfElse();
        test_skills[4] = new BasicAttack();
        for (int i = 0; i < 5; ++i)
            skills[i].setSkill(test_skills[i]);

    }
    void loadActionBar(basePlayer unit) {
        current_unit = unit;
        skills[0].setSkill(unit.skill1);
        skills[1].setSkill(unit.skill2);
        skills[2].setSkill(unit.skill3);
        skills[3].setSkill(unit.skill4);
        skills[4].setSkill(unit.basicAttack);
    }
}
