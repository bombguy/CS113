using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class enemyButton : MonoBehaviour {
   public Button _enemyButton;
   public baseEnemy _enemy;
   public bool selected;
	// Use this for initialization
    void Awake() {
        _enemyButton = GetComponent<Button>();
    }
	void Start () {
        if (_enemy != null)
            _enemyButton.GetComponentInChildren<Text>().text = _enemy.name;
        else
            _enemyButton.GetComponentInChildren<Text>().text = "-";
        selected = false;
	}
    void Update() { }

    public void enemySelected()
    {
        GUIManager.updateTarget(_enemy);
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
