using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextEditor : MonoBehaviour {
	int count = 0;
	Text text;
	int maxsize = 11;
	string[] arr = {"*rapid typing*",
		"Alright, almost done...",
		"Yes! It works beautifully",
		"Ok now I just need to commit, push, and...",
		"...",
		"..",
		"WHAT?? MERGE CONFLICT!?",
		"Okay, if I do this command, it should work...",
		"*rapid typing*",
		"NOOOOOOOOOOOOOOOO!!!",
		"ALL MY NOTES!! THEY'RE GONE! FOREVER!"
		};
	// Use this for initialization
	void Awake () {
		text = GetComponent<Text> ();
	}
	void Update(){
		if (Input.GetMouseButtonDown (0) && (count < maxsize)) {
			text.text = arr [count];
			count++;
		} 
		if(count == maxsize){
			Application.LoadLevel("BattleScene");
		}
	}
}
