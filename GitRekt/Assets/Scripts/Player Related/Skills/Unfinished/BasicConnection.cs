using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

public class BasicConnection : baseSkill {
	public GameInformation gameInformation;
	
	public BasicConnection () {
		skillID = 3;
		skillName = "Basic Connection";
		skillDescription = "Throws a cable at targeted unit and transfers data, depending on target, it may heal allies or damage enemies.";
		hasAdditionalEffect = false;
		targetEnemy = true;
		targetPlayer = true;
		
		//define effect
		//***If target is ally, heal, otherwise do damage***
		if (targetEnemy == true) {

			additionalEffect = new Effect ();
			additionalEffect.status = Effect.Status.HEAL;
			additionalEffect.power = 2 + skillLevel * 5;
			additionalEffect.duration = 1;
		
		} 

		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 3;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Spell/" + skillName);
	}
	
	public override int cast(basePlayer caster) {
		//is it player?
		//if (target.GetType ().IsAssignableFrom (basePlayer)) {
		//	Debug.Log ("its a player");
		//} else
		//	Debug.Log ("its enemy");

		//skill effect
		int attack = (skillLevel * 5) + 10;

		//skill experience gain
		skillExperience++;
		
		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
			skillLevel++;
			caster.networkMastery++;
		}
		return attack;
	}
    public override int cast(baseEnemy caster)
    {
        return 0;
    }
	
	public BasicConnection(SerializationInfo info, StreamingContext ctxt)
	{
		skillName = "BasicConnection";
		skillDescription = "Throws a cable at targeted unit and transfers data, depending on target, it may heal allies or damage enemies.";
		
		skillLevel = (int)info.GetValue("BASICCONNECTION_SKILLEVEL",typeof(int));
		skillExperience = (int)info.GetValue("BASICCONNECTION_SKILLEXPERIENCE",typeof(int));
		skillCoolDown = (int)info.GetValue("BASICCONNECTION_SKILLCOOLDOWN",typeof(int));
		skillPower = (int)info.GetValue("BASICCONNECTION_SKILLPOWER",typeof(int));
		
	}
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("BASICCONNECTIONS_SKILLLEVEL", skillLevel, typeof(int));
		info.AddValue("BASICCONNECTION_SKILLEXPERIENCE", skillExperience, typeof(int));
		info.AddValue("BASICCONNECTION_COOLDOWN", skillCoolDown, typeof(int));
		info.AddValue("BASICCONNECTION_SKILLPOWER", skillPower, typeof(int));
		
		
	}
	
}

