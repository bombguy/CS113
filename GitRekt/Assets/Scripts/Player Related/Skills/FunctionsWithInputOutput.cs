using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using UnityEngine.EventSystems;

public class FunctionsWithInputOutput : baseSkill {
	public GameInformation gameInformation;
	
	public FunctionsWithInputOutput () {
		skillName = "Functions With I/O";
		skillDescription = "Sacrafice 5% of your hp to deal damage for " + (skillPower * 300) + "% of player's attack.";
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 3;
		skillPower = 1;
	}
	
	public override void 	cast(MonoBehaviour castor, MonoBehaviour target) {
		//skill effect
		int (castor as basePlayer).currentHP -= (int)((castor as basePlayer).currentHP * 0.05)
		int (castor as basePlayer).attack += (int)((castor as basePlayer).attack * skillPower * 150);
		(target as baseEnemy).currentHP -= damage;

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
