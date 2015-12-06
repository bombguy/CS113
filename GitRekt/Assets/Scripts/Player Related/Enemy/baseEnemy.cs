using UnityEngine;
using System.Collections;

public class baseEnemy : MonoBehaviour{
	public string		name;
	public int			maxHP;
	public int			currentHP;
	public int			attack;
	public int			defense;
	public baseSkill	basicAttack;
    //Battle Members for effects and the such.
    public bool         effected;
    public int          duration;
    public Status       effect;
    public baseSkill effective_skill;
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
}
