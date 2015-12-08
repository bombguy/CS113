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
            turnInfo.text = "Turn :" + BattleManager.turnCounter + "     Enemies Alive: "+BattleManager.enemyParty.Count + "     Players Alive:"+BattleManager.playerParty.Count + "      Select a Unit.";
        }
        else if (GUIManager._skill == null)
        {
            turnInfo.text = "Turn :" + BattleManager.turnCounter + "     Enemies Alive: "+BattleManager.enemyParty.Count + "     Players Alive:"+BattleManager.playerParty.Count + "      Select a Skill.";
        }
        else
            turnInfo.text = "Turn :" + BattleManager.turnCounter + "     Enemies Alive: " + BattleManager.enemyParty.Count + "     Players Alive:" + BattleManager.playerParty.Count + "      Select a Target.";
    }
}
