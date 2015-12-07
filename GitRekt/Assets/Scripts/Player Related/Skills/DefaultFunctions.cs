using UnityEngine;
using System.Collections;

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
	
	public DefaultFunctions(string load)
	{
		skillID = 5;
		skillName = "Default Functions";
		skillDescription = "Functions surround the unit, increasing attack for three turns.";
		hasAdditionalEffect = true;
		targetEnemy = false;
		targetPlayer = true;
		
		//define effect
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.ATTACK;
		additionalEffect.power = 0;
		additionalEffect.duration = 3;

		skillLevel = PlayerPrefs.GetInt("DEFAULTFUNCTIONS_LEVEL",0);
		skillExperience = PlayerPrefs.GetInt("DEFAULTFUNCTIONS_EXPERIENCE",0);
		skillCoolDown = PlayerPrefs.GetInt("DEFAULTFUNCTIONS_COOLDOWN",0);
		skillPower = (double)PlayerPrefs.GetFloat("DEFAULTFUNCTIONS_POWER",0);

		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
		
	}
	
	public override void 	saveSkill() {

		PlayerPrefs.SetInt ("DEFAULTFUNCTIONS_LEVEL", skillLevel);
		PlayerPrefs.SetInt ("DEFAULTFUNCTIONS_EXPERIENCE", skillExperience);
		PlayerPrefs.SetInt ("DEFAULTFUNCTIONS_COOLDOWN", skillCoolDown);
		PlayerPrefs.SetFloat ("DEFAULTFUNCTIONS_POWER", (float)skillPower);

		
	}
}

