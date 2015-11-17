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
		NETWORK,
		NONE
	}

	public int				skillID;
	public string			skillName;
	public string			skillDescription;
	public SkillCategory	skillCategory;	
	public int				skillLevel;
	public int				skillExperience;
	public int				skillCoolDown;
	public double			skillPower;
	public Sprite			skillIcon;

	public abstract void 	cast(MonoBehaviour castor, MonoBehaviour target);
	public abstract void 	GetObjectData(SerializationInfo info, StreamingContext context);
}
