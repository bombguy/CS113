using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerButton : MonoBehaviour
{
    public BattlePanel _playerBattleStats;
    public Button _playerButton;
    public ActionBar _actionBar;
    public basePlayer _player;
    public bool _selected;

    void Awake() {
        _playerButton = GetComponent<Button>();
        _actionBar = GetComponentInChildren<ActionBar>();
        _playerBattleStats = GetComponentInChildren<BattlePanel>();
    }
    void Start() {
        _actionBar.hideActionBar();
        _playerBattleStats.hidePanel();
        
    }
    //Action/Turn things.
    public void endAction() {
        _playerButton.interactable = false;
        _actionBar.hideActionBar();
        _playerBattleStats.updateBattlePanel();
    }
    //Event functions
    public void playerSelected()
    {
        GUIManager.updateUnit(_player);
        _selected = true;
        _playerBattleStats.hidePanel();
    }
    public void onMouseEnter() {
        _playerBattleStats.showPanel();    
    }
    public void onMouseExit() {
        _playerBattleStats.hidePanel();
    }
    //Button settings
    public void buttonDisable() {
        _playerButton.interactable = false;
        
    }
    public void buttonEnable() {
        _playerButton.interactable = true;
    }
    public void setButton(basePlayer input)
    {
        _player = input;
        _playerBattleStats.setBattlePanel(_player);
    }
}
