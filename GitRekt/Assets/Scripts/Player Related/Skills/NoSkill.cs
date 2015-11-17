using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using UnityEngine.EventSystems;
public class NoSkill : baseSkill {
	public GameInformation gameInformation;
	
	public NoSkill () {
		skillName = "-";
		skillDescription = "";
		skillLevel = 0;
		skillExperience = 0;
		skillCoolDown = 0;
		skillPower = 0;
	}

	public override void	cast(MonoBehaviour castor, MonoBehaviour target) {
		return;
	}
	
	public override void 	GetObjectData(SerializationInfo info, StreamingContext context) {
		return;
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        BattleManager.skill = this;
    }
}
