using UnityEngine;
using System.Collections;

public class InfiniteLoop : baseSkill {
	public GameInformation gameInformation;
	
	public InfiniteLoop () {
		skillID = 12;
		skillName = "Infinite Loop";
		skillDescription = "Lines of code appears in front of target, stunning them for one turn.";
		hasAdditionalEffect = true;
		targetEnemy = true;
		targetPlayer = false;
		
		//define effect
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.STUN;
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
	
	public InfiniteLoop(string load)
	{
		skillID = 12;
		skillName = "Infinite Loop";
		skillDescription = "Lines of code appears in front of target, stunning them for one turn.";
		hasAdditionalEffect = true;
		targetEnemy = true;
		targetPlayer = false;
		
		//define effect
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.STUN;
		additionalEffect.power = 0;
		additionalEffect.duration = 1;

		skillLevel = PlayerPrefs.GetInt("INFINITELOOP_LEVEL",0);
		skillExperience = PlayerPrefs.GetInt("INFINITELOOP_EXPERIENCE",0);
		skillCoolDown = PlayerPrefs.GetInt("INFINITELOOP_COOLDOWN",0);
		skillPower = (double)PlayerPrefs.GetFloat("INFINITELOOP_POWER",0);

		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
		
	}
	
	public override void 	saveSkill() {

		PlayerPrefs.SetInt ("INFINITELOOP_LEVEL", skillLevel);
		PlayerPrefs.SetInt ("INFINITELOOP_EXPERIENCE", skillExperience);
		PlayerPrefs.SetInt ("INFINITELOOP_COOLDOWN", skillCoolDown);
		PlayerPrefs.SetFloat ("INFINITELOOP_POWER", (float)skillPower);

		
	}
	
}

