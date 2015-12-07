using UnityEngine;
using System.Collections;



public abstract class basePlayer: MonoBehaviour {
	public string		name;
	public int			maxHP;
	public int			currentHP;
	public int			attack;
	public int			defense;
	public baseSkill	skill1;
	public baseSkill	skill2;
	public baseSkill	skill3;
	public baseSkill	skill4;
	public baseSkill	basicAttack;
	public int			flowMastery;
	public int			functionMastery;
	public int			datastructureMastery;
	public int			networkMastery;
    public enum Status
    {
        NONE,
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
    //Battle Members for effects and the such.
    public bool         effected;
    public Status       effect;
    public int          duration;
    public baseSkill effective_skill;
    public abstract basePlayer deepCopy();
	public abstract void 	savePlayer();
}