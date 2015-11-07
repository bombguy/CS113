using UnityEngine;
using System.Collections;

public class GameInformation : MonoBehaviour {
	public static baseEnemy[] enemies;
	public static basePlayer[] players;

	void Start() {
		players = new basePlayer[2];
		players [0] = new sudo ();
		players [1] = new rmdir ();

		enemies = new baseEnemy[2];
	}

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

	public static int level{ get; set;}

}
