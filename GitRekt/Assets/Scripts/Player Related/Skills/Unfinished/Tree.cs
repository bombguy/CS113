﻿using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

public class Tree : baseSkill {
	public GameInformation gameInformation;
	
	public Tree () {
		skillID = 17;
		skillName = "Tree";
		skillDescription = "Branches comes out and damages all opponents, where each opponent is a node and deals more damage with more nodes.";
		hasAdditionalEffect = false;
		targetEnemy = true;
		targetPlayer = false;
		
		//define effect
		//target all opponents
		//Power is multiplied by number of opponents
		
		
		
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 5;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Spell/" + skillName);
	}
	
	public override int 	cast(GameObject castor, GameObject target) {
		//skill effect
		// int attack = (5*skillLevel) + 10) * numberofnodes

		//skill experience gain
		skillExperience++;
		
		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
			skillLevel++;
			(castor as basePlayer).networkMastery++;
		}
	}
	
	public Tree(SerializationInfo info, StreamingContext ctxt)
	{
		skillName = "Tree";
		skillDescription = "Branches comes out and damages all opponents, where each opponent is a node and deals more damage with more nodes.";
		
		skillLevel = (int)info.GetValue("TREE_SKILLEVEL",typeof(int));
		skillExperience = (int)info.GetValue("TREE_SKILLEXPERIENCE",typeof(int));
		skillCoolDown = (int)info.GetValue("TREE_SKILLCOOLDOWN",typeof(int));
		skillPower = (int)info.GetValue("TREE_SKILLPOWER",typeof(int));
		
	}
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("TREE_SKILLLEVEL", skillLevel, typeof(int));
		info.AddValue("TREE_SKILLEXPERIENCE", skillExperience, typeof(int));
		info.AddValue("TREE_COOLDOWN", skillCoolDown, typeof(int));
		info.AddValue("TREE_SKILLPOWER", skillPower, typeof(int));
		
		
	}
	
}

