using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillScript : MonoBehaviour, IPointerClickHandler {
	public baseSkill skill;
	public GameObject TextArea;
	public string description;

	void Start() {
		this.skill = this.GetComponentInParent<SlotScript> ().skill;
		TextArea = GameObject.Find("SkillDescription");
		description = "";
	}

	public void OnPointerClick(PointerEventData eventData) {
		Debug.Log ("Skill Script onclick fired");
		description = skill.skillName + "\n"
			+ "Skill Level: " + skill.skillLevel.ToString() + "\n"
			+ "Experience: " + skill.skillExperience.ToString() + "\n"
			+ "Cooldown: " + skill.skillCoolDown.ToString() + "\n"
			+ "Description: " + skill.skillDescription + "\n";
		TextArea.GetComponent<Text> ().text = description;
	}
}
