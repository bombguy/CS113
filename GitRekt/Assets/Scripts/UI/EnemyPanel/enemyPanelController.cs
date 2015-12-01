using UnityEngine;
using System.Collections;

public class enemyPanelController : MonoBehaviour {
    enemyButton[] _enemyButtons;

    public baseEnemy _selectedEnemy;
    public baseEnemy[] enemies;
    public bool _hasSelected;

    public void Awake() {
        _enemyButtons = GetComponentsInChildren<enemyButton>();
    }
    public void Start() {
        _hasSelected = false;
        _selectedEnemy = null;
        testEnemies();
    }
    public void testEnemies() {
        enemies = new baseEnemy[4];
        enemies[0] = gameObject.AddComponent<C>();
        enemies[1] = gameObject.AddComponent<Cpp>();
        enemies[2] = gameObject.AddComponent<C>();
        enemies[3] = gameObject.AddComponent<Python>();
        setEnemyButtons(enemies);
    }
    public void setEnemyButtons(baseEnemy[] enemies)
    {
        for (int i = 0; i < enemies.Length; ++i)
        {
            _enemyButtons[i].setButton(enemies[i]);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        updateSelected();
        updateDebug();
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
