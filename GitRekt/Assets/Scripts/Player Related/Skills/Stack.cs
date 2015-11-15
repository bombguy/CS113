using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using UnityEngine.EventSystems;
//TARGET ALL ENEMIES NOT IMPLEMENTED
public class Recursion : baseSkill {
	public GameInformation gameInformation;
	
	public Recursion () {
		skillName = "Stack";
		skillDescription = "Rapidly throws stacks of CDs (First In First Out). damaging target by " + (skillPower * 200) + "% of player's attack.";
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
