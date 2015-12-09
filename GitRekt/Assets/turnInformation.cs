using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class turnInformation : MonoBehaviour {
    Text turnInfo;
    void Awake() {
        turnInfo = GetComponentInChildren<Text>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        updateTurnInfo();
	}
    public void updateTurnInfo() {
        if (GUIManager._unit == null)
        {
            turnInfo.text = "Turn :" + BattleManager.turnCounter + " ||| Action: Select a Unit.";
        }
        else if (GUIManager._skill == null)
        {
            turnInfo.text = "Turn :" + BattleManager.turnCounter + " ||| Action: Select a Skill." +
                "\n Selected Unit :"+ GUIManager._unit.name;
        }
        else
            turnInfo.text = "Turn :" + BattleManager.turnCounter + " Action: Select a Target." +
                "\n Selected Unit: "+GUIManager._unit.name +"\n Selected Skill: "+GUIManager._skill;
    }
}
