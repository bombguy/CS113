using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EquipmentScript : MonoBehaviour {

	public GameObject slot_prefab;
	public GameObject skill_prefab;
	public GameObject[] slots;
	
	// Use this for initialization
	void Start () {
		slots = new GameObject[4];
		for (int i = 0; i < 4; i++) {
			slots[i] = (GameObject)Instantiate (slot_prefab);
			slots[i].transform.SetParent (this.transform);

			GameObject skill_in_slot = (GameObject)Instantiate(skill_prefab);
			skill_in_slot.transform.SetParent(slots[i].transform);
		}
		StartCoroutine(LoadEquipment(0));
	}
	
	IEnumerator LoadEquipment(int player) {
		yield return new WaitForSeconds(0.5F);

		for (int i = 0; i < 4; i++) {
			SlotScript slotscript = slots[i].GetComponent<SlotScript> ();
			switch(i) {
			case 0:
				slotscript.skill = GameInformation.players[player].skill1;
				break;
			case 1:
				slotscript.skill = GameInformation.players[player].skill2;
				break;
			case 2:
				slotscript.skill = GameInformation.players[player].skill3;
				break;
			case 3:
				slotscript.skill = GameInformation.players[player].skill4;
				break;
			}
			slots[i].transform.GetChild(0).GetComponent<Image>().sprite = slotscript.skill.skillIcon;
		}
	}

	public void LoadEquipments(int player) {
		for (int i = 0; i < 4; i++) {
			SlotScript slotscript = slots[i].GetComponent<SlotScript> ();
			switch(i) {
			case 0:
				slotscript.skill = GameInformation.players[player].skill1;
				break;
			case 1:
				slotscript.skill = GameInformation.players[player].skill2;
				break;
			case 2:
				slotscript.skill = GameInformation.players[player].skill3;
				break;
			case 3:
				slotscript.skill = GameInformation.players[player].skill4;
				break;
			}
			slots[i].transform.GetChild(0).GetComponent<Image>().sprite = slotscript.skill.skillIcon;
		}
	}
}
