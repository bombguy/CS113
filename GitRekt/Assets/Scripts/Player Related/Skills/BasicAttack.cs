using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using UnityEngine.EventSystems;

public class BasicAttack : baseSkill {
	public GameInformation gameInformation;

	public BasicAttack () {
		skillName = "Basic Attack";
		skillDesciption = "Deals 100% of player's attack";
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 0;
		skillPower = 1;
	}

	public override int 	cast(int playerAttack) {
		return skillPower * playerAttack;
	}

	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		return;
	}

}
