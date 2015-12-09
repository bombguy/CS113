using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoseText : MonoBehaviour {
	//var obj = new GameObject();
	//var renderer = obj.AddComponent<SpriteRenderer> ();
	//Renderer.sprite = refer;
	public Sprite gameover;
	int count = 0;
	Text text;
	int maxsize = 5;
	public GameObject camera;
	//Texture2D myGUITexture;
	string[] arr = {"OH CRAP!!!", "WHAT TIME IS IT???", "I CAN'T DO THIS, I CAN'T!!", "*cries*", ""
	};
	// Use this for initialization
	void Awake () {
		text = GetComponent<Text> ();
	}
	void Update()
	{
		if (Input.GetMouseButtonDown (0) && (count < maxsize)) {
			text.text = arr[count];
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
			m.sprite = gameover;
			count++;
		}

	}
}
