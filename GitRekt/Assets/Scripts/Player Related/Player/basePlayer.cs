using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;


[System.Serializable] 
public abstract class basePlayer: ISerializable {
	public string		playerName;
	public int			health;
	public int			attack;
	public int			defense;
	public baseSkill	spell1;
	public baseSkill	spell2;
	public baseSkill	spell3;
	public baseSkill	spell4;
	public baseSkill	basicAttack;
	public int			flowMastery;
	public int			functionMastery;
	public int			datastructureMastery;
	public int			networkMastery;
	
	public abstract void 	GetObjectData(SerializationInfo info, StreamingContext context);
}