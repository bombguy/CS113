using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour {

	public baseSkill skill;
	private Image skillImage;
	private Text  skillDetail;

	// Use this for initialization
	void Start () {
		skill = new BasicAttack();
		skillImage = gameObject.transform.GetChild (0).GetComponent<Image>();
		skillDetail = gameObject.transform.GetChild (1).GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (skill != null) {
			skillImage.enabled = true;
			skillImage.sprite = skill.skillIcon;
			skillDetail.text = "Skill Name: " + skill.skillName +
								"\nCategory: " + skill.skillCategory +
								"\nEffect: " + skill.skillDescription;
			//skillDetail.text = skill.skillName;
		} else {
			skillImage.enabled = false;
		}
	}

	public void showDetail() {
		skillDetail.enabled = true;
	}

	public void removeDetail() {
		skillDetail.enabled = false;
	}	
}
