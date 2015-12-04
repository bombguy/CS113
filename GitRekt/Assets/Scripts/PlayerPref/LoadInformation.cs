using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadInformation{
		
	public static void LoadAllInformation(){

		Debug.Log ("Start");
		BinaryFormatter bformatter = new BinaryFormatter();

		Stream stream = File.Open("Players.gr", FileMode.Open);
		GameInformation.players[0] = (sudo)bformatter.Deserialize(stream);
		GameInformation.players[1] = (rmdir)bformatter.Deserialize(stream);
		GameInformation.players[2] = (mkdir)bformatter.Deserialize(stream);
		GameInformation.players[3] = (ls)bformatter.Deserialize(stream);
		Debug.Log ("End of Players");
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
		Debug.Log ("Start Inventory");
		Stream stream1 = File.Open("Inventory.gr", FileMode.Open);
		Debug.Log ("Inventory open");
		GameInformation.inventorySkills [0] = bformatter.Deserialize (stream1) as Arrays;		
		Debug.Log ("Array");
//		GameInformation.inventorySkills [1] = bformatter.Deserialize (stream1) as BreakAndContinue;
//		Debug.Log ("BreakAndContinue");
//		GameInformation.inventorySkills [2] = bformatter.Deserialize (stream1) as DDOS;
//		Debug.Log ("DDOS");
//		GameInformation.inventorySkills [3] = bformatter.Deserialize (stream1) as DefaultFunctions;	
//		Debug.Log ("DefaultFunctions");
//		GameInformation.inventorySkills [4] = bformatter.Deserialize (stream1) as FireWall;
//		Debug.Log ("FireWall");
//		GameInformation.inventorySkills [5] = bformatter.Deserialize (stream1) as FunctionsWithInputOutput;
//		Debug.Log ("FunctionsWithInputOutput");
//		GameInformation.inventorySkills [6] = bformatter.Deserialize (stream1) as FunctionsWithOutput;
//		Debug.Log ("FunctionsWithOutput");
//		GameInformation.inventorySkills [7] = bformatter.Deserialize (stream1) as Hash;
//		Debug.Log ("Hash");
//		GameInformation.inventorySkills [8] = bformatter.Deserialize (stream1) as IfElse;
//		Debug.Log ("IfElse");
//		GameInformation.inventorySkills [9] = bformatter.Deserialize (stream1) as InfiniteLoop;
//		Debug.Log ("InfiniteLoop");
//		GameInformation.inventorySkills [10] = bformatter.Deserialize (stream1) as Loop;
//		Debug.Log ("Loop");
//		GameInformation.inventorySkills [11] = bformatter.Deserialize (stream1) as PacketSniffing;
//		Debug.Log ("PacketSniffing");
//		GameInformation.inventorySkills [12] = bformatter.Deserialize (stream1) as Recursion;
//		Debug.Log ("Recursion");
//		GameInformation.inventorySkills [13] = bformatter.Deserialize (stream1) as Stack;
//		Debug.Log ("Stack");



	}

	//we may be able to avoid this if always store each spell in the same order every time. i'll think about it
	private baseSkill createSkill(string name, Stream stream, BinaryFormatter bformatter)
	{
		switch (name) 
		{
			case "Arrays":
				return (Arrays)bformatter.Deserialize(stream);
			case "DDOS":
				return (DDOS)bformatter.Deserialize(stream);
			case "DefaultFunctions":
				return (DefaultFunctions)bformatter.Deserialize(stream);
			case "FireWall":
				return (FireWall)bformatter.Deserialize(stream);
			case "FunctionsWithInputOutput"	:
				return (FunctionsWithInputOutput)bformatter.Deserialize(stream);
			case "FunctionsWithOutput"	:
				return (FunctionsWithOutput)bformatter.Deserialize(stream);
			case "Hash":
				return (Hash)bformatter.Deserialize(stream);
			case "IfElse":
				return (IfElse)bformatter.Deserialize(stream);
			case "InfiniteLoop":
				return (InfiniteLoop)bformatter.Deserialize(stream);
			case "PacketSniffing":
				return (PacketSniffing)bformatter.Deserialize(stream);
			case "Recursion":
				return (Recursion)bformatter.Deserialize(stream);
			case "Stack":
				return (Stack)bformatter.Deserialize(stream);
			default:
				return (baseSkill)bformatter.Deserialize(stream);



		}
	}




}
