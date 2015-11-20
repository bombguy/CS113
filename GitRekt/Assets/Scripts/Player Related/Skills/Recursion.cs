using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

public class Recursion : baseSkill {
	public GameInformation gameInformation;
	
	public Recursion () {
		skillID = 15;
		skillName = "Recursion";
		skillDescription = "A giant loop surrounds opponent's side of the field, dealing damage to all opponents.";
		hasAdditionalEffect = false;
		targetEnemy = true;
		targetPlayer = false;
		
		//define effect
		//target all opponents
		
		
		
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 5;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Spell/" + skillName);
	}
	
	public override int 	cast(MonoBehaviour castor, MonoBehaviour target) {
		//skill effect
		int attack = 25 + (skillLevel * 5);
		//skill experience gain
		skillExperience++;

		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
			skillLevel++;
			(castor as basePlayer).networkMastery++;
		}
		return attack;
	}
	
	public Recursion(SerializationInfo info, StreamingContext ctxt)
	{
		skillName = "Recursion";
		skillDescription = "A giant loop surrounds opponent's side of the field, dealing damage to all opponents.";
		
		skillLevel = (int)info.GetValue("RECURSION_SKILLEVEL",typeof(int));
		skillExperience = (int)info.GetValue("RECURSION_SKILLEXPERIENCE",typeof(int));
		skillCoolDown = (int)info.GetValue("RECURSION_SKILLCOOLDOWN",typeof(int));
		skillPower = (int)info.GetValue("RECURSION_SKILLPOWER",typeof(int));
		
	}
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("RECURSION_SKILLLEVEL", skillLevel, typeof(int));
		info.AddValue("RECURSION_SKILLEXPERIENCE", skillExperience, typeof(int));
		info.AddValue("RECURSION_COOLDOWN", skillCoolDown, typeof(int));
		info.AddValue("RECURSION_SKILLPOWER", skillPower, typeof(int));
		
		
	}
	
}

