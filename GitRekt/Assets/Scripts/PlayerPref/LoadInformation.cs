using UnityEngine;
using System.Collections;

public class LoadInformation{
		
	public static void LoadAllInformation(){
		GameInformation.level = PlayerPrefs.GetInt ("PLAYERLEVEL");
	}
}
