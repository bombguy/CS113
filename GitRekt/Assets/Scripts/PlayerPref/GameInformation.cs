using UnityEngine;
using System.Collections;
using System;

public class GameInformation : MonoBehaviour {
	public static baseEnemy[] enemies;
	public static basePlayer[] players;
	public static baseSkill[] inventorySkills;

    public static int level { get; set; }

//		players [0] = new sudo ();
//		players [1] = new rmdir ();
//		players [2] = new mkdir ();
//		players [3] = new ls ();

    public void initPlayers(){
        players[0] = gameObject.AddComponent<sudo>();
        players[1] = gameObject.AddComponent<rmdir>();
        players[2] = gameObject.AddComponent<mkdir>();
        players[3] = gameObject.AddComponent<ls>();
		Debug.Log ("Finished Loading Player");
    }

    public void initLevel() {
        switch (level)
        {
            case 1:
                for (int i = 0; i < enemies.Length; ++i)
                {
                    enemies[i] = gameObject.AddComponent<Python>();
                }
                break;
            default:
                break;
        }
		Debug.Log ("Finished Loading Level");
    }
    public void initInventory() {
        inventorySkills = new baseSkill[14];
		inventorySkills [0] = new Arrays ();
		inventorySkills [1] = new BreakAndContinue ();
		inventorySkills [2] = new DDOS ();
		inventorySkills [3] = new DefaultFunctions ();
		inventorySkills [4] = new FireWall ();
		inventorySkills [5] = new FunctionsWithInputOutput ();
		inventorySkills [6] = new FunctionsWithOutput ();
		inventorySkills [7] = new Hash ();
		inventorySkills [8] = new IfElse ();
		inventorySkills [9] = new InfiniteLoop ();
		inventorySkills [10] = new Loop ();
		inventorySkills [11] = new PacketSniffing ();
		inventorySkills [12] = new Recursion ();
		inventorySkills [13] = new Stack ();
		Debug.Log ("Finished Loading Inventory");
    }

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
        level = 1;
        players = new basePlayer[4];
        enemies = new baseEnemy[4];
        Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
    }

    void Start() {
        initPlayers();
        //initLevel();
        initInventory();
	}

	public static void saveGame(){
		SaveInformation.SaveAllInformation();
		Debug.Log ("saved");
	}
	public static void loadGame(){
		LoadInformation.LoadAllInformation();
		Debug.Log ("Loaded");
	}

}
