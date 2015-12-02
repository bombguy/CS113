using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

public class Graph : baseSkill {
	public GameInformation gameInformation;
	
	public Graph () {
		skillID = 9;
		skillName = "Graph";
		skillDescription = "Draws a graph with each character is a point on the map, draw a white line hitting each point to heal all characters.";
		hasAdditionalEffect = true;
		targetEnemy = false;
		targetPlayer = true;
		
		//define effect
		//NEEDS TO HEAL ALL UNITS
		additionalEffect = new Effect ();
		additionalEffect.status = Effect.Status.AOE;
		additionalEffect.power = 0;
		additionalEffect.duration = 1;
		
		
		
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 5;
		skillPower = 0;
		
		skillIcon = Resources.Load<Sprite> ("Skill/" + skillName);
	}
	
	public override int cast(basePlayer caster) {
		//skill effect
		
		//skill experience gain
		skillExperience++;
		
		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
			skillLevel++;
			caster.networkMastery++;
		}
		return 0;
	}
    public override int cast(baseEnemy caster)
    {
        return 0;
    }
	
	public Graph(SerializationInfo info, StreamingContext ctxt)
	{
		skillName = "Graph";
		skillDescription = "Target's computer crashes causing them to panic, resulting in a one turn stun.";
		
		skillLevel = (int)info.GetValue("GRAPH_SKILLEVEL",typeof(int));
		skillExperience = (int)info.GetValue("GRAPH_SKILLEXPERIENCE",typeof(int));
		skillCoolDown = (int)info.GetValue("GRAPH_SKILLCOOLDOWN",typeof(int));
		skillPower = (int)info.GetValue("GRAPH_SKILLPOWER",typeof(int));
		
	}
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("GRAPH_SKILLLEVEL", skillLevel, typeof(int));
		info.AddValue("GRAPH_SKILLEXPERIENCE", skillExperience, typeof(int));
		info.AddValue("GRAPH_COOLDOWN", skillCoolDown, typeof(int));
		info.AddValue("GRAPH_SKILLPOWER", skillPower, typeof(int));
		
		
	}
	
}

