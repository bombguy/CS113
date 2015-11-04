using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour {
    public BoardManager boardScript;
    public CombatStateMachine stateMachine;
    private int level = 1;

	
	void Awake () {
        boardScript = GetComponent<BoardManager>();
        stateMachine = GetComponent<CombatStateMachine>();
        InitBattle();
	}
    void InitBattle() {
        boardScript.SetUpScene(level);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
