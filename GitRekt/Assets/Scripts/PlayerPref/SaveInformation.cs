using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveInformation{

	public static void SaveAllInformation(){
		BinaryFormatter bformatter = new BinaryFormatter ();
		foreach(basePlayer bp in GameInformation.players)
		{
			Stream stream = File.Open((bp.name+".gr"),FileMode.Create);
			bformatter.Serialize(stream,bp);
			bformatter.Serialize (stream,bp.skill1);
			bformatter.Serialize (stream,bp.skill2);
			bformatter.Serialize (stream,bp.skill3);
			bformatter.Serialize (stream,bp.skill4);
			stream.Close ();

		}



	}
}
