using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using UnityEngine.EventSystems;
//RANDOMLY SELECT A UNIT NOT IMPLEMENTED
//MITIGATION OF DAMAGE NOT IMPLEMENTED
public class Hash : baseSkill {
	public GameInformation gameInformation;
	
	public Hash () {
		skillName = "Hash";
		skillDescription = "Randomly selects an ally to become immune to any damage for one turn.";
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 10;
		skillPower = 1;
	}
	
	public override void 	cast(MonoBehaviour castor, MonoBehaviour target) {
		//skill effect

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
