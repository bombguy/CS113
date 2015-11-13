using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveInformation{

	public static void SaveAllInformation(){
		Stream stream = File.Open ("SaveInfo.gr", FileMode.Create);
		BinaryFormatter bformatter = new BinaryFormatter ();
		foreach(basePlayer bp in GameInformation.players)
		{
			bformatter.Serialize(stream,bp);
		}
		stream.Close ();



	}
}
