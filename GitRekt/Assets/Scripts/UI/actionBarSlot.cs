using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class actionBarSlot {
	public baseSkill skill;
	public Texture2D skillImage;
	//private Text  skillDetail;
    public Rect position;
	// Use this for initialization
	void Start () {
	}

	public void addSkillToSlot(baseSkill input_skill) {
		skill = input_skill;
        //skillImage = Texture2D.whiteTexture; // Temp unit I fix Spell Names in Skills
        skillImage = Resources.Load<Texture2D>("Skills/"+input_skill.skillName.ToLower());
        //skillDetail.text = "Skill Name: " + skill.skillName +
          //          "\nCategory: " + skill.skillCategory +
            //        "\nEffect: " + skill.skillDescription;
    }
	

	// Update is called once per frame
	void Update () {
	}
}
