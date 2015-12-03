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

    public void endAction() {
        _playerButton.interactable = false;
        _actionBar.hideActionBar();
    }
    public void playerSelected()
    {
        GUIManager.updateUnit(_player);
        _selected = true;
    }
    public void buttonDisable() {
        _playerButton.interactable = false;
        
    }
    public void buttonEnable() {
        _playerButton.interactable = true;
    }
    public void setButton(basePlayer input)
    {
        _player = input;
        _playerButton.GetComponentInChildren<Text>().text = _player.name;
    }
}
