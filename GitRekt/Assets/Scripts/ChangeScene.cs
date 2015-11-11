using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public void ChangeToScene(string sceneToChangeTo){
		//give index to each scene and call them by their index(int)
		//note: can check index from build menu and change index of scenes
		Application.LoadLevel(sceneToChangeTo);
	}
}
