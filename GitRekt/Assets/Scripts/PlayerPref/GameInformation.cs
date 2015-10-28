using UnityEngine;
using System.Collections;

public class GameInformation : MonoBehaviour {
	public static basePlayer Player { get; set; }

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

	public static int level{ get; set;}

}
