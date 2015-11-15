using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using UnityEngine.EventSystems;
//THREE TURNS NOT IMPLEMENTED
public class Arrays : baseSkill {
	public GameInformation gameInformation;
	
	public Arrays () {
		skillName = "Arrays";
		skillDescription = "Increases defense by" + (skillPower * 150) + "% of player's skillPower for three turns";
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 0;
		skillPower = 1;
	}
	
	public override void 	cast(MonoBehaviour castor, MonoBehaviour target) {
		//skill effect
		int (castor as basePlayer).defense += (int)((castor as basePlayer).defense * skillPower * 150);
		
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
