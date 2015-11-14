using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class skill4Button : MonoBehaviour, IPointerClickHandler
{
    Button skill4;
    // Use this for initialization
    void Start()
    {
        skill4 = GetComponent<Button>();
    }
    //Will be used when we implement cds and the such.
    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        BattleManager.skill = BattleManager.selectedUnit.skill4;
    }
}
