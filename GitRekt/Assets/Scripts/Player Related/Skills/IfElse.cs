using UnityEngine;
using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using UnityEngine.EventSystems;

public class IfElse : baseSkill {
	public GameInformation gameInformation;

	public IfElse () {
		skillName = "If Else";
		skillDescription = "Flips a coin, Dealing" + (skillPower * 200) + "% of player's attack if attack lands";
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 1;
		skillPower = 1;
	}

	public override void 	cast(MonoBehaviour castor, MonoBehaviour target) {
		Random rnd = new Random ();
		int coin = rnd.Next (0, 1);
		//skill effect
		if (coin == 0) {
			None;
		else {
			int damage = (int)(((castor as basePlayer).attack * skillPower)*200);
			(target as baseEnemy).currentHP -= damage;
		}
		//skill coolddown here

		//skill experience gain
		skillExperience++;

		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
			skillLevel++;
			//(castor as basePlayer).category++;
			skillPower += .05;
		}
	}



	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		return;
	}

}