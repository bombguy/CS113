using UnityEngine;
using System.Collections;

public class enemyPanelController : MonoBehaviour {
    public enemyButton[] _enemyButtons;
    public enemyButton _currentEnemy;
    public bool hasSelected;
	// Use this for initialization
    public enemyButton[] getEnemyButtons() { return _enemyButtons; }
    public void setEnemyButtons(baseEnemy[] enemies)
    {
        for (int i = 0; 0 < enemies.Length; ++i)
        {
            _enemyButtons[i].setButton(enemies[i]);
        }
    }
    public baseEnemy getEnemy() { return _currentEnemy.getEnemy(); }
    public void resetSelected() { hasSelected = false; }
    public bool isSelected() { return hasSelected; }

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
                hasSelected = true;
            }
        }
    }
}
