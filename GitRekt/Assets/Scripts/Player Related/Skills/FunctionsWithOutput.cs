using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

public class FunctionsWithOutput : baseSkill {
	public GameInformation gameInformation;
	
	public FunctionsWithOutput () {
		skillID = 8;
		skillName = "Functions With Output";
		skillDescription = "Unit will enter code and output solutions will be sent to the opponent damaging them.";
		hasAdditionalEffect = false;
		targetEnemy = true;
		targetPlayer = false;
		
		//define effect
		additionalEffect = new Effect ();

		
		
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 5;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
	}
	
	public override int 	cast(MonoBehaviour castor, MonoBehaviour target) {
		//skill effect
		int attack = (skillLevel * 5) + 20;

		//skill experience gain
		skillExperience++;
		
		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
			skillLevel++;
			(castor as basePlayer).networkMastery++;
		}
		return attack;
	}
	
	public FunctionsWithOutput(SerializationInfo info, StreamingContext ctxt)
	{
		skillName = "Functions With Output";
		skillDescription = "Unit will enter code and output solutions will be sent to the opponent damaging them.";
		
		skillLevel = (int)info.GetValue("FUNCTIONSWITHOUTPUT_SKILLEVEL",typeof(int));
		skillExperience = (int)info.GetValue("FUNCTIONSWITHOUTPUT_SKILLEXPERIENCE",typeof(int));
		skillCoolDown = (int)info.GetValue("FUNCTIONSWITHOUTPUT_SKILLCOOLDOWN",typeof(int));
		skillPower = (int)info.GetValue("FUNCTIONSWITHOUTPUT_SKILLPOWER",typeof(int));
		
	}
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("FUNCTIONSWITHOUTPUT_SKILLLEVEL", skillLevel, typeof(int));
		info.AddValue("FUNCTIONSWITHOUTPUT_SKILLEXPERIENCE", skillExperience, typeof(int));
		info.AddValue("FUNCTIONSWITHOUTPUT_COOLDOWN", skillCoolDown, typeof(int));
		info.AddValue("FUNCTIONSWITHOUTPUT_SKILLPOWER", skillPower, typeof(int));
		
		
	}
	
}
