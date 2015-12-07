using UnityEngine;
using System.Collections;

public class enemyPanelController : MonoBehaviour {

    public enemyButton[] _enemies;
    public baseEnemy _selectedEnemy;
    public bool _hasSelected;

    public void Awake() {
        _enemies = GetComponentsInChildren<enemyButton>();

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
    //Targeting mode
    public void enableTargetMode() {
        for (int i = 0; i < _enemies.Length; ++i) {
            if (_enemies[i]._enemy.currentHP > 0) {
                _enemies[i].buttonEnable();
            }
                
        }
    }
    public void disableTargetMode() {
        for (int i = 0; i < _enemies.Length; ++i) {
            _enemies[i].buttonDisable();
        }
    }
    public void setEnemyButtons(baseEnemy[] enemies)
    {
        for (int i = 0; i < enemies.Length; ++i)
        {
            _enemies[i].setButton(enemies[i]);
        }
    }
    public enemyButton fetchEnemyButton(baseEnemy unit) {
        for (int i = 0; i < _enemies.Length; ++i) {
            if (_enemies[i]._enemy == unit) {
                return _enemies[i];
            }
        }   
        return _enemies[0];
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
        for (int i = 0; i < _enemies.Length; ++i)
        {
            if (_enemies[i].selected == true)
            {
                _selectedEnemy = _enemies[i]._enemy;
                _enemies[i].selected = false;
                _hasSelected = true;
                Debug.Log("Enemy :" + _selectedEnemy.name);
            }
        }
    }
}
