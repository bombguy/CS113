using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour {
    public CombatStateMachine stateMachine;
    private int level = 1;

	
	void Awake () {
        stateMachine = GetComponent<CombatStateMachine>();
        InitBattle();
	}
    void InitBattle() {
    }
	// Update is called once per frame
	void Update () {
	
	}
}
