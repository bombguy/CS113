using System.Runtime.Serialization;

public class sudo : basePlayer {

	public sudo () {
		playerName = "Susan Domo";
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
		info.AddValue("SUDO_NAME", playerName, typeof(string));
		info.AddValue("SUDO_HEALTH", health, typeof(int));
		info.AddValue("SUDO_ATTACK", attack, typeof(int));
		info.AddValue("SUDO_DEFENSE", defense, typeof(int));

		//info.AddValue("SUDO_SPELL1_EXP", playerName, typeof(int));

		info.AddValue("SUDO_FLOWCONTROL_MASTERY", flowMastery, typeof(int));
		info.AddValue("SUDO_FUNCTION_MASTERY", functionMastery, typeof(int));
		info.AddValue("SUDO_DATABASE_MASTERY", datastructureMastery, typeof(int));
		info.AddValue("SUDO_NETWORK_MASTERY", networkMastery, typeof(int));
	}
}