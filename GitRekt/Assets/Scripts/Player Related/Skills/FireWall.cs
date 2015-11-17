using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

public class FireWall : baseSkill {
	public GameInformation gameInformation;
	
	public FireWall () {
		skillName = "Fire Wall";
		skillDescription = "Increases party member's defense by " + (10 + skillLevel * 5);
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 3;
		skillPower = 0;
	}
	public FireWall(SerializationInfo info, StreamingContext ctxt)
	{
		skillName = "Fire Wall";
		skillDescription = "Increases party member's defense by " + (10 + skillLevel * 5);


		skillLevel = (int)info.GetValue("FIREWALL_SKILLEVEL",typeof(int));
		skillExperience = (int)info.GetValue("FIREWALL_SKILLEXPERIENCE",typeof(int));
		skillCoolDown = (int)info.GetValue("FIREWALL_SKILLCOOLDOWN",typeof(int));
		skillPower = (int)info.GetValue("FIREWALL_SKILLPOWER",typeof(int));

	}
	
	public override void 	cast(MonoBehaviour castor, MonoBehaviour target) {
		//skill effect
		int effect = 10 + (skillLevel * 5);
		(target as basePlayer).defense += effect;

		//skill experience gain
		skillExperience++;
		
		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
			skillLevel++;
			(castor as basePlayer).networkMastery++;
		}
	}
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("FIREWALL_SKILLLEVEL", skillLevel, typeof(int));
		info.AddValue("FIREWALL_SKILLEXPERIENCE", skillExperience, typeof(int));
		info.AddValue("FIREWALL_COOLDOWN", skillCoolDown, typeof(int));
		info.AddValue("FIREWALL_SKILLPOWER", skillPower, typeof(int));


	}
	
}
