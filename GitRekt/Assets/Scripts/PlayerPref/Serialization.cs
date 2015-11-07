//using UnityEngine;
//using System;
//using System.IO;
//using System.Collections;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;
//
//public class Serialization{
//
//	public static BinaryFormatter binaryFormatter = new BinaryFormatter();
//
//	public static void Save(string saveTag, object obj){
//		MemoryStream memoryStream = new MemoryStream ();
//		binaryFormatter.serialize (memoryStream, obj);
//		string temp = System.Convert.ToBase64String (memoryStream.ToArray ());
//		PlayerPrefs.setString(saveTag,temp)
//	}
//
//	public static object Load(string saveTag){
//		string temp = PlayerPrefs.GetString (saveTag);
//		if (temp == string.empty) {
//			return null;
//		}
//		MemoryStream memoryStream = new MemoryStream (System.Convert.FromBased64String(temp));
//		return binaryFormatter.Deserialize (memoryStream);
//
//	}
//
//}
