using System.Runtime.Serialization;

public class rmdir : basePlayer {

	public rmdir () {
		playerName = "Raymond Dirginham";
		health = 100;
		attack = 10;
		defense = 0;
		basicAttack = new BasicAttack ();
		spell1 = null;
		spell2 = null;
		spell3 = null;
		spell4 = null;
		flowMastery = 0;
		functionMastery = 0;
		datastructureMastery = 0;
		networkMastery = 0;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue("RMDIR_NAME", playerName, typeof(string));
		info.AddValue("RMDIR_HEALTH", health, typeof(int));
		info.AddValue("RMDIR_ATTACK", attack, typeof(int));
		info.AddValue("RMDIR_DEFENSE", defense, typeof(int));

		//info.AddValue("RMDIR_SPELL1_EXP", playerName, typeof(int));

		info.AddValue("RMDIR_FLOWCONTROL_MASTERY", flowMastery, typeof(int));
		info.AddValue("RMDIR_FUNCTION_MASTERY", functionMastery, typeof(int));
		info.AddValue("RMDIR_DATABASE_MASTERY", datastructureMastery, typeof(int));
		info.AddValue("RMDIR_NETWORK_MASTERY", networkMastery, typeof(int));
	}
}