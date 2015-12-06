using UnityEngine;
using System.Collections;

public class Stack : baseSkill {
	public GameInformation gameInformation;
	
	public Stack () {
		skillID = 16;
		skillName = "Stack";
		skillDescription = "Unit shoots a stack of discs at the opponent, dealing damage.";
		hasAdditionalEffect = false;
		targetEnemy = true;
		targetPlayer = false;
		
		//define effect
		additionalEffect = new Effect ();

		
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 5;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
	}
	
	public override int cast(basePlayer caster) {
		//skill effect
		int attack = 50 + (skillLevel * 5);

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
	
	public Stack(string load)
	{
		skillID = 16;
		skillName = "Stack";
		skillDescription = "Unit shoots a stack of discs at the opponent, dealing damage.";
		hasAdditionalEffect = false;
		targetEnemy = true;
		targetPlayer = false;
		
		//define effect
		additionalEffect = new Effect ();

		skillLevel = PlayerPrefs.GetInt("STACK_LEVEL",0);
		skillExperience = PlayerPrefs.GetInt("STACK_EXPERIENCE",0);
		skillCoolDown = PlayerPrefs.GetInt("STACK_COOLDOWN",0);
		skillPower = (double)PlayerPrefs.GetInt("STACK_POWER",0);

		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
		
	}
	
	public override void 	saveSkill() {

		PlayerPrefs.SetInt ("STACK_LEVEL", skillLevel);
		PlayerPrefs.SetInt ("STACK_EXPERIENCE", skillExperience);
		PlayerPrefs.SetInt ("STACK_COOLDOWN", skillCoolDown);
		PlayerPrefs.SetFloat ("STACK_POWER", (float)skillPower);

		
	}
	
}