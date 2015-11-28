using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerButton : MonoBehaviour
{
    Button _playerButton;
    basePlayer _player;
    bool selected;

    void Awake() {
        _player = GetComponent<basePlayer>();
        _playerButton = GetComponent<Button>();
        
    }
    void Start() {
        if (_player != null)
            _playerButton.GetComponentInChildren<Text>().text = _player.name;
        else
            _playerButton.GetComponentInChildren<Text>().text = "-";
        selected = false;
    }
    void Update() { 
        
    }
    public void resetSelected() { selected = false; } 
    public bool isSelected() { return selected; }
    public basePlayer getPlayer(){
        return _player;
    }
    
    public void playerSelected()
    {
        selected = true;
    }
    public void buttonDisable() {
        _playerButton.interactable = false;
        selected = false;
    }
    public void buttonEnable() {
        _playerButton.interactable = true;
    }
    public Button getButton() { return _playerButton; }
    public void setButton(basePlayer input)
    {
        _player = input;
        _playerButton.GetComponentInChildren<Text>().text = _player.name;
    }
    public void setButton(playerButton input) {
        this._player = input.getPlayer();
        this._playerButton = input.getButton();
        this.selected = input.isSelected();
    }
}
