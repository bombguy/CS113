using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class skill2_button : MonoBehaviour {
    Button skillButton;
    Image skillImage;
    Text skillName;
    baseSkill current_skill;
	// Use this for initialization
	void Start () {
        skillImage = GetComponent<Image>();
        skillButton = GetComponent<Button>();
        skillName = GetComponentInChildren<Text>();
        testButton();
	}

	// Update is called once per frame
	void Update () {
        //updateSkill();
	}
    void updateSkill() {
        if (BattleManager.selectedUnit == null)
        {
        }
        else {
            if (current_skill == null)
                addSkilltoButton(BattleManager.selectedUnit.skill2);
            else if (current_skill != BattleManager.selectedUnit.skill2)
                addSkilltoButton(BattleManager.selectedUnit.skill2);
        }
    }

    void addSkilltoButton(baseSkill in_skill) {
        current_skill = in_skill;
        skillImage.sprite = Resources.Load<Sprite>("Skill/" + current_skill.skillName.ToLower());
        skillName.text = in_skill.skillName;
        skillButton.image = skillImage;
    }
    void testButton() {
        baseSkill test = new Hash();
        addSkilltoButton(test);
    }
}
