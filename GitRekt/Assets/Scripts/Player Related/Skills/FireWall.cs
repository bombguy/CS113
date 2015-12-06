using UnityEngine;
using System.Collections;

public class FireWall : baseSkill {
	public GameInformation gameInformation;
	
	public FireWall () {
		skillID = 6;
		skillName = "Fire Wall";
		skillDescription = "Builds a firewall in front of target, increasing defense for three turns.";
		hasAdditionalEffect = true;
		targetEnemy = false;
		targetPlayer = true;
		
		//define effect
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.DEFENSE;
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
		int defense = (skillLevel * 5) + 10;

		//skill experience gain
		skillExperience++;
		
		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
			skillLevel++;
			caster.networkMastery++;
		}
		return defense;
	}
    public override int cast(baseEnemy caster)
    {
        return 0;
    }
	
	public FireWall(string load)
	{
		skillID = 6;
		skillName = "Fire Wall";
		skillDescription = "Builds a firewall in front of target, increasing defense for three turns.";
		hasAdditionalEffect = true;
		targetEnemy = false;
		targetPlayer = true;
		
		//define effect
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.DEFENSE;
		additionalEffect.power = 0;
		additionalEffect.duration = 1;
		
		
		skillLevel = PlayerPrefs.GetInt("FIREWALL_LEVEL",0);
		skillExperience = PlayerPrefs.GetInt("FIREWALL_EXPERIENCE",0);
		skillCoolDown = PlayerPrefs.GetInt("FIREWALL_COOLDOWN",0);
		skillPower = (double)PlayerPrefs.GetFloat("FIREWALL_POWER",0);

		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
		
	}
	
	public override void 	saveSkill() {

		PlayerPrefs.SetInt ("FIREWALL_LEVEL", skillLevel);
		PlayerPrefs.SetInt ("FIREWALL_EXPERIENCE", skillExperience);
		PlayerPrefs.SetInt ("FIREWALL_COOLDOWN", skillCoolDown);
		PlayerPrefs.SetFloat ("FIREWALL_POWER", (float)skillPower);

		
	}
	
}

