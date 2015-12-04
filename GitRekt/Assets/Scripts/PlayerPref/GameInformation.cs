using UnityEngine;
using System.Collections;
using System;

public class GameInformation : MonoBehaviour {
	public static baseEnemy[] enemies;
	public static basePlayer[] players;
	public static baseSkill[] inventorySkills;

	void Start() {
		players = new basePlayer[4];
		players [0] = gameObject.AddComponent<sudo> ();
		players [1] = gameObject.AddComponent<rmdir> ();
		players [2] = gameObject.AddComponent<mkdir> ();
		players [3] = gameObject.AddComponent<ls> ();

//		players [0] = new sudo ();
//		players [1] = new rmdir ();
//		players [2] = new mkdir ();
//		players [3] = new ls ();


		enemies = new baseEnemy[2];

		inventorySkills = new baseSkill[25];
		inventorySkills [0] = new Arrays ();
		inventorySkills [1] = new BreakAndContinue ();
		inventorySkills [2] = new DDOS ();
		inventorySkills [3] = new DefaultFunctions ();
		inventorySkills [4] = new FireWall ();
		inventorySkills [5] = new FunctionsWithInputOutput ();
		inventorySkills [6] = new FunctionsWithOutput ();
		inventorySkills [7] = new Hash ();
		inventorySkills [8] = new IfElse ();
		inventorySkills [9] = new InfiniteLoop ();
		inventorySkills [10] = new Loop ();
		inventorySkills [11] = new PacketSniffing ();
		inventorySkills [12] = new Recursion ();
		inventorySkills [13] = new Stack (); 



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
