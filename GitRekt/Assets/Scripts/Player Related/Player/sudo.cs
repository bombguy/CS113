using UnityEngine.EventSystems;
using UnityEngine;

public class sudo : basePlayer {
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
        effected = false;
        duration = 0;
        effect = Status.NONE;
        effective_skill = new NoSkill();
	}
    public override basePlayer deepCopy()
    {
        basePlayer copy = gameObject.AddComponent<sudo>();
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
	public sudo(string load)
	{
		name = "Susan Domo";
		maxHP = PlayerPrefs.GetInt ("SUDO_HEALTH", 0);
		attack = PlayerPrefs.GetInt ("SUDO_ATTACK", 0);
		defense = PlayerPrefs.GetInt ("SUDO_DEFENSE", 0);
		currentHP = maxHP;

		flowMastery = PlayerPrefs.GetInt ("SUDO_FLOW_CONTROL_MASTERY", 0);
		functionMastery = PlayerPrefs.GetInt ("SUDO_FUNCTION_MASTERY", 0);
		datastructureMastery = PlayerPrefs.GetInt ("SUDO_DATABASE_MASTERY", 0);
		networkMastery = PlayerPrefs.GetInt ("SUDO_NETWORK_MASTERY", 0);

		string skill1name = PlayerPrefs.GetString ("SUDO_SPELL1","");
		string skill2name = PlayerPrefs.GetString ("SUDO_SPELL2","");
		string skill3name = PlayerPrefs.GetString ("SUDO_SPELL3","");
		string skill4name = PlayerPrefs.GetString ("SUDO_SPELL4","");

		skill1 = LoadInformation.createSkill (skill1name);
		skill2 = LoadInformation.createSkill (skill2name);
		skill3 = LoadInformation.createSkill (skill3name);
		skill4 = LoadInformation.createSkill (skill4name);

	}

	public override void savePlayer() {


		PlayerPrefs.SetInt ("SUDO_HEALTH", maxHP);
		PlayerPrefs.SetInt ("SUDO_ATTACK", attack);
		PlayerPrefs.SetInt ("SUDO_DEFENSE", defense);


		PlayerPrefs.SetInt ("SUDO_FLOWCONTROL_MASTERY", flowMastery);
		PlayerPrefs.SetInt ("SUDO_FUNCTION_MASTERY", functionMastery);
		PlayerPrefs.SetInt ("SUDO_DATABASE_MASTERY", datastructureMastery);
		PlayerPrefs.SetInt ("SUDO_NETWORK_MASTERY", networkMastery);
	

		PlayerPrefs.SetString ("SUDO_SPELL1", skill1.skillName);
		PlayerPrefs.SetString ("SUDO_SPELL2", skill2.skillName);
		PlayerPrefs.SetString ("SUDO_SPELL3", skill3.skillName);
		PlayerPrefs.SetString ("SUDO_SPELL4", skill4.skillName);
	}
}