using UnityEngine;
using System.Collections;

public class GameInformation : MonoBehaviour {
	public static sudo Susan;
	public static rmdir Raymond;

	void Start() {
		Susan = new sudo ();
		Raymond = new rmdir ();
	}

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

	public static int level{ get; set;}

}
