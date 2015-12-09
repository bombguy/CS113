using UnityEngine;
using System.Collections;


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
		additionalEffect.power = 1;
		additionalEffect.duration = 1;
		
		skillLevel = 1;
		skillExperience = 0;
		skillCoolDown = 5;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
	}
	
	public override int 	cast(basePlayer caster) {
		//skill effect
		int attack = 50 + (caster.networkMastery * 5);
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
	
	public BreakAndContinue(string load)
	{
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
		
		
		
		skillLevel = PlayerPrefs.GetInt("BREAKANDCONTINUE_LEVEL",0);
		skillExperience = PlayerPrefs.GetInt("BREAKANDCONTINUE_EXPERIENCE",0);
		skillCoolDown = PlayerPrefs.GetInt("BREAKANDCONTINUE_COOLDOWN",0);
		skillPower = (double)PlayerPrefs.GetFloat("BREAKANDCONTINUE_POWER",0);

		
		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
		
	}
	
	public override void 	saveSkill() {

		PlayerPrefs.SetInt ("BREAKANDCONTINUE_LEVEL", skillLevel);
		PlayerPrefs.SetInt ("BREAKANDCONTINUE_EXPERIENCE", skillExperience);
		PlayerPrefs.SetInt ("BREAKANDCONTINUE_COOLDOWN", skillCoolDown);
		PlayerPrefs.SetFloat ("BREAKANDCONTINUE_POWER", (float)skillPower);

		
	}
	
}

