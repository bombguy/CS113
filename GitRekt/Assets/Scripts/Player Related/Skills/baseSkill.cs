using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

[System.Serializable]
public abstract class baseSkill: ISerializable{
	public enum SkillCategory
	{
		FLOWCONTROL,
		FUNCTION,
		DATASTRUCTURE,
		NETWORK
	}

	public string			skillName;
	public string			skillDesciption;
	public SkillCategory	skillCategory;	
	public int				skillLevel;
	public int				skillExperience;
	public int				skillCoolDown;
	public int				skillPower;

	public abstract void 	cast();
	public abstract void 	GetObjectData(SerializationInfo info, StreamingContext context);
}
