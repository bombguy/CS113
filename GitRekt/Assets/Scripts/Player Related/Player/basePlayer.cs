using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;


[System.Serializable] 
public abstract class basePlayer: baseGameObject, ISerializable {
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
	
	public abstract void 	GetObjectData(SerializationInfo info, StreamingContext context);
}