using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public GameObject slots;

	public int maxRow;
	public int maxCol;

	private int x = -110;
	private int y = 110;

	public int index;

	// Use this for initialization
	void Start () {
	
		for (int row= 0; row < maxRow; row++) {
			for (int col=0; col < maxCol; col++) {
				GameObject slot = (GameObject)Instantiate(slots);
				SlotScript slotscript = slot.GetComponent<SlotScript>();
				int index = (row*5)+col;
				slotscript.addSkillToSlot(GameInformation.inventorySkills[index]);
				slot.transform.SetParent(this.transform);
				slot.GetComponent<RectTransform>().localPosition = new Vector3(x,y,0);
				x += 55;
				if(col == maxCol-1)
					x = -110;
			}
			y -= 55;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
