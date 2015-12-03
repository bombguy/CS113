using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerButton : MonoBehaviour
{
    public Button _playerButton;
    public ActionBar _actionBar;
    public basePlayer _player;
    public bool _selected;

    void Awake() {
        _playerButton = GetComponent<Button>();
        _actionBar = GetComponentInChildren<ActionBar>();
    }
    void Start() {
        _actionBar.hideActionBar();
        
    }
    //Action/Turn things.
    public void endAction() {
        _playerButton.interactable = false;
        _actionBar.hideActionBar();
    }
    //Event functions
    public void playerSelected()
    {
        GUIManager.updateUnit(_player);
        _selected = true;
    }
    public void onMouseEnter() { 
        
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
        _playerButton.GetComponentInChildren<Text>().color = Color.white;
        _playerButton.GetComponentInChildren<Text>().text = _player.name;
    }
}
