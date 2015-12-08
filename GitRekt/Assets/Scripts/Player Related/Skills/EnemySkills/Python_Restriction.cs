using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Python_Restriction : baseSkill {
	//public GameInformation gameInformation;
	
	public Python_Restriction () {
		skillID = 1;
		skillName = "Python_Restriction";
		skillDescription = "Pushes players causing them to take massive damage";
		hasAdditionalEffect = false;
		targetEnemy = false;
		targetPlayer = true;
		
		//define effect
		additionalEffect = new Effect ();
		
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
		int attack = (int)(skillPower * 150);
		
		return attack;
		
	}
	public override int cast(baseEnemy caster)
	{
		return 0;
	}
	
	
	
	public override void 	saveSkill() {
		
		
	}
	
	
	
}

