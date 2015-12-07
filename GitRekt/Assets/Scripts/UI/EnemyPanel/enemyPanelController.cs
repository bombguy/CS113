using UnityEngine;
using System.Collections;

public class enemyPanelController : MonoBehaviour {
    public enemyButton[] _enemyButtons;

    public baseEnemy _selectedEnemy;
    public baseEnemy[] _enemies;
    public bool _hasSelected;

    public void Awake() {
        _enemyButtons = GetComponentsInChildren<enemyButton>();
    }
    public void Start() {
        _hasSelected = false;
        _selectedEnemy = null;
    }
    public void testEnemies() {
        _enemies = new baseEnemy[4];
        _enemies[0] = gameObject.AddComponent<C>();
        _enemies[1] = gameObject.AddComponent<Cpp>();
        _enemies[2] = gameObject.AddComponent<C>();
        _enemies[3] = gameObject.AddComponent<Python>();
        setEnemyButtons(_enemies);
    }
    public void setEnemyButtons(baseEnemy[] enemies)
    {
        _enemies = new baseEnemy[enemies.Length];
        for (int i = 0; i < enemies.Length; ++i)
        {

            _enemyButtons[i].setButton(enemies[i]);
            _enemies[i] = enemies[i];
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
