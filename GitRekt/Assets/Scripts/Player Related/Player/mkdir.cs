using System.Runtime.Serialization;
using UnityEngine.EventSystems;
using UnityEngine;

public class mkdir : basePlayer{
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
        effected = false;
        duration = 0;
        effect = Status.NONE;
        effective_skill = new NoSkill();
	}
    public override basePlayer deepCopy()
    {
        basePlayer copy = gameObject.AddComponent<mkdir>(); 
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
	
	public mkdir(string load)
	{
		name = "Miku Dirginham";
		maxHP = PlayerPrefs.GetInt ("MKDIR_HEALTH", 0);
		attack = PlayerPrefs.GetInt ("MKDIR_ATTACK", 0);
		defense = PlayerPrefs.GetInt ("MKDIR_DEFENSE", 0);
		currentHP = maxHP;

		flowMastery = PlayerPrefs.GetInt ("MKDIR_FLOW_CONTROL_MASTERY", 0);
		functionMastery = PlayerPrefs.GetInt ("MKDIR_FUNCTION_MASTERY", 0);
		datastructureMastery = PlayerPrefs.GetInt ("MKDIR_DATABASE_MASTERY", 0);
		networkMastery = PlayerPrefs.GetInt ("MKDIR_NETWORK_MASTERY", 0);

		string skill1name = PlayerPrefs.GetString ("MKDIR_SPELL1", "");
		string skill2name = PlayerPrefs.GetString ("MKDIR_SPELL2", "");
		string skill3name = PlayerPrefs.GetString ("MKDIR_SPELL3", "");
		string skill4name = PlayerPrefs.GetString ("MKDIR_SPELL4", "");

		skill1 = LoadInformation.createSkill (skill1name);
		skill2 = LoadInformation.createSkill (skill2name);
		skill3 = LoadInformation.createSkill (skill3name);
		skill4 = LoadInformation.createSkill (skill4name);

	}

	public override void savePlayer() {

		PlayerPrefs.SetInt ("MKDIR_HEALTH", maxHP);
		PlayerPrefs.SetInt ("MKDIR_ATTACK", attack);
		PlayerPrefs.SetInt ("MKDIR_DEFENSE", defense);


		PlayerPrefs.SetInt ("MKDIR_FLOWCONTROL_MASTERY", flowMastery);
		PlayerPrefs.SetInt ("MKDIR_FUNCTION_MASTERY", functionMastery);
		PlayerPrefs.SetInt ("MKDIR_DATABASE_MASTERY", datastructureMastery);
		PlayerPrefs.SetInt ("MKDIR_NETWORK_MASTERY", networkMastery);
	

		PlayerPrefs.SetString ("MKDIR_SPELL1", skill1.skillName);
		PlayerPrefs.SetString ("MKDIR_SPELL2", skill2.skillName);
		PlayerPrefs.SetString ("MKDIR_SPELL3", skill3.skillName);
		PlayerPrefs.SetString ("MKDIR_SPELL4", skill4.skillName);
	}
}