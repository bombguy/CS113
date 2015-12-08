using UnityEngine;
using System.Collections;

public class enemyPanelController : MonoBehaviour {

    public enemyButton[] _enemyButtons;
    public baseEnemy _selectedEnemy;
    public bool _hasSelected;

    public void Awake() {
        _enemyButtons = GetComponentsInChildren<enemyButton>();
    }
    public void Start() {
 
        _hasSelected = false;
        _selectedEnemy = null;
    }
    public void testEnemies() {
        baseEnemy[] _testEnemies;
        _testEnemies = new baseEnemy[4];
        _testEnemies[0] = gameObject.AddComponent<C>();
        _testEnemies[1] = gameObject.AddComponent<Cpp>();
        _testEnemies[2] = gameObject.AddComponent<C>();
        _testEnemies[3] = gameObject.AddComponent<Python>();
        setEnemyButtons(_testEnemies);
    }
    public void endAction() {
        for (int i = 0; i < _enemyButtons.Length; ++i)
            _enemyButtons[i]._enemyBattleStats.updateBattlePanel();
    }
    //Targeting mode
    public void enableTargetMode() {
        for (int i = 0; i < _enemyButtons.Length; ++i) {
            if (_enemyButtons[i]._enemy.currentHP > 0) {
                _enemyButtons[i].buttonEnable();
            }
                
        }
    }
    public void disableTargetMode() {
        for (int i = 0; i < _enemyButtons.Length; ++i) {
            _enemyButtons[i].buttonDisable();
        }
    }
    public void setEnemyButtons(baseEnemy[] enemies)
    {
        for (int i = 0; i < enemies.Length; ++i)
        {
            _enemyButtons[i].setButton(enemies[i]);
        }

    }
    public enemyButton fetchEnemyButton(baseEnemy unit) {
        for (int i = 0; i < _enemyButtons.Length; ++i) {
            if (_enemyButtons[i]._enemy == unit) {
                return _enemyButtons[i];
            }
        }   
        return _enemyButtons[0];
    }
    
    // Update is called once per frame
    void Update()
    {
        updateSelected();
        //updateDebug();
    }
    void updateDebug() {
        if (_selectedEnemy != null)
            Debug.Log("Current Enemy :" + _selectedEnemy.name);
        //else
           // Debug.Log("Current Enemy is null");
    }

    void updateSelected()
    {
        for (int i = 0; i < _enemyButtons.Length; ++i)
        {
            if (_enemyButtons[i].selected == true)
            {
                _selectedEnemy = _enemyButtons[i]._enemy;
                _enemyButtons[i].selected = false;
                _hasSelected = true;
                Debug.Log("Enemy :" + _selectedEnemy.name);
            }
        }
    }
}
