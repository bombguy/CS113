using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerButton : MonoBehaviour
{
    public Button _playerButton; 
    public basePlayer unit;
    public bool selected;

    void Start() {
        unit = GetComponent<basePlayer>();
        _playerButton = GetComponent<Button>();
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
        unit = input; // possible place to instantiate
        _playerButton.GetComponentInChildren<Text>().text = unit.name;
    }
}
