using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinText : MonoBehaviour {
	int count = 0;
	Text text;
	int maxsize = 5;
	public GameObject camera;
	public Sprite win;
	string[] arr = {"...huh?", 
		"That was one weird dream...",
		"But I feel more confident to face today's exam",
		"^^", ""
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
		if(Input.GetMouseButtonDown(0) && (count > maxsize)){
			Application.LoadLevel("MainMenu");
		}
		if(count == maxsize){
			//obj.AddCompnent<Image>();
			//obj.sprite = refer;
			//GameObject obj = Instantiate(gameover, new Vector2(0,0), Quaternion.identity) as GameObject;
			camera = new GameObject ();
			camera.name = "TestCanvas";
			camera.AddComponent<Canvas> ();
			Canvas myCanvas = camera.GetComponent<Canvas> ();
			myCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
			Image m = camera.AddComponent<Image>();
			m.sprite = win;
			count++;
		}

	}
}
