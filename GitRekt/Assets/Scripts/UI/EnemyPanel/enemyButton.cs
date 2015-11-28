using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class enemyButton : MonoBehaviour {
    Button _enemyButton;
    public baseEnemy _enemy;
    public bool selected;
	// Use this for initialization
	void Start () {
        _enemy = GetComponent<baseEnemy>();
        _enemyButton = GetComponent<Button>();
        if (_enemy != null)
            _enemyButton.GetComponentInChildren<Text>().text = _enemy.name;
        selected = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //public variables
    public void enemySelected() {
        selected = true;
    }
    public void addEnemyToButton(baseEnemy input) {
        _enemy = input;
        _enemyButton.GetComponentInChildren<Text>().text = _enemy.name;
    }
}
