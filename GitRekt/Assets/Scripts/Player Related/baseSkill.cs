using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

[Serializable()]
public abstract class baseSkill: ISerializable{
	public enum SkillCategory
	{
		FLOWCONTROL,
		FUNCTION,
		DATASTRUCTURE,
		NETWORK
	}

	private string			skillName;
	private string			skillDesciption;
	private SkillCategory	skillCategory;	
	private int				skillLevel;
	private int				skillExperience;
	private int				skillCoolDown;
	private int				power;
	
	public string	SkillName { get; set; }
	public int		SkillLevel { get; set; }
	public int		SkillExperience { get; set; }
	public int		SkillCoolDown { get; set; }
	public int		Power { get; set; }
	
	public abstract void 	cast();
}
