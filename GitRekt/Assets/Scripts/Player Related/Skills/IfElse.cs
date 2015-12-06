using UnityEngine;
using System.Collections;

public class IfElse : baseSkill {
	public GameInformation gameInformation;
	
	public IfElse () {
		skillID = 11;
		skillName = "If Else";
		skillDescription = "All or Nothing, Doubles the attack or nothing at all.";
		hasAdditionalEffect = false;
		targetEnemy = true;
		targetPlayer = false;
		
		//define effect
		additionalEffect = new Effect ();

		
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 3;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
	}
	
	public override int cast(basePlayer caster) {
		//skill effect
		int attack = (10 + (skillLevel * 5)) * 2;
        if (Random.Range(0, 1) != 0)
            attack = 0;
		
		//skill experience gain
		++skillExperience;
		
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
	public IfElse(string load)
	{
		skillID = 11;
		skillName = "If Else";
		skillDescription = "All or Nothing, Doubles the attack or nothing at all.";
		hasAdditionalEffect = false;
		targetEnemy = true;
		targetPlayer = false;
		
		//define effect
		additionalEffect = new Effect ();

		skillLevel = PlayerPrefs.GetInt("IFELSE_LEVEL",0);
		skillExperience = PlayerPrefs.GetInt("IFELSE_EXPERIENCE",0);
		skillCoolDown = PlayerPrefs.GetInt("IFELSE_COOLDOWN",0);
		skillPower = (double)PlayerPrefs.GetFloat("IFELSE_POWER",0);

		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
		
	}
	
	public override void 	saveSkill() {

		PlayerPrefs.SetInt ("IFELSE_LEVEL", skillLevel);
		PlayerPrefs.SetInt ("IFELSE_EXPERIENCE", skillExperience);
		PlayerPrefs.SetInt ("IFELSE_COOLDOWN", skillCoolDown);
		PlayerPrefs.SetFloat ("IFELSE_POWER", (float)skillPower);

		
	}	
}
