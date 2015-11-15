using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

public class FireWall : baseSkill {
	public GameInformation gameInformation;
	
	public FireWall () {
		skillName = "Fire Wall";
		skillDescription = "Increases party member's defense by " + (10 + skillLevel * 5);
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 3;
		skillPower = 0;
	}
	
	public override void 	cast(GameObject castor, GameObject target) {
		//skill effect
		int effect = 10 + (skillLevel * 5);
		(target as basePlayer).defense += effect;

		//skill experience gain
		skillExperience++;
		
		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
			skillLevel++;
			(castor as basePlayer).networkMastery++;
		}
	}
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		return;
	}
	
}
