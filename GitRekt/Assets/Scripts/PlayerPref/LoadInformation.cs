using UnityEngine;

using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadInformation{
		
	public static void LoadAllInformation(){
		BinaryFormatter bformatter = new BinaryFormatter();

		Stream stream = File.Open("Sudo.gr", FileMode.Open);
		GameInformation.players[0] = (sudo)bformatter.Deserialize(stream);
		GameInformation.players [0].skill1 = (baseSkill)bformatter.Deserialize (stream);
		GameInformation.players [0].skill2 = (baseSkill)bformatter.Deserialize (stream);
		GameInformation.players [0].skill3 = (baseSkill)bformatter.Deserialize (stream);
		GameInformation.players [0].skill4 = (baseSkill)bformatter.Deserialize (stream);


		GameInformation.players[1] = (rmdir)bformatter.Deserialize(stream);
//		GameInformation.players [1].skill1 = (skill1)bformatter.Deserialize (stream);
//		GameInformation.players [1].skill2 = (skill2)bformatter.Deserialize (stream);
//		GameInformation.players [1].skill3 = (skill3)bformatter.Deserialize (stream);
//		GameInformation.players [1].skill4 = (skill4)bformatter.Deserialize (stream);
		GameInformation.players[2] = (mkdir)bformatter.Deserialize(stream);
//		GameInformation.players [2].skill1 = (skill1)bformatter.Deserialize (stream);
//		GameInformation.players [2].skill2 = (skill2)bformatter.Deserialize (stream);
//		GameInformation.players [2].skill3 = (skill3)bformatter.Deserialize (stream);
//		GameInformation.players [2].skill4 = (skill4)bformatter.Deserialize (stream);
		GameInformation.players[3] = (ls)bformatter.Deserialize(stream);
//		GameInformation.players [3].skill1 = (skill1)bformatter.Deserialize (stream);
//		GameInformation.players [3].skill2 = (skill2)bformatter.Deserialize (stream);
//		GameInformation.players [3].skill3 = (skill3)bformatter.Deserialize (stream);
//		GameInformation.players [3].skill4 = (skill4)bformatter.Deserialize (stream);

		foreach(basePlayer bp in GameInformation.players)
		{
			Stream fstream = File.Open((bp.name+".gr"),FileMode.Create);
			bformatter.Serialize(stream,bp);
			bformatter.Serialize (fstream,bp.skill1);
			bformatter.Serialize (fstream,bp.skill2);
			bformatter.Serialize (fstream,bp.skill3);
			bformatter.Serialize (fstream,bp.skill4);
			stream.Close ();
			
		}

		stream.Close();


	}
}
