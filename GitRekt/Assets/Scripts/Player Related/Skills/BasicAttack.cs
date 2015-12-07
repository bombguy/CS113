using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using UnityEngine.EventSystems;


public class BasicAttack : baseSkill {
	public GameInformation gameInformation;
	
	public BasicAttack () {
		skillID = 1;
		skillName = "Basic Attack";
		skillLevel = 1;
		skillExperience = 1;
		skillCoolDown = 0;
		skillPower = 1;
		skillCategory = SkillCategory.NONE;
		skillDescription = "Deals " + (skillPower * 100) + "% of player's attack";
		//skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
        targetEnemy = true;
        targetPlayer = true;
	}

	public override int cast(basePlayer caster) {
		//skill effect
		int damage = (int)(caster.attack * skillPower);

		//skill coolddown here
		
		//skill experience gain
		skillExperience++;
		
		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
            skillLevel++;
			skillPower += .05;
		}
		return damage;
	}
    public override int cast(baseEnemy caster)
    {
        return caster.attack;
    }
	public override void 	saveSkill() {
		return;
	}

}
