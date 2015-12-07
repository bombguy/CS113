using UnityEngine;
using System.Collections;

public class Recursion : baseSkill {
	public GameInformation gameInformation;
	
	public Recursion () {
		skillID = 15;
		skillName = "Recursion";
		skillDescription = "A giant loop surrounds opponent's side of the field, dealing damage to all opponents.";
		hasAdditionalEffect = true;
		targetEnemy = true;
		targetPlayer = false;
		
		//define effect
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.AOE;
		additionalEffect.power = 0;
		additionalEffect.duration = 1;
	
		
		
		
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 5;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
	}
	
	public override int cast(basePlayer caster) {
		//skill effect
		int attack = 25 + (skillLevel * 5);
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
	
	public Recursion(string load)
	{
		skillID = 15;
		skillName = "Recursion";
		skillDescription = "A giant loop surrounds opponent's side of the field, dealing damage to all opponents.";
		hasAdditionalEffect = true;
		targetEnemy = true;
		targetPlayer = false;
		
		//define effect
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.AOE;
		additionalEffect.power = 0;
		additionalEffect.duration = 1;

		skillLevel = PlayerPrefs.GetInt("RECURSION_LEVEL",0);
		skillExperience = PlayerPrefs.GetInt("RECURSION_EXPERIENCE",0);
		skillCoolDown = PlayerPrefs.GetInt("RECURSION_COOLDOWN",0);
		skillPower = (double)PlayerPrefs.GetFloat("RECURSION_POWER",0);

		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
		
	}
	
	public override void 	saveSkill() {

		PlayerPrefs.SetInt ("RECURSION_LEVEL", skillLevel);
		PlayerPrefs.SetInt ("RECURSION_EXPERIENCE", skillExperience);
		PlayerPrefs.SetInt ("RECURSION_COOLDOWN", skillCoolDown);
		PlayerPrefs.SetFloat ("RECURSION_POWERL",(float) skillPower);

		
	}
	
}

