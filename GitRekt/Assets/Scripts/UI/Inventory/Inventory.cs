using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	public GameObject slot_prefab;
	public GameObject skill_prefab;
	public GameObject[] slots;
	public int inventory_size;

	// Use this for initialization
	void Start () {
		slots = new GameObject[inventory_size];
		for (int i = 0; i < inventory_size; i++) {
			slots[i] = (GameObject)Instantiate (slot_prefab);
			slots[i].transform.SetParent (this.transform);
		}
		StartCoroutine(LoadInventory());
	}

	IEnumerator LoadInventory() {
		yield return new WaitForSeconds(1);
		int i = 0;
		foreach (baseSkill skill in GameInformation.inventorySkills) {
			SlotScript slotscript = slots[i].GetComponent<SlotScript> ();
			slotscript.skill = skill;
			GameObject skill_in_slot = (GameObject)Instantiate(skill_prefab);
			skill_in_slot.GetComponent<Image>().sprite = skill.skillIcon;
			skill_in_slot.transform.SetParent(slots[i++].transform);
		}
	}

}
