using UnityEngine;
using System.Collections;

public class GameInformation : MonoBehaviour {


	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

	public static int level{ get; set;}
//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//}
}
