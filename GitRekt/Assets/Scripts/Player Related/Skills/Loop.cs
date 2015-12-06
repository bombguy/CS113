using UnityEngine;
using System.Collections;

public class Loop : baseSkill {
	public GameInformation gameInformation;
	
	public Loop () {
		skillID = 13;
		skillName = "Loop";
		skillDescription = "Opponent is stuck in a  loop, dealing damage, and have a chance to become Confused.";
		hasAdditionalEffect = true;
		targetEnemy = true;
		targetPlayer = false;

			
		//define effect
		//Generate chance of effect
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.CONFUSED;
		additionalEffect.power = 0;				
		additionalEffect.duration = 3;

		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 5;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
	}
	
	public override int cast(basePlayer caster) {
		//skill effect
		int attack = (skillLevel * 5) + 10;
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
	
	public Loop(string load)
	{
		skillID = 13;
		skillName = "Loop";
		skillDescription = "Opponent is stuck in a  loop, dealing damage, and have a chance to become Confused.";
		hasAdditionalEffect = true;
		targetEnemy = true;
		targetPlayer = false;

			
		//define effect
		//Generate chance of effect
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.CONFUSED;
		additionalEffect.power = 0;				
		additionalEffect.duration = 3;


		skillLevel = PlayerPrefs.GetInt("LOOP_LEVEL",0);
		skillExperience = PlayerPrefs.GetInt("LOOP_EXPERIENCE",0);
		skillCoolDown = PlayerPrefs.GetInt("LOOP_COOLDOWN",0);
		skillPower = (double)PlayerPrefs.GetFloat("LOOP_POWER",0);

		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
		
	}
	
	public override void 	saveSkill() {

		PlayerPrefs.SetInt ("LOOP_LEVEL", skillLevel);
		PlayerPrefs.SetInt ("LOOP_EXPERIENCE", skillExperience);
		PlayerPrefs.SetInt ("LOOP_COOLDOWN", skillCoolDown);
		PlayerPrefs.SetFloat ("LOOP_POWER", (float)skillPower);

		
	}
	
}

