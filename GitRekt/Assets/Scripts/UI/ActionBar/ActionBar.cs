using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour {
    public skill_button[] skills;
	void Awake(){

    }
    // Use this for initialization
	void Start () {
        testActionBar();
	}
	
	// Update is called once per frame
	void Update () {
	
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
        skills[0].setSkill(unit.skill1);
        skills[1].setSkill(unit.skill2);
        skills[2].setSkill(unit.skill3);
        skills[3].setSkill(unit.skill4);
        skills[4].setSkill(unit.basicAttack);
    }
}
