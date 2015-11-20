using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

public class InfiniteLoop : baseSkill {
	public GameInformation gameInformation;
	
	public InfiniteLoop () {
		skillID = 12;
		skillName = "Infinite Loop";
		skillDescription = "Lines of code appears in front of target, stunning them for one turn.";
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
	
	public InfiniteLoop(SerializationInfo info, StreamingContext ctxt)
	{
		skillName = "Infinite Loop";
		skillDescription = "Lines of code appears in front of target, stunning them for one turn.";
		
		skillLevel = (int)info.GetValue("INFINITELOOP_SKILLEVEL",typeof(int));
		skillExperience = (int)info.GetValue("INFINITELOOP_SKILLEXPERIENCE",typeof(int));
		skillCoolDown = (int)info.GetValue("INFINITELOOP_SKILLCOOLDOWN",typeof(int));
		skillPower = (int)info.GetValue("INFINITELOOP_SKILLPOWER",typeof(int));
		
	}
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("INFINITELOOP_SKILLLEVEL", skillLevel, typeof(int));
		info.AddValue("INFINITELOOP_SKILLEXPERIENCE", skillExperience, typeof(int));
		info.AddValue("INFINITELOOP_COOLDOWN", skillCoolDown, typeof(int));
		info.AddValue("INFINITELOOP_SKILLPOWER", skillPower, typeof(int));
		
		
	}
	
}

