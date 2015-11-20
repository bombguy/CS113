﻿using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

public class IfElse : baseSkill {
	public GameInformation gameInformation;
	
	public IfElse () {
		skillID = 11;
		skillName = "If Else";
		skillDescription = "All or Nothing, Doubles the attack or nothing at all.";
		hasAdditionalEffect = false;
		targetEnemy = true;
		targetPlayer = false;
		
		//define effect
		//NO EFFECT
		
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 3;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Spell/" + skillName);
	}
	
	public override int 	cast(GameObject castor, GameObject target) {
		//skill effect
		int attack = (10 + (skillLevel * 5)) * 2;
		
		//skill experience gain
		skillExperience++;
		
		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
			skillLevel++;
			(castor as basePlayer).networkMastery++;
		}
	}
	
	public IfElse(SerializationInfo info, StreamingContext ctxt)
	{
		skillName = "If Else";
		skillDescription = "All or Nothing, Doubles the attack or nothing at all.";
		
		skillLevel = (int)info.GetValue("IFELSE_SKILLEVEL",typeof(int));
		skillExperience = (int)info.GetValue("IFELSE_SKILLEXPERIENCE",typeof(int));
		skillCoolDown = (int)info.GetValue("IFELSE_SKILLCOOLDOWN",typeof(int));
		skillPower = (int)info.GetValue("IFELSE_SKILLPOWER",typeof(int));
		
	}
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("IFELSE_SKILLLEVEL", skillLevel, typeof(int));
		info.AddValue("IFELSE_SKILLEXPERIENCE", skillExperience, typeof(int));
		info.AddValue("IFELSE_COOLDOWN", skillCoolDown, typeof(int));
		info.AddValue("IFELSE_SKILLPOWER", skillPower, typeof(int));
		
		
	}
	
}

