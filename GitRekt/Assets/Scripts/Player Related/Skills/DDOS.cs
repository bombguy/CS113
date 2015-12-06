using UnityEngine;
using System.Collections;

public class DDOS : baseSkill {
	public GameInformation gameInformation;
	
	public DDOS () {
		skillID = 4;
		skillName = "DDOS";
		skillDescription = "Target's computer crashes causing them to panic, resulting in a one turn stun.";
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
	
	public override int 	cast(basePlayer caster) {
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
	
	public DDOS(string load)
	{
		skillID = 4;
		skillName = "DDOS";
		skillDescription = "Target's computer crashes causing them to panic, resulting in a one turn stun.";
		hasAdditionalEffect = true;
		targetEnemy = true;
		targetPlayer = false;
		
		//define effect
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.STUN;
		additionalEffect.power = 0;
		additionalEffect.duration = 1;
			
		 
		
		skillLevel = PlayerPrefs.GetInt("DDOS_LEVEL",0);
		skillExperience = PlayerPrefs.GetInt("DDOS_EXPERIENCE",0);
		skillCoolDown = PlayerPrefs.GetInt("DDOS_COOLDOWN",0);
		skillPower = (double)PlayerPrefs.GetFloat("DDOS_POWER",0);
		
		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
		
	}
	
	public override void 	saveSkill() {

		PlayerPrefs.SetInt ("DDOS_LEVEL", skillLevel);
		PlayerPrefs.SetInt ("DDOS_EXPERIENCE", skillExperience);
		PlayerPrefs.SetInt ("DDOS_COOLDOWN", skillCoolDown);
		PlayerPrefs.SetFloat ("DDOS_POWER", (float)skillPower);

		
	}
	
}

