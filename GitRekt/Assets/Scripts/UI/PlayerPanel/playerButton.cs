using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerButton : MonoBehaviour
{
    Button _playerButton;
    public ActionBar _actionBar;
    public basePlayer _player;
    public bool selected;

    void Awake() {
        _player = GetComponent<basePlayer>() as basePlayer;
        _playerButton = GetComponent<Button>();
        _actionBar = GetComponentInChildren<ActionBar>();
    }
    void Start() {
        if(_player!=null)
            _playerButton.GetComponentInChildren<Text>().text = _player.name;
        _actionBar.setActionBar(_player);
        _actionBar.hideActionBar();
        selected = false;
    }
    void Update() { 
    }
    
    public void playerSelected()
    {
        selected = true;
    }
    public void hideActionBar() {
        _actionBar.hideActionBar();
    }
    public void showActionBar(){
        _actionBar.displayActionBar();
    }
    public void buttonDisable() {
        _playerButton.interactable = false;
        selected = false;
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
