using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

[System.Serializable]
public class FunctionsWithInputOutput : baseSkill {
	public GameInformation gameInformation;
	
	public FunctionsWithInputOutput () {
		skillID = 7;
		skillName = "Functions With I/O";
		skillDescription = "Unit will be supplying health, to deal massive damage to opponent.";
		hasAdditionalEffect = false;
		targetEnemy = false;
		targetPlayer = true;
		
		additionalEffect = new Effect ();

		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 4;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Spell/" + skillName);
	}
	
	public override int cast(MonoBehaviour castor, MonoBehaviour target) {
		//skill effect
		int health = 100 / (skillLevel + 1);
		int attack = (skillLevel * health) + 10;

		//skill experience gain
		skillExperience++;
		
		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
			skillLevel++;
			(castor as basePlayer).networkMastery++;
		}
		return attack;
	}
	
	public FunctionsWithInputOutput(SerializationInfo info, StreamingContext ctxt)
	{
		skillName = "Functions With I/O";
		skillDescription = "Unit will be supplying health, to deal massive damage to opponent.";
		
		skillLevel = (int)info.GetValue("FUNCTIONSWITHINPUTOUTPUT_SKILLEVEL",typeof(int));
		skillExperience = (int)info.GetValue("FUNCTIONSWITHINPUTOUTPUT_SKILLEXPERIENCE",typeof(int));
		skillCoolDown = (int)info.GetValue("FUNCTIONSWITHINPUTOUTPUT_SKILLCOOLDOWN",typeof(int));
		skillPower = (int)info.GetValue("FUNCTIONSWITHINPUTOUTPUT_SKILLPOWER",typeof(int));
		
	}
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("FUNCTIONSWITHINPUTOUTPUT_SKILLLEVEL", skillLevel, typeof(int));
		info.AddValue("FUNCTIONSWITHINPUTOUTPUT_SKILLEXPERIENCE", skillExperience, typeof(int));
		info.AddValue("FUNCTIONSWITHINPUTOUTPUT_COOLDOWN", skillCoolDown, typeof(int));
		info.AddValue("FUNCTIONSWITHINPUTOUTPUT_SKILLPOWER", skillPower, typeof(int));
		
		
	}
	
}
