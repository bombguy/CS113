using UnityEngine;
using System.Collections;
using System;

public class GameInformation : MonoBehaviour {
	public static baseEnemy[] enemies;
	public static basePlayer[] players;
	public static baseSkill[] inventorySkills;

	void Start() {
		players = new basePlayer[4];
		players [0] = new sudo ();
		players [1] = new rmdir ();
		players [2] = new mkdir ();
		players [3] = new ls ();


		enemies = new baseEnemy[2];

		inventorySkills = new baseSkill[25];
		inventorySkills [0] = new Arrays ();
		inventorySkills [1] = new DDOS ();
		inventorySkills [2] = new DefaultFunctions ();
		inventorySkills [3] = new FireWall ();
		inventorySkills [4] = new FunctionsWithInputOutput ();
		inventorySkills [5] = new FunctionsWithOutput ();
		inventorySkills [6] = new Hash ();
		inventorySkills [7] = new IfElse ();
		inventorySkills [8] = new InfiniteLoop ();
		inventorySkills [9] = new PacketSniffing ();
		inventorySkills [11] = new Stack ();
		inventorySkills [12] = new Arrays ();
		inventorySkills [13] = new DDOS ();
		inventorySkills [14] = new DefaultFunctions ();
		inventorySkills [15] = new FireWall ();
		inventorySkills [16] = new FunctionsWithInputOutput ();
		inventorySkills [17] = new FunctionsWithOutput ();
		inventorySkills [18] = new Hash ();
		inventorySkills [19] = new IfElse ();
		inventorySkills [20] = new InfiniteLoop ();
		inventorySkills [21] = new PacketSniffing ();
		inventorySkills [22] = new Recursion ();
		inventorySkills [23] = new Stack ();
		inventorySkills [24] = new DDOS ();

	}

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

	public static int level{ get; set;}

	public void saveGame(){
		SaveInformation.SaveAllInformation ();
		Debug.Log ("saved");
	}
	public void loadGame(){
		LoadInformation.LoadAllInformation ();
		Debug.Log ("Loaded");
	}

}
