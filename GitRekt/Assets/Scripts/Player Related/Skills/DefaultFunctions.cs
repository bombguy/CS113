using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

public class DefaultFunctions : baseSkill {
	public GameInformation gameInformation;
	
	public DefaultFunctions () {
		skillID = 5;
		skillName = "Default Functions";
		skillDescription = "Functions surround the unit, increasing attack for three turns.";
		hasAdditionalEffect = true;
		targetEnemy = false;
		targetPlayer = true;
		
		//define effect
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.ATTACK;
		additionalEffect.power = 1;
		additionalEffect.duration = 3;
        
		skillLevel = 1;
		skillExperience = 0;
		skillCoolDown = 1;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
	}
	
	public override int cast(basePlayer caster) {
		//skill effect
		additionalEffect.power = (skillLevel * 5) + 10;
        
		//skill experience gain
		skillExperience++;
		
		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
			skillLevel++;
			caster.networkMastery++;

		}
		return 0;
	}
    public override int cast(baseEnemy caster)
    {
        return 0;
    }
	
	public DefaultFunctions(SerializationInfo info, StreamingContext ctxt)
	{
		skillName = "Default Functions";
		skillDescription = "Functions surround the unit, increasing attack for three turns.";
		
		skillLevel = (int)info.GetValue("DEFAULTFUCNTIONS_SKILLEVEL",typeof(int));
		skillExperience = (int)info.GetValue("DEFAULTFUCNTIONS_SKILLEXPERIENCE",typeof(int));
		skillCoolDown = (int)info.GetValue("DEFAULTFUCNTIONS_SKILLCOOLDOWN",typeof(int));
		skillPower = (int)info.GetValue("DEFAULTFUCNTIONS_SKILLPOWER",typeof(int));
		
	}
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("DEFAULTFUCNTIONS_SKILLLEVEL", skillLevel, typeof(int));
		info.AddValue("DEFAULTFUCNTIONS_SKILLEXPERIENCE", skillExperience, typeof(int));
		info.AddValue("DEFAULTFUCNTIONS_COOLDOWN", skillCoolDown, typeof(int));
		info.AddValue("DEFAULTFUCNTIONS_SKILLPOWER", skillPower, typeof(int));
		
		
	}
	
}

