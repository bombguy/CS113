using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Rwby_Taunt : baseSkill {
	//public GameInformation gameInformation;
	
	public Rwby_Taunt () {
		skillID = 1;
		skillName = "Rwby_Taunt";
		skillDescription = "Laughs are their opponent, provoking the opponent to only use their basic attack next turn";
		hasAdditionalEffect = true;
		targetEnemy = false;
		targetPlayer = true;
		
		//define effect
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.STUN;
		additionalEffect.duration = 2;
		additionalEffect.power = 0;
		
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
		int attack = (int)(skillPower * 0);
		
		return attack;
		
	}
	public override int cast(baseEnemy caster)
	{
		return 0;
	}
	
	
	
	public override void 	saveSkill() {
		
		
	}
	
	
	
}

