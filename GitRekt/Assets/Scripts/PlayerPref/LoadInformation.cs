using UnityEngine;

using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadInformation{
		
	public static void LoadAllInformation(){
		Stream stream = File.Open("SaveInfo.gr", FileMode.Open);
		BinaryFormatter bformatter = new BinaryFormatter();
		GameInformation.players[0] = (sudo)bformatter.Deserialize(stream);
		GameInformation.players[1] = (rmdir)bformatter.Deserialize(stream);
		GameInformation.players[2] = (mkdir)bformatter.Deserialize(stream);
		GameInformation.players[3] = (ls)bformatter.Deserialize(stream);

		Debug.Log (GameInformation.players [0].maxHP);

		stream.Close();


	}
}
