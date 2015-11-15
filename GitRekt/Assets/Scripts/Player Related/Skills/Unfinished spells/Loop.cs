using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using UnityEngine.EventSystems;
//DEBUFF NOT IMPLEMENTED (CONFUSION)
public class Loop : baseSkill {
	public GameInformation gameInformation;
	
	public Loop () {
		skillName = "Loop";
		skillDescription = "Deals" + (skillPower * 200) + "% of player's attack with chance of Confusion/";
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 3;
		skillPower = 1;
	}
	
	public override void 	cast(MonoBehaviour castor, MonoBehaviour target) {
		//skill effect
		int damage = (int)((castor as basePlayer).attack * skillPower * 200);
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
