using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class skill1_button : MonoBehaviour {
    Button skillButton;
    Image skillImage;
    baseSkill skill;
	// Use this for initialization
	void Start () {
        skillImage = GetComponent<Image>();
        skillButton = GetComponent<Button>();
	}

	// Update is called once per frame
	void Update () {
	
	}

    void addSkilltoButton(baseSkill in_skill) {
        skill = in_skill;
        skillImage.sprite = Resources.Load<Sprite>("Skills/" + skill.skillName.ToLower());
    }
}

