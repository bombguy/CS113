using UnityEngine;
using System.Collections;

public class enemyPanelController : MonoBehaviour {
    enemyButton[] _enemyButtons;
    public enemyButton _currentEnemy;
    public bool _hasSelected;

    public void Awake() {
        _enemyButtons = GetComponentsInChildren<enemyButton>();
    }
    public void Start() {
        _currentEnemy = _enemyButtons[_enemyButtons.Length - 1];
        //testEnemies();
    }
    public void testEnemies() {
        for (int i = 0; i < _enemyButtons.Length-1; ++i) { 
            baseEnemy test = new C();
            _enemyButtons[i].setButton(test);
        }
    }
    public void setEnemyButtons(baseEnemy[] enemies)
    {
        for (int i = 0; i < enemies.Length; ++i)
        {
            _enemyButtons[i].setButton(enemies[i]);
        }
    }
    public void disableEnemy() {
        _currentEnemy.buttonDisable();
    }
    
    // Update is called once per frame
    void Update()
    {
        updateSelected();
    }

    void updateSelected()
    {
        for (int i = 0; i < _enemyButtons.Length; ++i)
        {
            if (_enemyButtons[i].isSelected())
            {
                _currentEnemy.setButton(_enemyButtons[i].getEnemy());
                _enemyButtons[i].resetSelected();
                _hasSelected = true;
            }
        }
    }
}
