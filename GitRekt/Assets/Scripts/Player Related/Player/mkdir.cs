using System.Runtime.Serialization;
using UnityEngine.EventSystems;

[System.Serializable]
public class mkdir : basePlayer, IPointerClickHandler {
	public mkdir () {
		name = "Miku Dirginham";
		maxHP = 100;
		currentHP = maxHP;
		attack = 17;
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

	public mkdir(SerializationInfo info, StreamingContext ctxt)
	{
		name = (string)info.GetValue("MKDIR_NAME",typeof(string));
		maxHP = (int)info.GetValue("MKDIR_HEALTH",typeof(int));
		attack = (int)info.GetValue("MKDIR_ATTACK",typeof(int));
		defense = (int)info.GetValue ("MKDIR_DEFENSE", typeof(int));
		
		flowMastery = (int)info.GetValue("MKDIR_FLOWCONTROL_MASTERY",typeof(int));
		functionMastery = (int)info.GetValue("MKDIR_FUNCTION_MASTERY",typeof(int));
		datastructureMastery = (int)info.GetValue("MKDIR_DATABASE_MASTERY",typeof(int));
		networkMastery = (int)info.GetValue ("MKDIR_NETWORK_MASTERY", typeof(int));
	}
	
	public override void GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("MKDIR_NAME", name, typeof(string));
		info.AddValue("MKDIR_HEALTH", maxHP, typeof(int));
		info.AddValue("MKDIR_ATTACK", attack, typeof(int));
		info.AddValue("MKDIR_DEFENSE", defense, typeof(int));
		
		//info.AddValue("RMDIR_SPELL1_EXP", playerName, typeof(int));
		
		info.AddValue("MKDIR_FLOWCONTROL_MASTERY", flowMastery, typeof(int));
		info.AddValue("MKDIR_FUNCTION_MASTERY", functionMastery, typeof(int));
		info.AddValue("MKDIR_DATABASE_MASTERY", datastructureMastery, typeof(int));
		info.AddValue("MKDIR_NETWORK_MASTERY", networkMastery, typeof(int));
	}
    public void OnPointerClick(PointerEventData eventData){
        if (BattleManager.selectedUnit == null)
            BattleManager.selectedUnit = this;
        else
            BattleManager.healTarget = this;
    }
}