using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * Changes the text on the button whenever a player is selected.
 */
public class displaySkill3 : MonoBehaviour
{
    Text spellText;
    basePlayer previouslySelected;
    // Use this for initialization
    void Start()
    {
        spellText = GetComponent<Text>();
        spellText.text = " ";
        previouslySelected = null;
    }
    void Update()
    {
        if (BattleManager.selectedUnit != null && BattleManager.selectedUnit != previouslySelected)
        {
            spellText.text = BattleManager.selectedUnit.skill3.skillName;
            previouslySelected = BattleManager.selectedUnit;
        }
        //This might be buggy as were using coroutines which stop the update function. if so this is fixable.
        if (CombatStateMachine.CurrentState == CombatStateMachine.CombatStates.ENEMY)
        {
            spellText.text = " ";
            previouslySelected = null;
        }
    }
}
