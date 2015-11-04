using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;


[System.Serializable] 
public class basePlayer: ISerializable {
	private string		playerName;
	private int			health;
	private int			attack;
	private int			defense;
	private baseSkill	spell1;
	private baseSkill	spell2;
	private baseSkill	spell3;
	private baseSkill	spell4;
	private int			flowMastery;
	private int			functionMastery;
	private int			datastructureMastery;
	private int			networkMastery;

	public string		PlayerName { get; set; }
	public int			Health { get; set; }
	public int			Attack { get; set; }
	public int			Defense { get; set; }
	public baseSkill	Spell1 { get; set; }
	public baseSkill	Spell2 { get; set; }
	public baseSkill	Spell3 { get; set; }
	public baseSkill	Spell4 { get; set; }
	public int			FlowMastery { get; set; }
	public int			FunctionMastery { get; set; }
	public int			DataStructureMastery { get; set; }
	public int			NetworkMastery { get; set; }
}