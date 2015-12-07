using UnityEngine;
using System.Collections;

public class FunctionsWithInputOutput : baseSkill {
	public GameInformation gameInformation;
	
	public FunctionsWithInputOutput () {
		skillID = 7;
		skillName = "Functions With IO";
		skillDescription = "Unit will be supplying health, to deal massive damage to opponent.";
		hasAdditionalEffect = false;
		targetEnemy = false;
		targetPlayer = true;
		
		additionalEffect = new Effect ();

		skillLevel = 1;
		skillExperience = 0;
		skillCoolDown = 4;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
	}
	
	public override int cast(basePlayer caster) {
		//skill effect
		int health = 100 / (skillLevel + 1);
        caster.currentHP -= health; // Trading health for attack.
		int attack = (skillLevel * health) + 10;

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
	
	public FunctionsWithInputOutput(string load)
	{
		skillID = 7;
		skillName = "Functions With IO";
		skillDescription = "Unit will be supplying health, to deal massive damage to opponent.";
		hasAdditionalEffect = false;
		targetEnemy = false;
		targetPlayer = true;
		
		additionalEffect = new Effect ();

		skillLevel = PlayerPrefs.GetInt("FUNCTIONSWITHINPUTOUTPUT_LEVEL",0);
		skillExperience = PlayerPrefs.GetInt("FUNCTIONSWITHINPUTOUTPUT_EXPERIENCE",0);
		skillCoolDown = PlayerPrefs.GetInt("FUNCTIONSWITHINPUTOUTPUT_COOLDOWN",0);
		skillPower = (double)PlayerPrefs.GetFloat("FUNCTIONSWITHINPUTOUTPUT_POWER",0);

		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
		
	}
	
	public override void 	saveSkill() {

		PlayerPrefs.SetInt ("FUNCTIONSWITHINPUTOUTPUT_LEVEL", skillLevel);
		PlayerPrefs.SetInt ("FUNCTIONSWITHINPUTOUTPUT_EXPERIENCE", skillExperience);
		PlayerPrefs.SetInt ("FUNCTIONSWITHINPUTOUTPUT_COOLDOWN", skillCoolDown);
		PlayerPrefs.SetFloat ("FUNCTIONSWITHINPUTOUTPUT_POWER", (float)skillPower);

		
	}
	
}
