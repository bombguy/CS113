using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using UnityEngine.EventSystems;
//"NUMBER OF NODES" NOT IMPLEMENTED
public class Tree : baseSkill {
	public GameInformation gameInformation;
	
	public Tree () {
		skillName = "Tree";
		skillDescription = "Damages all enemies based on number of nodes on the field and  " + (skillPower) + "% of player's attack.";
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 5;
		skillPower = 1;
	}
	
	public override void 	cast(MonoBehaviour castor, MonoBehaviour target) {
		//skill effect
		//int node =  number of enemies
		int damage = (int)((castor as basePlayer).attack * skillPower * node );
		(target as baseEnemy).currentHP -= damage;
		
		//skill coolddown here
		
		//skill experience gain
		skillExperience++;
		
		//if skill experience hits 10, skill/category level up
		if (skillExperience % 10 == 0) {
			skillLevel++;
			//(castor as basePlayer).category++;
			skillPower += .05;
		}
	}
	
	
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		return;
	}
	
}
