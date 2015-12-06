using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using UnityEngine.EventSystems;
public class NoSkill : baseSkill {
	public GameInformation gameInformation;
	
	public NoSkill () {
		skillName = "-";
		skillDescription = " ";
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 0;
		skillPower = 0;
	}

	public override int	cast(basePlayer caster) {
		return 0 ;
	}
    public override int cast(baseEnemy caster)
    {
        return 0;
    }
	
	public override void 	saveSkill(){
		return;
	}
}
