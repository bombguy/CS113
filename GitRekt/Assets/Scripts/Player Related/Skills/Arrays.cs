using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

public class Arrays : baseSkill {
	public GameInformation gameInformation;
	
	public Arrays () {
		skillID = 2;
		skillName = "Arrays";
		skillDescription = "Wall of arrays appear in front of the unit, increasing defense for three turns";
		hasAdditionalEffect = true;
		targetEnemy = false;
		targetPlayer = true;
		
		//define effect
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.DEFENSE;
		additionalEffect.power = 0;
		additionalEffect.duration = 3;
		
		skillLevel = 1;
		skillExperience = 0;
		skillCoolDown = 1;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
	}
	
	public override int cast(basePlayer caster) {
		//skill effect
        additionalEffect.power = (caster.networkMastery * 10);
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
	
	public Arrays(SerializationInfo info, StreamingContext ctxt)
	{
		skillName = "Arrays";
		skillDescription = "Wall of arrays appear in front of the unit, increasing defense for three turns";
		
		skillLevel = (int)info.GetValue("ARRAYS_SKILLEVEL",typeof(int));
		skillExperience = (int)info.GetValue("ARRAYS_SKILLEXPERIENCE",typeof(int));
		skillCoolDown = (int)info.GetValue("ARRAYS_SKILLCOOLDOWN",typeof(int));
		skillPower = (int)info.GetValue("ARRAYS_SKILLPOWER",typeof(int));
		
	}
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("ARRAYS_SKILLLEVEL", skillLevel, typeof(int));
		info.AddValue("ARRAYS_SKILLEXPERIENCE", skillExperience, typeof(int));
		info.AddValue("ARRAYS_COOLDOWN", skillCoolDown, typeof(int));
		info.AddValue("ARRAYS_SKILLPOWER", skillPower, typeof(int));
		
		
	}
	
}

