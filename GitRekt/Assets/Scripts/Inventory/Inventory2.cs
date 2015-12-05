using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory2 : MonoBehaviour, IHasChanged {

	[SerializeField] Transform slots;
	[SerializeField] Text inventoryText;

	// Use this for initialization
	void Start () {
		HasChanged ();
	
	}



	#region IHasChanged implementation
	public void HasChanged ()
	{
		System.Text.StringBuilder builder = new System.Text.StringBuilder ();
		builder.Append (" HP:0 \n Skill Power: 0 ");
		foreach (Transform slotTransform in slots) {
			GameObject item = slotTransform.GetComponent<slot>().item;
			if (item){
				builder.Append(item.name);
				builder.Append(" - ");

			}
		}
		inventoryText.text = builder.ToString ();
	}
	#endregion
}


namespace UnityEngine.EventSystems {
	public interface IHasChanged : IEventSystemHandler {
		void HasChanged();
	}
}