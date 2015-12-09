using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Arrays : baseSkill {
	//public GameInformation gameInformation;
	
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
		additionalEffect.power = 1;
		additionalEffect.duration = 3;
		
		skillLevel = 4;
		skillExperience = 0;
		skillCoolDown = 1;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
	}
	
	public override int cast(basePlayer caster) {
		//skill effect
        additionalEffect.power = (caster.networkMastery * 10)+skillLevel;
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
	
	public Arrays(string load)
	{
		skillID = 2;
		skillName = "Arrays";
		skillDescription = "Wall of arrays appear in front of the unit, increasing defense for three turns";
		hasAdditionalEffect = true;
		targetEnemy = false;
		targetPlayer = true;

		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.DEFENSE;
		additionalEffect.power = 0;
		additionalEffect.duration = 3;

		skillLevel = PlayerPrefs.GetInt("ARRAYS_LEVEL",0);
		skillExperience = PlayerPrefs.GetInt("ARRAYS_EXPERIENCE",0);
		skillCoolDown = PlayerPrefs.GetInt("ARRAYS_COOLDOWN",0);
		skillPower = (double)PlayerPrefs.GetFloat("ARRAYS_POWER",0);

		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
		
	}
	
	public override void 	saveSkill() {

		PlayerPrefs.SetInt ("ARRAYS_LEVEL", skillLevel);
		PlayerPrefs.SetInt ("ARRAYS_EXPERIENCE", skillExperience);
		PlayerPrefs.SetInt ("ARRAYS_COOLDOWN", skillCoolDown);
		PlayerPrefs.SetFloat ("ARRAYS_POWER", (float)skillPower);

		
	}


	
}

