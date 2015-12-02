using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

public class BreakAndContinue : baseSkill {
	public GameInformation gameInformation;
	
	public BreakAndContinue () {
		skillID = 4;
		skillName = "Break and Continue";
		skillDescription = "Spends one turn to “charge up” attack, spends next turn launching attack, dealing massive damage.";
		hasAdditionalEffect = true;
		targetEnemy = true;
		targetPlayer = false;
		
		//define effect
		//Skip a turn then deal damage
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.SKIP;
		additionalEffect.power = 0;
		additionalEffect.duration = 1;
		
		
		
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 5;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Spell/" + skillName);
	}
	
	public override int 	cast(basePlayer caster) {
		//skill effect
		int attack = 50 + (skillLevel * 5);
		//skill experience gain
		skillExperience++;
		
		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
			skillLevel++;
			caster.networkMastery++;
		}
		return attack;
	}
    public override int cast(baseEnemy caster)
    {
        return 0;
    }
	
	public BreakAndContinue(SerializationInfo info, StreamingContext ctxt)
	{
		skillName = "Break and Continue";
		skillDescription = "Spends one turn to “charge up” attack, spends next turn launching attack, dealing massive damage.";
		
		skillLevel = (int)info.GetValue("BREAKANDCONTINUE_SKILLEVEL",typeof(int));
		skillExperience = (int)info.GetValue("BREAKANDCONTINUE_SKILLEXPERIENCE",typeof(int));
		skillCoolDown = (int)info.GetValue("BREAKANDCONTINUE_SKILLCOOLDOWN",typeof(int));
		skillPower = (int)info.GetValue("BREAKANDCONTINUE_SKILLPOWER",typeof(int));
		
	}
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("BREAKANDCONTINUE_SKILLLEVEL", skillLevel, typeof(int));
		info.AddValue("BREAKANDCONTINUE_SKILLEXPERIENCE", skillExperience, typeof(int));
		info.AddValue("BREAKANDCONTINUE_COOLDOWN", skillCoolDown, typeof(int));
		info.AddValue("BREAKANDCONTINUE_SKILLPOWER", skillPower, typeof(int));
		
		
	}
	
}

