using UnityEngine;
using System.Collections;

public class actionBarHandler : MonoBehaviour {

    public basePlayer unit;
    public Texture2D actionBar;
    public Rect position;
    public actionBarSlot[] skills;
    public int numOfSkills;

    public float skill_x;
    public float skill_y;
    public float skillWidth;
    public float skillHeight;
    public float skillDistance;
	// Use this for initialization
	void Start () {
        numOfSkills = 5;
        skills = new actionBarSlot[numOfSkills];
        for (int i = 0; i<skills.Length; ++i)
            skills[i] = new actionBarSlot();

        testSkills();
	}
	
	// Update is called once per frame
	void Update () {
	    updateSkills();
	}
    void OnGUI() {
        drawActionBar();
        drawSkillSlot();    
    }
    void drawActionBar() {
        GUI.DrawTexture(getScreenRect(position), actionBar);
    }
    public void drawSkillSlot()
    {
        for (int i = 0; i < skills.Length; ++i)
            GUI.DrawTexture(getScreenRect(skills[i].position),skills[i].skillImage);
    }
    
    void updateSkills() { 
        if(unit==null && BattleManager.selectedUnit !=null){
            loadActionBar(BattleManager.selectedUnit);
            unit = BattleManager.selectedUnit;
        }
        else if (unit!=null && unit != BattleManager.selectedUnit) {
            loadActionBar(BattleManager.selectedUnit);
            unit = BattleManager.selectedUnit;
        }
        for (int i = 0; i < skills.Length; ++i) {
            skills[i].position.Set(skill_x + i * (skillWidth+skillDistance),skill_y,skillWidth,skillHeight);
        }
    }

    public void loadActionBar(basePlayer unit) {
        skills[0].addSkillToSlot(unit.skill1);
        skills[1].addSkillToSlot(unit.skill2);
        skills[2].addSkillToSlot(unit.skill3);
        skills[3].addSkillToSlot(unit.skill4);
        skills[4].addSkillToSlot(unit.basicAttack);
    }
    Rect getScreenRect(Rect position)
    {
        return new Rect(Screen.width * position.x, Screen.height * position.y, Screen.width * position.width, Screen.height * position.height);
    }
    public void loadActionBar(baseSkill[] skillSet) {
        skills[0].addSkillToSlot(skillSet[0]);
        skills[1].addSkillToSlot(skillSet[1]);
        skills[2].addSkillToSlot(skillSet[2]);
        skills[3].addSkillToSlot(skillSet[3]);
        skills[4].addSkillToSlot(skillSet[4]);
    }
    public void testSkills() {
        baseSkill[] skillSet = new baseSkill[5];
        for (int i = 0; i < skillSet.Length; ++i )
            skillSet[i] = new NoSkill();
        skillSet[0] = new BreakAndContinue();
        skillSet[1] = new FireWall();
        skillSet[2] = new Hash();
        skillSet[3] = new IfElse();
        skillSet[4] = new BasicAttack();
        loadActionBar(skillSet);

    }
}
