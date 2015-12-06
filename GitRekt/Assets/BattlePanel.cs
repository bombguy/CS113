using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BattlePanel : MonoBehaviour {
    Image background;
    Text battleStats;
    basePlayer _unit;
    void Awake() {
        battleStats = GetComponentInChildren<Text>();
        background = GetComponent<Image>();
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void setBattlePanel(basePlayer unit) {
        _unit = unit;
        battleStats.text = 
            "Name : " + _unit.name + "\n" +
            "HP :" + _unit.currentHP + "/" + _unit.maxHP + "\n" +
            "Effects : " + _unit.effect.ToString() + "\n" +
            "Flow Mastery :" + _unit.flowMastery + "\n" +
            "Function Mastery :" + _unit.functionMastery + "\n" +
            "Data Structure Mastery :" + _unit.datastructureMastery;
    }
    public void updateBattlePanel() {
        battleStats.text = 
            "Name : " + _unit.name + "\n" +
            "HP :" + _unit.currentHP + "/" + _unit.maxHP + "\n" +
            "Effects : " + _unit.effect.ToString() + "\n" +
            "Flow Mastery :" + _unit.flowMastery + "\n" +
            "Function Mastery :" + _unit.functionMastery + "\n" +
            "Data Structure Mastery :" + _unit.datastructureMastery;
    }
    public void hidePanel() {
        background.enabled = false;
        battleStats.enabled = false;
    }
    public void showPanel() {
        background.enabled = true;
        battleStats.enabled = true;
    }
}
