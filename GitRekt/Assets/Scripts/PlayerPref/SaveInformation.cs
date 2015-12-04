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
//		foreach (baseSkill bs in GameInformation.inventorySkills) 
//		{
//			Debug.Log (bs.skillName);
//			bformatter.Serialize(inventoryStream,bs);
//		}
		bformatter.Serialize(inventoryStream,GameInformation.inventorySkills [0]); 
//		bformatter.Serialize(inventoryStream,GameInformation.inventorySkills [1]);
//		bformatter.Serialize(inventoryStream,GameInformation.inventorySkills [2]);
//		bformatter.Serialize(inventoryStream,GameInformation.inventorySkills [3]);
//		bformatter.Serialize(inventoryStream,GameInformation.inventorySkills [4]);
//		bformatter.Serialize(inventoryStream,GameInformation.inventorySkills [5]);
//		bformatter.Serialize(inventoryStream,GameInformation.inventorySkills [6]);
//		bformatter.Serialize(inventoryStream,GameInformation.inventorySkills [7]);
//		bformatter.Serialize(inventoryStream,GameInformation.inventorySkills [8]);
//		bformatter.Serialize(inventoryStream,GameInformation.inventorySkills [9]);
//		bformatter.Serialize(inventoryStream,GameInformation.inventorySkills [10]);
//		bformatter.Serialize(inventoryStream,GameInformation.inventorySkills [11]);
//		bformatter.Serialize(inventoryStream,GameInformation.inventorySkills [12]);
//		bformatter.Serialize(inventoryStream,GameInformation.inventorySkills [13]);
		inventoryStream.Close ();


	}
}
