using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class enemyButton : MonoBehaviour {

   public BattlePanel _enemyBattleStats;
   public Button _enemyButton;
   public baseEnemy _enemy;
   public bool selected;
	// Use this for initialization
    void Awake() {
        _enemyButton = GetComponent<Button>();
        _enemyBattleStats = GetComponentInChildren<BattlePanel>();
    }
	void Start () {
        if (_enemy != null)
            setButton(_enemy);
        else
            _enemyButton.GetComponentInChildren<Text>().text = "-";
        selected = false;
        _enemyBattleStats.hidePanel();
	}

    void Update() { }

    public void enableBattleStats() {
        _enemyBattleStats.showPanel();    
    }
    public void disableBattleStats() {
        _enemyBattleStats.hidePanel();
    }
    
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
    //Set button here.
    public void setButton(baseEnemy input)
    {
        _enemy = input;
        _enemyBattleStats.setBattlePanel(input);
    }
}
