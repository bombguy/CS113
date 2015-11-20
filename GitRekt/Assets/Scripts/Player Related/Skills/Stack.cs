using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

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
		//NO EFFECT
		
		
		
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 5;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Spell/" + skillName);
	}
	
	public override int 	cast(MonoBehaviour castor, MonoBehaviour target) {
		//skill effect
		int attack = 50 + (skillLevel * 5);
		//skill experience gain
		skillExperience++;
		
		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
			skillLevel++;
			(castor as basePlayer).networkMastery++;
		}
		return attack;
	}
	
	public Stack(SerializationInfo info, StreamingContext ctxt)
	{
		skillName = "Stack";
		skillDescription = "Unit shoots a stack of discs at the opponent, dealing damage.";
		
		skillLevel = (int)info.GetValue("STACK_SKILLEVEL",typeof(int));
		skillExperience = (int)info.GetValue("STACK_SKILLEXPERIENCE",typeof(int));
		skillCoolDown = (int)info.GetValue("STACK_SKILLCOOLDOWN",typeof(int));
		skillPower = (int)info.GetValue("STACK_SKILLPOWER",typeof(int));
		
	}
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("STACK_SKILLLEVEL", skillLevel, typeof(int));
		info.AddValue("STACK_SKILLEXPERIENCE", skillExperience, typeof(int));
		info.AddValue("STACK_COOLDOWN", skillCoolDown, typeof(int));
		info.AddValue("STACK_SKILLPOWER", skillPower, typeof(int));
		
		
	}
	
}

