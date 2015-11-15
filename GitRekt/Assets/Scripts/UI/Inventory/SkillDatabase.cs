using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class SkillDatabase : MonoBehaviour {
	public List<baseSkill> skills;

	// Use this for initialization
	void Start () {
		skills = new List<baseSkill>();
		skills.Add (new BasicAttack ());
	}
	

}
