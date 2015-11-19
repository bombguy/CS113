using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

public class DDOS : baseSkill {
	public GameInformation gameInformation;
	
	public DDOS () {
		skillID = 4;
		skillName = "DDOS";
		skillDescription = "Target's computer crashes causing them to panic, resulting in a one turn stun.";
		hasAdditionalEffect = true;
		targetEnemy = true;
		targetPlayer = false;
		
		//define effect
			additionalEffect = new Effect ();
			additionalEffect.status = Effect.Status.STUN;
			additionalEffect.power = 0;
			additionalEffect.duration = 1;
			
		 
		
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 5;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Spell/" + skillName);
	}
	
	public override int 	cast(GameObject castor, GameObject target) {
		//skill effect

		//skill experience gain
		skillExperience++;
		
		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
			skillLevel++;
			(castor as basePlayer).networkMastery++;
		}
	}
	
	public DDOS(SerializationInfo info, StreamingContext ctxt)
	{
		skillName = "DDOS";
		skillDescription = "Target's computer crashes causing them to panic, resulting in a one turn stun.";
		
		skillLevel = (int)info.GetValue("DDOS_SKILLEVEL",typeof(int));
		skillExperience = (int)info.GetValue("DDOS_SKILLEXPERIENCE",typeof(int));
		skillCoolDown = (int)info.GetValue("DDOS_SKILLCOOLDOWN",typeof(int));
		skillPower = (int)info.GetValue("DDOS_SKILLPOWER",typeof(int));
		
	}
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("DDOS_SKILLLEVEL", skillLevel, typeof(int));
		info.AddValue("DDOS_SKILLEXPERIENCE", skillExperience, typeof(int));
		info.AddValue("DDOS_COOLDOWN", skillCoolDown, typeof(int));
		info.AddValue("DDOS_SKILLPOWER", skillPower, typeof(int));
		
		
	}
	
}

