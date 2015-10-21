using UnityEngine;
using System.Collections;

public class SaveInformation{

	public static void SaveAllinformation(){
		PlayerPrefs.SetInt ("PLAYERLEVEL", GameInformation.level);
		//Include all the other information that we want to save
	}
}
