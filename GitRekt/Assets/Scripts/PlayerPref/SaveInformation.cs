using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveInformation{

	public static void SaveAllInformation(){
		BinaryFormatter bformatter = new BinaryFormatter ();
		Stream playerStream = File.Open(("Players.gr"),FileMode.Create);
		foreach(basePlayer bp in GameInformation.players)
		{
			bformatter.Serialize(playerStream,bp);
		}
		playerStream.Close ();


		Stream inventoryStream  = File.Open ("Inventory.gr",FileMode.Create);
		foreach (baseSkill bs in GameInformation.inventorySkills) 
		{
			bformatter.Serialize(inventoryStream,bs);
		}
		playerStream.Close ();


	}
}
