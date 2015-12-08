using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public static void ChangeToScene(string sceneToChangeTo){
		//give index to each scene and call them by their index(int)
		//note: can check index from build menu and change index of scenes
		Application.LoadLevel(sceneToChangeTo);
	}
    public static void changeToDemo() {
        Debug.Log("Loading demo Level.");
        Application.LoadLevel("BattleScene");
    }
    public void changeToDemoWrapper() {
        changeToDemo();
    }
    public void changeToSceneWrapper(string sceneToChageTo) {
        ChangeToScene(sceneToChageTo);
    }
}
