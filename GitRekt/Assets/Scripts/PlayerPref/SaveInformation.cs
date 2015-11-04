using UnityEngine;
using System.Collections;

public class SaveInformation{

	public static void SaveAllinformation(){
		//Include all the other information that we want to save
		basePlayer toSave = GameInformation.Player;
		baseSkill spell1 = toSave.Spell1;
		baseSkill spell2 = toSave.Spell2;
		baseSkill spell3 = toSave.Spell3;
		baseSkill spell4 = toSave.Spell4;

		//Player Stats
		PlayerPrefs.SetString ("PLAYERNAME", toSave.PlayerName);
		PlayerPrefs.SetInt ("HEALTH", toSave.Health);
		PlayerPrefs.SetInt ("ATTACK", toSave.Attack);
		PlayerPrefs.SetInt ("DEFENSE", toSave.Defense);

		PlayerPrefs.SetInt ("FLOWMASTERY", toSave.FlowMastery);
		PlayerPrefs.SetInt ("FUNCTIONMASTERY", toSave.FunctionMastery);
		PlayerPrefs.SetInt ("DATASTRUCTUREMASTERY", toSave.DataStructureMastery);
		PlayerPrefs.SetInt ("NETWORKMASTERY", toSave.NetworkMastery);

		//Spell1
		PlayerPrefs.SetString ("1SKILLNAME", spell1.SkillName);
		PlayerPrefs.SetString ("1SKILLLEVEL", spell1.SkillLevel);
		PlayerPrefs.SetString ("1SKILLEXPERIENCE", spell1.SkillExperience);
		PlayerPrefs.SetString ("1SKILLCOOLDOWN", spell1.SkillCoolDown);
		PlayerPrefs.SetString ("1SKILLPOWER", spell1.Power);

		//Spell2
		PlayerPrefs.SetString ("2SKILLNAME", spell2.SkillName);
		PlayerPrefs.SetString ("2SKILLLEVEL", spell2.SkillLevel);
		PlayerPrefs.SetString ("2SKILLEXPERIENCE", spell2.SkillExperience);
		PlayerPrefs.SetString ("2SKILLCOOLDOWN", spell2.SkillCoolDown);
		PlayerPrefs.SetString ("2SKILLPOWER", spell2.Power);

		//Spell3
		PlayerPrefs.SetString ("3SKILLNAME", spell3.SkillName);
		PlayerPrefs.SetString ("3SKILLLEVEL", spell3.SkillLevel);
		PlayerPrefs.SetString ("3SKILLEXPERIENCE", spell3.SkillExperience);
		PlayerPrefs.SetString ("3SKILLCOOLDOWN", spell3.SkillCoolDown);
		PlayerPrefs.SetString ("3SKILLPOWER", spell3.Power);

		//Spell4
		PlayerPrefs.SetString ("4SKILLNAME", spell4.SkillName);
		PlayerPrefs.SetString ("4SKILLLEVEL", spell4.SkillLevel);
		PlayerPrefs.SetString ("4SKILLEXPERIENCE", spell4.SkillExperience);
		PlayerPrefs.SetString ("4SKILLCOOLDOWN", spell4.SkillCoolDown);
		PlayerPrefs.SetString ("4SKILLPOWER", spell4.Power);





	}
}
