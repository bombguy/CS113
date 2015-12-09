using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterStat : MonoBehaviour {

	public GameObject stat_window1;
	public GameObject stat_window2;
	public string stat1;
	public string stat2;

	// Use this for initialization
	void Start () {
		stat_window1 = GameObject.Find ("Stat1");
		stat_window2 = GameObject.Find ("Stat2");
		stat1 = "";
		stat2 = "";
		StartCoroutine(LoadCharacterStat (0));
	}

	IEnumerator LoadCharacterStat (int players) {
		yield return new WaitForSeconds (0.3F);
		basePlayer player = GameInformation.players [players];
		stat1 = player.name + "\n"
			+ "HP: " + player.currentHP + " / " + player.maxHP + "\n"
			+ "Attack: " + player.attack + "\n"
			+ "Defense: " + player.defense;

		stat2 = "Flow Control Mastery: " + player.flowMastery + "\n"
			+ "Function Mastery: " + player.functionMastery + "\n"
			+ "Data Structure Mastery: " + player.datastructureMastery + "\n"
			+ "Network Mastery: " + player.networkMastery;

		stat_window1.GetComponent<Text> ().text = stat1;
		stat_window2.GetComponent<Text> ().text = stat2;

		GameObject.Find ("Equipment").GetComponent<EquipmentScript>().LoadEquipments(players);
	}

	public void LoadCharacter(int players) {
		StartCoroutine (LoadCharacterStat (players));
	}
}