using UnityEngine;
using System.Collections;

public class Hash : baseSkill {
	public GameInformation gameInformation;
	
	public Hash () {
		skillID = 10;
		skillName = "Hash";
		skillDescription = "Guaranteed to block an attack.";
		hasAdditionalEffect = true;
		targetEnemy = false;
		targetPlayer = true;
		
		//define effect
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.GOD;
		additionalEffect.power = 0;
		additionalEffect.duration = 1;
		
		
		
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 10;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
	}
	
	public override int cast(basePlayer caster) {
		//skill effect
		
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
	
	public Hash(string load)
	{
		skillID = 10;
		skillName = "Hash";
		skillDescription = "Guaranteed to block an attack.";
		hasAdditionalEffect = true;
		targetEnemy = false;
		targetPlayer = true;
		
		//define effect
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.GOD;
		additionalEffect.power = 0;
		additionalEffect.duration = 1;

		skillLevel = PlayerPrefs.GetInt("HASH_LEVEL",0);
		skillExperience = PlayerPrefs.GetInt("HASH_EXPERIENCE",0);
		skillCoolDown = PlayerPrefs.GetInt("HASH_COOLDOWN",0);
		skillPower = (double)PlayerPrefs.GetFloat("HASH_POWER",0);

		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
		
	}
	
	public override void 	saveSkill() {

		PlayerPrefs.SetInt ("HASH_LEVEL", skillLevel);
		PlayerPrefs.SetInt ("HASH_EXPERIENCE", skillExperience);
		PlayerPrefs.SetInt ("HASH_COOLDOWN", skillCoolDown);
		PlayerPrefs.SetFloat ("HASH_POWER", (float)skillPower);

		
	}
	
}

