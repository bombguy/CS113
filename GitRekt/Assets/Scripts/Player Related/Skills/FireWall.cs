using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

public class FireWall : baseSkill {
	public GameInformation gameInformation;
	
	public FireWall () {
		skillID = 6;
		skillName = "Fire Wall";
		skillDescription = "Builds a firewall in front of target, increasing defense for three turns.";
		hasAdditionalEffect = true;
		targetEnemy = false;
		targetPlayer = true;
		
		//define effect
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.DEFENSE;
		additionalEffect.power = 0;
		additionalEffect.duration = 1;
		
		
		
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 5;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Spell/" + skillName);
	}
	
	public override int 	cast(MonoBehaviour castor, MonoBehaviour target) {
		//skill effect
		int defense = (skillLevel * 5) + 10;

		//skill experience gain
		skillExperience++;
		
		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
			skillLevel++;
			(castor as basePlayer).networkMastery++;
		}
		return defense;

	}
	
	public FireWall(SerializationInfo info, StreamingContext ctxt)
	{
		skillName = "Fire Wall";
		skillDescription = "Builds a firewall in front of target, increasing defense for three turns.";
		
		skillLevel = (int)info.GetValue("FIREWALL_SKILLEVEL",typeof(int));
		skillExperience = (int)info.GetValue("FIREWALL_SKILLEXPERIENCE",typeof(int));
		skillCoolDown = (int)info.GetValue("FIREWALL_SKILLCOOLDOWN",typeof(int));
		skillPower = (int)info.GetValue("FIREWALL_SKILLPOWER",typeof(int));
		
	}
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("FIREWALL_SKILLLEVEL", skillLevel, typeof(int));
		info.AddValue("FIREWALL_SKILLEXPERIENCE", skillExperience, typeof(int));
		info.AddValue("FIREWALL_COOLDOWN", skillCoolDown, typeof(int));
		info.AddValue("FIREWALL_SKILLPOWER", skillPower, typeof(int));
		
		
	}
	
}

