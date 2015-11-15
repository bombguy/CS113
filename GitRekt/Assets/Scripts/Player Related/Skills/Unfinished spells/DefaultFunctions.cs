using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using UnityEngine.EventSystems;
//DURATION OF 3 TURNS NOT IMPLEMENTED
public class DefaultFunctions : baseSkill {
	public GameInformation gameInformation;
	
	public DefaultFunctions () {
		skillName = "Default Functions";
		skillDescription = "Increases" + (skillPower * 150) + "% of player's attack for three turns.";
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 0;
		skillPower = 1;
	}
	
	public override void 	cast(MonoBehaviour castor, MonoBehaviour target) {
		//skill effect
		foreach (string name in baseEnemy) 
		int (castor as basePlayer).attack += (int)((castor as basePlayer).attack * skillPower * 150);
		
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
