using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Cpp_Submerge : baseSkill {
	//public GameInformation gameInformation;
	
	public Cpp_Submerge () {
		skillID = 1;
		skillName = "Cpp_Submerge";
		skillDescription = "Single target damage that drowns a unit with semicolons with chance of poison";
		hasAdditionalEffect = true;
		targetEnemy = false;
		targetPlayer = true;
		
		//define effect
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.DOT;
		additionalEffect.duration = 3;
		additionalEffect.power = 10;
		
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 1;
		skillPower = 1;
		
		skillIcon = null;
		//skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
	}
	
	public override int cast(basePlayer caster) {
		//skill effect
		
		//skill experience gain
		//		skillExperience++;
		
		//if skill experience hits 10, skill/category level up
		//		if (skillExperience % 10 == 0) {
		//			skillLevel++;
		//			caster.networkMastery++;
		//		}
		int attack = (int)(skillPower * 100);
		
		return attack;
		
	}
	public override int cast(baseEnemy caster)
	{
		return 0;
	}
	
	
	
	public override void 	saveSkill() {
		
		
	}
	
	
	
}

