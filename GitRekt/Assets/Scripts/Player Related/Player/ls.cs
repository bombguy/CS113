using System.Runtime.Serialization;
using UnityEngine.EventSystems;
using UnityEngine;


public class ls : basePlayer
{
    public ls()
    {
        name = "Lisa";
        maxHP = 100;
        currentHP = maxHP;
        attack = 12;
        defense = 0;
        basicAttack = new BasicAttack();
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
        basePlayer copy = gameObject.AddComponent<ls>();
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
    public ls(string load)
    {
        name = "Lisa";
        maxHP = PlayerPrefs.GetInt ("LS_HEALTH", 0);
        attack = PlayerPrefs.GetInt ("LS_ATTACK", 0);
        defense = PlayerPrefs.GetInt ("LS_DEFENSE", 0);
        currentHP = maxHP;

        flowMastery = PlayerPrefs.GetInt ("LS_FLOW_CONTROL_MASTERY", 0);
        functionMastery = PlayerPrefs.GetInt ("LS_FUNCTION_MASTERY", 0);
        datastructureMastery = PlayerPrefs.GetInt ("LS_DATABASE_MASTERY", 0);
        networkMastery = PlayerPrefs.GetInt ("LS_NETWORK_MASTERY", 0);

        string skill1name = PlayerPrefs.GetString ("LS_SPELL1", "");
        string skill2name = PlayerPrefs.GetString ("LS_SPELL2", "");
        string skill3name = PlayerPrefs.GetString ("LS_SPELL3", "");
        string skill4name = PlayerPrefs.GetString ("LS_SPELL4", "");

        skill1 = LoadInformation.createSkill (skill1name);
        skill2 = LoadInformation.createSkill (skill2name);
        skill3 = LoadInformation.createSkill (skill3name);
        skill4 = LoadInformation.createSkill (skill4name);

    }

    public override void savePlayer() {

        PlayerPrefs.SetInt ("LS_HEALTH", maxHP);
        PlayerPrefs.SetInt ("LS_ATTACK", attack);
        PlayerPrefs.SetInt ("LS_DEFENSE", defense);


        PlayerPrefs.SetInt ("LS_FLOWCONTROL_MASTERY", flowMastery);
        PlayerPrefs.SetInt ("LS_FUNCTION_MASTERY", functionMastery);
        PlayerPrefs.SetInt ("LS_DATABASE_MASTERY", datastructureMastery);
        PlayerPrefs.SetInt ("LS_NETWORK_MASTERY", networkMastery);
    

        PlayerPrefs.SetString ("LS_SPELL1", skill1.skillName);
        PlayerPrefs.SetString ("LS_SPELL2", skill2.skillName);
        PlayerPrefs.SetString ("LS_SPELL3", skill3.skillName);
        PlayerPrefs.SetString ("LS_SPELL4", skill4.skillName);
    }
}