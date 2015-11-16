using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using UnityEngine.EventSystems;
//STUN DEBUFF NOT IMPLEMENTED
public class InfiniteLoop : baseSkill {
	public GameInformation gameInformation;
	
	public InfiniteLoop () {
		skillName = "Infinite Loop";
		skillDescription = "Causes opponent to become stunned for 2 turns.";
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
