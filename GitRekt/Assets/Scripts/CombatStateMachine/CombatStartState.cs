using UnityEngine;
using System.Collections;

public class CombatStartState {

	private basePlayer enemy = new basePlayer();
	
	public void PrepareBattle(){
		CreateNewEnemy();
	}

	private void CreateNewEnemy(){
		enemy.PlayerName = "enemy";
		enemy.Health = 10;
		enemy.Attack =1;
		enemy.Defense = 1;
		enemy.Spell1 = null;
		enemy.Spell2 = null;
		enemy.Spell3 = null;
		enemy.Spell4 = null;
		enemy.FlowMastery = 1;
		enemy.FunctionMastery = 1;
		enemy.DataStructureMastery = 1;
		enemy.NetworkMastery = 1;
	}
}
