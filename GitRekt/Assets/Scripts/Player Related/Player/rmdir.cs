using System.Runtime.Serialization;
using UnityEngine.EventSystems;
[System.Serializable] 
public class rmdir : basePlayer, IPointerClickHandler {

	public rmdir () {
		name = "Raymond Dirginham";
		maxHP = 100;
		currentHP = maxHP;
		attack = 15;
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
        effected = false;
        duration = 0;
        effect = Status.NONE;
        effective_skill = new NoSkill();
    }
    public override basePlayer deepCopy()
    {
        basePlayer copy = new rmdir();
        copy.maxHP = this.maxHP;
        copy.currentHP = this.currentHP;
        copy.attack = this.attack;
        copy.defense = this.defense;
        copy.basicAttack = this.basicAttack;
        copy.skill1 = this.skill1;
        copy.skill2 = this.skill2;
        copy.skill3 = this.skill3;
        copy.skill4 = this.skill4;
        copy.flowMastery = this.flowMastery;
        copy.functionMastery = this.functionMastery;
        copy.datastructureMastery = this.datastructureMastery;
        copy.networkMastery = this.networkMastery;
        return copy;
    }
	public rmdir(SerializationInfo info, StreamingContext ctxt)
	{
		name = (string)info.GetValue("RMDIR_NAME",typeof(string));
		maxHP = (int)info.GetValue("RMDIR_HEALTH",typeof(int));
		attack = (int)info.GetValue("RMDIR_ATTACK",typeof(int));
		defense = (int)info.GetValue ("RMDIR_DEFENSE", typeof(int));
		
		flowMastery = (int)info.GetValue("RMDIR_FLOWCONTROL_MASTERY",typeof(int));
		functionMastery = (int)info.GetValue("RMDIR_FUNCTION_MASTERY",typeof(int));
		datastructureMastery = (int)info.GetValue("RMDIR_DATABASE_MASTERY",typeof(int));
		networkMastery = (int)info.GetValue ("RMDIR_NETWORK_MASTERY", typeof(int));
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("RMDIR_NAME", name, typeof(string));
		info.AddValue("RMDIR_HEALTH", maxHP, typeof(int));
		info.AddValue("RMDIR_ATTACK", attack, typeof(int));
		info.AddValue("RMDIR_DEFENSE", defense, typeof(int));

		//info.AddValue("RMDIR_SPELL1_EXP", playerName, typeof(int));

		info.AddValue("RMDIR_FLOWCONTROL_MASTERY", flowMastery, typeof(int));
		info.AddValue("RMDIR_FUNCTION_MASTERY", functionMastery, typeof(int));
		info.AddValue("RMDIR_DATABASE_MASTERY", datastructureMastery, typeof(int));
		info.AddValue("RMDIR_NETWORK_MASTERY", networkMastery, typeof(int));

		info.AddValue ("RMDIR_SPELL1", skill1.skillName, typeof(string));
		info.AddValue ("RMDIR_SPELL2", skill2.skillName, typeof(string));
		info.AddValue ("RMDIR_SPELL3", skill3.skillName, typeof(string));
		info.AddValue ("RMDIR_SPELL4", skill4.skillName, typeof(string));
	}
    public void OnPointerClick(PointerEventData eventData){
        if (BattleManager.selectedUnit == null)
            BattleManager.selectedUnit = this;
        else
            BattleManager.buffTarget = this;
    }
}