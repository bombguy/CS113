using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class enemyButton : MonoBehaviour {
    Button _enemyButton;
    baseEnemy _enemy;
    bool selected;
	// Use this for initialization
    void Awake() {
        _enemy = GetComponent<baseEnemy>();
        _enemyButton = GetComponent<Button>();
    }
	void Start () {
        if (_enemy != null)
            _enemyButton.GetComponentInChildren<Text>().text = _enemy.name;
        else
            _enemyButton.GetComponent<Text>().text = "-";
        selected = false;
	}
    void Update() { }
    public void resetSelected() { selected = false; }
    public bool isSelected() { return selected; }
    public baseEnemy getEnemy()
    {
        return _enemy;
    }

    public void enemySelected()
    {
        selected = true;
    }
    public void buttonDisable()
    {
        _enemyButton.interactable = false;
        selected = false;
    }
    public void buttonEnable()
    {
        _enemyButton.interactable = true;
    }
    public void setButton(baseEnemy input)
    {
        _enemy = input;
        _enemyButton.GetComponentInChildren<Text>().text = _enemy.name;
    }
}
