using UnityEngine;
using System.Collections;

public class SpellsUI : MonoBehaviour {

	public void CallSpell(int spell_num)
	{
		if(spell_num == 1)
			print ("spell 1");
		if(spell_num == 2)
			print ("spell 2");
		if(spell_num == 3)
			print ("spell 3");
		if(spell_num == 4)
			print ("spell 4");
	}

	public void BasicAttack()
	{
		print ("attack!!");
	}
}
