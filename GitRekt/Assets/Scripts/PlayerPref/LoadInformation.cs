using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadInformation{
		
	public static void LoadAllInformation(){

		BinaryFormatter bformatter = new BinaryFormatter();

		Stream stream = File.Open("Players.gr", FileMode.Open);
		GameInformation.players[0] = (sudo)bformatter.Deserialize(stream);
		GameInformation.players[1] = (rmdir)bformatter.Deserialize(stream);
		GameInformation.players[2] = (mkdir)bformatter.Deserialize(stream);
		GameInformation.players[3] = (ls)bformatter.Deserialize(stream);

		stream.Close ();

//		Stream inventoryStream = File.Open ("Inventory.gr", FileMode.Open);
//		for(int i = 0;i<25;i++)
//		{
//			GameInformation.inventorySkills[i] = 
//		}


//		GameInformation.players [0].skill1 = (baseSkill)bformatter.Deserialize (stream);
//		GameInformation.players [0].skill2 = (baseSkill)bformatter.Deserialize (stream);
//		GameInformation.players [0].skill3 = (baseSkill)bformatter.Deserialize (stream);
//		GameInformation.players [0].skill4 = (baseSkill)bformatter.Deserialize (stream);
		Stream stream1 = File.Open("Inventory.gr", FileMode.Open);
		GameInformation.inventorySkills [0] = (Arrays)bformatter.Deserialize (stream1);
		GameInformation.inventorySkills [1] = (DDOS)bformatter.Deserialize (stream1);
		GameInformation.inventorySkills [2] = (DefaultFunctions)bformatter.Deserialize (stream1);
		GameInformation.inventorySkills [3] = (FireWall)bformatter.Deserialize (stream1);
		GameInformation.inventorySkills [4] = (FunctionsWithInputOutput)bformatter.Deserialize (stream1);
		GameInformation.inventorySkills [5] = (FunctionsWithOutput)bformatter.Deserialize (stream1);
		GameInformation.inventorySkills [6] = (Hash)bformatter.Deserialize (stream1);
		GameInformation.inventorySkills [7] = (IfElse)bformatter.Deserialize (stream1);
		GameInformation.inventorySkills [8] = (InfiniteLoop)bformatter.Deserialize (stream1);
		GameInformation.inventorySkills [9] = (PacketSniffing)bformatter.Deserialize (stream1);
		GameInformation.inventorySkills [11] = (Stack)bformatter.Deserialize (stream1);


	}

	//we may be able to avoid this if always store each spell in the same order every time. i'll think about it
	private baseSkill createSkill(string name, Stream stream, BinaryFormatter bformatter)
	{
		switch (name) 
		{
			case "Arrays":
				return (Arrays)bformatter.Deserialize(stream);
				break;
			case "DDOS":
				return (DDOS)bformatter.Deserialize(stream);
				break;
			case "DefaultFunctions":
				return (DefaultFunctions)bformatter.Deserialize(stream);
				break;
			case "FireWall":
				return (FireWall)bformatter.Deserialize(stream);
				break;
			case "FunctionsWithInputOutput"	:
				return (FunctionsWithInputOutput)bformatter.Deserialize(stream);
				break;
			case "FunctionsWithOutput"	:
				return (FunctionsWithOutput)bformatter.Deserialize(stream);
				break;
			case "Hash":
				return (Hash)bformatter.Deserialize(stream);
				break;
			case "IfElse":
				return (IfElse)bformatter.Deserialize(stream);
				break;
			case "InfiniteLoop":
				return (InfiniteLoop)bformatter.Deserialize(stream);
				break;
			case "PacketSniffing":
				return (PacketSniffing)bformatter.Deserialize(stream);
				break;
			case "Recursion":
				return (Recursion)bformatter.Deserialize(stream);
				break;
			case "Stack":
				return (Stack)bformatter.Deserialize(stream);
				break;
			default:
				return (baseSkill)bformatter.Deserialize(stream);



		}
	}




}
