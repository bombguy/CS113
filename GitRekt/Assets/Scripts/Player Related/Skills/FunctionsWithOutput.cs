using UnityEngine;
using System.Collections;

public class FunctionsWithOutput : baseSkill {
	public GameInformation gameInformation;
	
	public FunctionsWithOutput () {
		skillID = 8;
		skillName = "Functions With Output";
		skillDescription = "Unit will enter code and output solutions will be sent to the opponent damaging them.";
		hasAdditionalEffect = false;
		targetEnemy = true;
		targetPlayer = false;
		
		//define effect
        additionalEffect = new Effect();
		
		skillLevel = 1;
		skillExperience = 0;
		skillCoolDown = 5;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
	}
	
	public override int cast(basePlayer caster) {
		//skill effect
		int attack = (skillLevel * 5) + 20;

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
	
	public FunctionsWithOutput(string load)
	{
		skillID = 8;
		skillName = "Functions With Output";
		skillDescription = "Unit will enter code and output solutions will be sent to the opponent damaging them.";
		hasAdditionalEffect = false;
		targetEnemy = true;
		targetPlayer = false;
		
		//define effect
        additionalEffect = new Effect();
		

		skillLevel = PlayerPrefs.GetInt("FUNCTIONSWITHOUTPUT_LEVEL",0);
		skillExperience = PlayerPrefs.GetInt("FUNCTIONSWITHOUTPUT_EXPERIENCE",0);
		skillCoolDown = PlayerPrefs.GetInt("FUNCTIONSWITHOUTPUT_COOLDOWN",0);
		skillPower = (double)PlayerPrefs.GetFloat("FUNCTIONSWITHOUTPUT_POWER",0);

		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
		
	}
	
	public override void 	saveSkill() {

		PlayerPrefs.SetInt ("FUNCTIONSWITHOUTPUT_LEVEL", skillLevel);
		PlayerPrefs.SetInt ("FUNCTIONSWITHOUTPUT_EXPERIENCE", skillExperience);
		PlayerPrefs.SetInt ("FUNCTIONSWITHOUTPUT_COOLDOWN", skillCoolDown);
		PlayerPrefs.SetFloat ("FUNCTIONSWITHOUTPUT_POWER", (float)skillPower);

		
	}
	
}
