﻿using System.Runtime.Serialization;

public class mkdir : basePlayer {
	
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
}