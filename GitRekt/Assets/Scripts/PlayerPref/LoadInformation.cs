using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadInformation{
		
	public static void LoadAllInformation(){

//		Debug.Log ("Start");
//		BinaryFormatter bformatter = new BinaryFormatter();
//		FileStream stream = new FileStream (Application.persistentDataPath +"/Players.gr", FileMode.Open);
		GameInformation.players [0] = new sudo ("load");
		GameInformation.players [1] = new rmdir ("load");
		GameInformation.players [2] = new mkdir ("load");
		GameInformation.players [3] = new ls ("load");


		GameInformation.inventorySkills [0] = new Arrays ("load");
		GameInformation.inventorySkills [1] = new BreakAndContinue ("load");
		GameInformation.inventorySkills [2] = new DDOS ("load");
		GameInformation.inventorySkills [3] = new DefaultFunctions ("load");
		GameInformation.inventorySkills [4] = new FireWall ("load");
		GameInformation.inventorySkills [5] = new FunctionsWithInputOutput ("load");
		GameInformation.inventorySkills [6] = new FunctionsWithOutput ("load");
		GameInformation.inventorySkills [7] = new Hash ("load");
		GameInformation.inventorySkills [8] = new IfElse ("load");
		GameInformation.inventorySkills [9] = new InfiniteLoop ("load");
		GameInformation.inventorySkills [10] = new Loop ("load");
		GameInformation.inventorySkills [11] = new PacketSniffing ("load");
		GameInformation.inventorySkills [12] = new Recursion ("load");
		GameInformation.inventorySkills [13] = new Stack ("load");

	}

	//we may be able to avoid this if always store each spell in the same order every time. i'll think about it
	public static baseSkill createSkill(string name)
	{
		switch (name) 
		{
		case "Arrays":
			return GameInformation.inventorySkills[0];
		case "BreakAndContinue":
			return GameInformation.inventorySkills[1];
		case "DDOS":
			return GameInformation.inventorySkills[2];
		case "DefaultFunctions":
			return GameInformation.inventorySkills[3];
		case "FireWall":
			return GameInformation.inventorySkills[4];
		case "FunctionsWithInputOutput"	:
			return GameInformation.inventorySkills[5];
		case "FunctionsWithOutput"	:
			return GameInformation.inventorySkills[6];
		case "Hash":
			return GameInformation.inventorySkills[7];
		case "IfElse":
			return GameInformation.inventorySkills[8];
		case "InfiniteLoop":
			return GameInformation.inventorySkills[9];
		case "Loop":
			return GameInformation.inventorySkills[10];
		case "PacketSniffing":
			return GameInformation.inventorySkills[11];
		case "Recursion":
			return GameInformation.inventorySkills[12];
		case "Stack":
			return GameInformation.inventorySkills[13];
		default:
			return null;



		}
	}




}
