using System.Runtime.Serialization;
<<<<<<< HEAD
using UnityEngine.EventSystems;
public class ls : basePlayer, IPointerClickHandler
{
=======
[System.Serializable] 
public class ls : basePlayer {
	
>>>>>>> 95b79f28e1ecaf27dd65fa234b08e8e5809b5509
	public ls () {
		name = "Lisa";
		maxHP = 100;
		currentHP = maxHP;
		attack = 12;
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
		info.AddValue("LS_NAME", name, typeof(string));
		info.AddValue("LS_HEALTH", maxHP, typeof(int));
		info.AddValue("LS_ATTACK", attack, typeof(int));
		info.AddValue("LS_DEFENSE", defense, typeof(int));
		
		//info.AddValue("RMDIR_SPELL1_EXP", playerName, typeof(int));
		
		info.AddValue("LS_FLOWCONTROL_MASTERY", flowMastery, typeof(int));
		info.AddValue("LS_FUNCTION_MASTERY", functionMastery, typeof(int));
		info.AddValue("LS_DATABASE_MASTERY", datastructureMastery, typeof(int));
		info.AddValue("LS_NETWORK_MASTERY", networkMastery, typeof(int));
	}
    public void OnPointerClick(PointerEventData eventData)
    {
        if (BattleManager.selectedUnit == null){
            BattleManager.selectedUnit = this;
        }
        else{
            BattleManager.healTarget = this;    
        }
   }
}