using UnityEngine;
using System.Collections;

public class enemyPanelController : MonoBehaviour {
    public enemyButton[] _enemyButtons;
    public enemyButton _currentEnemy;
    public bool hasSelected;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        checkSelected();
	}
    void checkSelected() {
        for (int i = 0; i < _enemyButtons.Length; ++i) {
            if (_enemyButtons[i].selected) {
                _currentEnemy.addEnemyToButton(_enemyButtons[i]._enemy);
                _enemyButtons[i].selected = false;
                hasSelected = true;
            }
        }
    }
}
