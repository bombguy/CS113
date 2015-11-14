using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class skillBasicButton : MonoBehaviour, IPointerClickHandler
{
    Button skillBasic;
    // Use this for initialization
    void Start()
    {
        skillBasic = GetComponent<Button>();
    }
    //Will be used when we implement cds and the such.
    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        BattleManager.skill = BattleManager.selectedUnit.basicAttack;
    }
}
