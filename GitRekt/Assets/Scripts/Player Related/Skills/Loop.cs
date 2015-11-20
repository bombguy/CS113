﻿using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

public class Loop : baseSkill {
	public GameInformation gameInformation;
	
	public Loop () {
		skillID = 13;
		skillName = "Loop";
		skillDescription = "Opponent is stuck in a  loop, dealing damage, and have a chance to become Confused.";
		hasAdditionalEffect = true;
		targetEnemy = true;
		targetPlayer = false;


		Random rnd = new Random()
		int condition = rnd.Next(0,1)
		
		if (condition == 1){
			
			//define effect
			additionalEffect = new Effect ();
			additionalEffect.status = Effect.Status.CONFUSED;
			additionalEffect.power = 0;				
			additionalEffect.duration = 3;
		}


		
		
		
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 5;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Spell/" + skillName);
	}
	
	public override int 	cast(GameObject castor, GameObject target) {
		//skill effect
		int attack = (skillLevel * 5) + 10
		//skill experience gain
		skillExperience++;
		
		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
			skillLevel++;
			(castor as basePlayer).networkMastery++;
		}
	}
	
	public Loop(SerializationInfo info, StreamingContext ctxt)
	{
		skillName = "Loop";
		skillDescription = "Opponent is stuck in a  loop, dealing damage, and have a chance to become Confused.";
		
		skillLevel = (int)info.GetValue("LOOP_SKILLEVEL",typeof(int));
		skillExperience = (int)info.GetValue("LOOP_SKILLEXPERIENCE",typeof(int));
		skillCoolDown = (int)info.GetValue("LOOP_SKILLCOOLDOWN",typeof(int));
		skillPower = (int)info.GetValue("LOOP_SKILLPOWER",typeof(int));
		
	}
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("LOOP_SKILLLEVEL", skillLevel, typeof(int));
		info.AddValue("LOOP_SKILLEXPERIENCE", skillExperience, typeof(int));
		info.AddValue("LOOP_COOLDOWN", skillCoolDown, typeof(int));
		info.AddValue("LOOP_SKILLPOWER", skillPower, typeof(int));
		
		
	}
	
}

