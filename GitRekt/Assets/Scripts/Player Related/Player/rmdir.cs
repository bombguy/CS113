using System.Runtime.Serialization;
using UnityEngine.EventSystems;
using UnityEngine;

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
        effected = false;
        duration = 0;
        effect = Status.NONE;
        effective_skill = new NoSkill();
    }
    public override basePlayer deepCopy()
    {
        basePlayer copy = gameObject.AddComponent<rmdir>();
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
	public rmdir(string load)
	{
		name = "Raymond Dirginham";
		maxHP = PlayerPrefs.GetInt ("RMDIR_HEALTH", 0);
		attack = PlayerPrefs.GetInt ("RMDIR_ATTACK", 0);
		defense = PlayerPrefs.GetInt ("RMDIR_DEFENSE", 0);
		currentHP = maxHP;

		flowMastery = PlayerPrefs.GetInt ("RMDIR_FLOW_CONTROL_MASTERY", 0);
		functionMastery = PlayerPrefs.GetInt ("RMDIR_FUNCTION_MASTERY", 0);
		datastructureMastery = PlayerPrefs.GetInt ("RMDIR_DATABASE_MASTERY", 0);
		networkMastery = PlayerPrefs.GetInt ("RMDIR_NETWORK_MASTERY", 0);

		string skill1name = PlayerPrefs.GetString ("RMDIR_SPELL1", "");
		string skill2name = PlayerPrefs.GetString ("RMDIR_SPELL2", "");
		string skill3name = PlayerPrefs.GetString ("RMDIR_SPELL3", "");
		string skill4name = PlayerPrefs.GetString ("RMDIR_SPELL4", "");

		skill1 = LoadInformation.createSkill (skill1name);
		skill2 = LoadInformation.createSkill (skill2name);
		skill3 = LoadInformation.createSkill (skill3name);
		skill4 = LoadInformation.createSkill (skill4name);

	}

	public override void savePlayer() {

		PlayerPrefs.SetInt ("RMDIR_HEALTH", maxHP);
		PlayerPrefs.SetInt ("RMDIR_ATTACK", attack);
		PlayerPrefs.SetInt ("RMDIR_DEFENSE", defense);


		PlayerPrefs.SetInt ("RMDIR_FLOWCONTROL_MASTERY", flowMastery);
		PlayerPrefs.SetInt ("RMDIR_FUNCTION_MASTERY", functionMastery);
		PlayerPrefs.SetInt ("RMDIR_DATABASE_MASTERY", datastructureMastery);
		PlayerPrefs.SetInt ("RMDIR_NETWORK_MASTERY", networkMastery);
	

		PlayerPrefs.SetString ("RMDIR_SPELL1", skill1.skillName);
		PlayerPrefs.SetString ("RMDIR_SPELL2", skill2.skillName);
		PlayerPrefs.SetString ("RMDIR_SPELL3", skill3.skillName);
		PlayerPrefs.SetString ("RMDIR_SPELL4", skill4.skillName);
	}
}