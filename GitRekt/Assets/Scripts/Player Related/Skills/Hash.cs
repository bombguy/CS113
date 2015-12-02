using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

[System.Serializable]
public class Hash : baseSkill {
	public GameInformation gameInformation;
	
	public Hash () {
		skillID = 10;
		skillName = "Hash";
		skillDescription = "Guaranteed to block an attack.";
		hasAdditionalEffect = true;
		targetEnemy = false;
		targetPlayer = true;
		
		//define effect
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.GOD;
		additionalEffect.power = 0;
		additionalEffect.duration = 1;
		
		
		
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 10;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Spell/" + skillName);
	}
	
	public override int 	cast(MonoBehaviour castor, MonoBehaviour target) {
		//skill effect
		
		//skill experience gain
		skillExperience++;
		
		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
			skillLevel++;
			(castor as basePlayer).networkMastery++;
		}
		return 0;
	}
	
	public Hash(SerializationInfo info, StreamingContext ctxt)
	{
		skillName = "Hash";
		skillDescription = "Guaranteed to block an attack.";
		
		skillLevel = (int)info.GetValue("HASH_SKILLEVEL",typeof(int));
		skillExperience = (int)info.GetValue("HASH_SKILLEXPERIENCE",typeof(int));
		skillCoolDown = (int)info.GetValue("HASH_SKILLCOOLDOWN",typeof(int));
		skillPower = (int)info.GetValue("HASH_SKILLPOWER",typeof(int));
		
	}
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("HASH_SKILLLEVEL", skillLevel, typeof(int));
		info.AddValue("HASH_SKILLEXPERIENCE", skillExperience, typeof(int));
		info.AddValue("HASH_COOLDOWN", skillCoolDown, typeof(int));
		info.AddValue("HASH_SKILLPOWER", skillPower, typeof(int));
		
		
	}
	
}

