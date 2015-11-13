using System.Runtime.Serialization;
[System.Serializable] 
public class rmdir : basePlayer {

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
	}
}