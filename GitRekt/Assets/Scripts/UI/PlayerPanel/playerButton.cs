using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerButton : MonoBehaviour
{
    Button _playerButton; 
    public basePlayer _player;
    public bool selected;

    void Start() {
        _player = GetComponent<basePlayer>();
        _playerButton = GetComponent<Button>();
        if(_player != null)
            _playerButton.GetComponentInChildren<Text>().text = _player.name;
        selected = false;
    }
    void Update() { 
        
    }

    public void playerSelected()
    {
        selected = true;
    }
    public void addUnitToButton(basePlayer input)
    {
        _player = input; // possible place to instantiate
        _playerButton.GetComponentInChildren<Text>().text = _player.name;
    }
}
