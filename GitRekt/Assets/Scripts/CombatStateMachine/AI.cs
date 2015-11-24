using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI : MonoBehaviour {

	public basePlayer lowestHealthTarget(List<basePlayer> playerTeam){
		if(playerTeam.Count == 1)
			return playerTeam[0];
		basePlayer target = playerTeam[0]; // Choose first target
		for(int i = 0; i<playerTeam.Count;++i){
			if (target.currentHP > playerTeam[i].currentHP)
				target = playerTeam[i];
		}
		return target;
	}
	public void highestDamageSpell(baseEnemy enemy){
		// return baseskill based on enemy's strongest attack  
	    
    }
	public void checkAlliedHealths(){
		//return allied enemy with lowest health if we want to include enemy healing
	}
	public void enemyHeal(){
		//return heal spell if we want to heal.
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
