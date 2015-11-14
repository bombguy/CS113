using System.Runtime.Serialization;
using UnityEngine.EventSystems;
public class sudo : basePlayer, IPointerClickHandler {

	public sudo () {
		name = "Susan Domo";
		maxHP = 100;
		currentHP = maxHP;
		attack = 10;
		defense = 0;
		basicAttack = new BasicAttack ();
		skill1 = new NoSkill();
		skill2 = new NoSkill();
		skill3 = new NoSkill();
		skill4 = new NoSkill();
		flowMastery = 0;
		functionMastery = 0;
		datastructureMastery = 0;
		networkMastery = 0;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("SUDO_NAME", name, typeof(string));
		info.AddValue("SUDO_HEALTH", maxHP, typeof(int));
		info.AddValue("SUDO_ATTACK", attack, typeof(int));
		info.AddValue("SUDO_DEFENSE", defense, typeof(int));

		//info.AddValue("SUDO_SPELL1_EXP", playerName, typeof(int));

		info.AddValue("SUDO_FLOWCONTROL_MASTERY", flowMastery, typeof(int));
		info.AddValue("SUDO_FUNCTION_MASTERY", functionMastery, typeof(int));
		info.AddValue("SUDO_DATABASE_MASTERY", datastructureMastery, typeof(int));
		info.AddValue("SUDO_NETWORK_MASTERY", networkMastery, typeof(int));
	}
    public void OnPointerClick(PointerEventData eventData)
    {
        if (BattleManager.selectedUnit == null)
            BattleManager.selectedUnit = this;
        else
            BattleManager.healTarget = this;
    }
}