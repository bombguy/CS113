using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerButton : MonoBehaviour {
	// Use this for initialization
    public basePlayer unit;
    public bool selected;
	void Start () {
        unit = GetComponent<basePlayer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void playerSelected(){
        selected = true;
    }
}
