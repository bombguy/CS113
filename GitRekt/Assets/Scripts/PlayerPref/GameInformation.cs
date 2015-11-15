using UnityEngine;
using System.Collections;
using System;

public class GameInformation : MonoBehaviour {
	public static baseEnemy[] enemies;
	public static basePlayer[] players;

	void Start() {
		players = new basePlayer[4];
		players [0] = new sudo ();
		players [1] = new rmdir ();
		players [2] = new mkdir ();
		players [3] = new ls ();


		enemies = new baseEnemy[2];
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
