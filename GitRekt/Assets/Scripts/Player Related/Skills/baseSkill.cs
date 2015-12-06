using UnityEngine;
using System.Collections;

public abstract class baseSkill{
	public enum SkillCategory
	{
		FLOWCONTROL,
		FUNCTION,
		DATASTRUCTURE,
		NETWORK,
		NONE
	}

	public struct Effect
	{
		public enum Status
		{
			STUN,
			CONFUSED,
			AOE,
			HEAL,
			DOT,
			GOD,
			ATTACK,
			DEFENSE,
			SKIP
		}
		public Status status;
		public int power;
		public int duration;
	}

	//if skill does anything else other than just damage
	public bool hasAdditionalEffect;

	//if the skill can target player: true
	public bool targetPlayer;

	//if the skill can target enemy: true
	public bool targetEnemy;

	public SkillCategory	skillCategory;
	public Effect			additionalEffect;

	public int				skillID;
	public string			skillName;
	public string			skillDescription;
	public int				skillLevel;
	public int				skillExperience;
	public int				skillCoolDown;
	public double			skillPower;
	public Sprite			skillIcon;

	public abstract int 	cast(basePlayer caster);
    public abstract int     cast(baseEnemy caster);
	public abstract void 	saveSkill();
}
