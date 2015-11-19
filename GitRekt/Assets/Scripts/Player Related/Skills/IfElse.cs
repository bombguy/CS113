using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

public class IfElse : baseSkill {
	public GameInformation gameInformation;
	
	public IfElse () {
		skillID = 2;
		skillName = "IfElse";
		skillDescription = "All or Nothing, Doubles the attack or nothing at all.";
		hasAdditionalEffect = false;
		targetEnemy = true;
		targetPlayer = false;
		
		//define effect
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.HEAL;
		additionalEffect.power = skillLevel * 2;
		additionalEffect.duration = 1;
		
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 3;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Spell/" + skillName);
	}
	
	public override int 	cast(GameObject castor, GameObject target) {
		//skill effect
		int attack = 10 + (skillLevel * 5);
		
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
		skillName = "Packet Sniffing";
		skillDescription = "Damages enemy " + (10 + skillLevel * 5) + "and heals for " +(2+skillLevel*5);
		
		skillLevel = (int)info.GetValue("PACKETSNIFFING_SKILLEVEL",typeof(int));
		skillExperience = (int)info.GetValue("PACKETSNIFFING_SKILLEXPERIENCE",typeof(int));
		skillCoolDown = (int)info.GetValue("PACKETSNIFFING_SKILLCOOLDOWN",typeof(int));
		skillPower = (int)info.GetValue("PACKETSNIFFING_SKILLPOWER",typeof(int));
		
	}
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("PACKETSNIFFING_SKILLLEVEL", skillLevel, typeof(int));
		info.AddValue("PACKETSNIFFING_SKILLEXPERIENCE", skillExperience, typeof(int));
		info.AddValue("PACKETSNIFFING_COOLDOWN", skillCoolDown, typeof(int));
		info.AddValue("PACKETSNIFFING_SKILLPOWER", skillPower, typeof(int));
		
		
	}
	
}

