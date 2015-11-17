using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

public class PacketSniffing : baseSkill {
	public GameInformation gameInformation;
	
	public PacketSniffing () {
		skillName = "Packet Sniffing";
		skillDescription = "Damages enemy " + (10 + skillLevel * 5) + "and heals for " +(2+skillLevel*5);
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 3;
		skillPower = 0;
	}

	public PacketSniffing(SerializationInfo info, StreamingContext ctxt)
	{
		skillName = "Packet Sniffing";
		skillDescription = "Damages enemy " + (10 + skillLevel * 5) + "and heals for " +(2+skillLevel*5);
		
		
		skillLevel = (int)info.GetValue("PACKETSNIFFING_SKILLEVEL",typeof(int));
		skillExperience = (int)info.GetValue("PACKETSNIFFING_SKILLEXPERIENCE",typeof(int));
		skillCoolDown = (int)info.GetValue("PACKETSNIFFING_SKILLCOOLDOWN",typeof(int));
		skillPower = (int)info.GetValue("PACKETSNIFFING_SKILLPOWER",typeof(int));
		
	}

	
	public override void 	cast(GameObject castor, GameObject target) {
		//skill effect
		int attack = 10 + (skillLevel * 5);
		int heal = 2 + (skillLevel * 5);
		(target as baseEnemy).maxHP -= attack;
		(castor as basePlayer).maxHP += heal;
		
		//skill experience gain
		skillExperience++;

		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
			skillLevel++;
			(castor as basePlayer).networkMastery++;
		}
	}
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("PACKETSNIFFING_SKILLLEVEL", skillLevel, typeof(int));
		info.AddValue("PACKETSNIFFING_SKILLEXPERIENCE", skillExperience, typeof(int));
		info.AddValue("PACKETSNIFFING_COOLDOWN", skillCoolDown, typeof(int));
		info.AddValue("PACKETSNIFFING_SKILLPOWER", skillPower, typeof(int));
		
		
	}
	
}

