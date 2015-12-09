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
        demoPlayers();
        //initLevel();
        initInventory();
	}
    public void initPlayers()
    {
        players[0] = gameObject.AddComponent<sudo>();
        players[1] = gameObject.AddComponent<rmdir>();
        players[2] = gameObject.AddComponent<mkdir>();
        players[3] = gameObject.AddComponent<ls>();
        players[0].skill1 = new DDOS();
        Debug.Log("Finished Loading Player");
    }
    public static void demoPlayers() {
        //Sudo
        players[0].maxHP = 200;
        players[0].currentHP = 200;
        players[0].attack = 30;
        players[0].defense = 30;
        players[0].skill1 = new Arrays();
        players[0].skill2 = new Hash();
        players[0].skill3 = new InfiniteLoop();
        players[0].skill4 = new Stack();
        players[0].networkMastery = 4;
        players[0].datastructureMastery = 1;
        players[0].functionMastery = 1;
        players[0].flowMastery = 1;
        //rmdir
        players[1].maxHP = 200;
        players[1].currentHP = 200;
        players[1].attack = 45;
        players[1].defense = 20;
        players[1].skill1 = new IfElse();
        players[1].skill2 = new FunctionsWithOutput();
        players[1].skill3 = new FunctionsWithInputOutput();
        players[1].skill4 = new DDOS();
        players[1].networkMastery = 4;
        players[1].datastructureMastery = 1;
        players[1].functionMastery = 1;
        players[1].flowMastery = 1;
        //mkdir
        players[2].maxHP = 150;
        players[2].currentHP = 150;
        players[2].attack = 50;
        players[2].defense = 10;
        players[2].skill1 = new FireWall();
        players[2].skill2 = new Arrays();
        players[2].skill3 = new FunctionsWithOutput();
        players[2].skill4 = new DDOS();
        players[2].networkMastery = 4;
        players[2].datastructureMastery = 1;
        players[2].functionMastery = 1;
        players[2].flowMastery = 1;
      
        //ls
        players[3].maxHP = 185;
        players[3].currentHP = 185;
        players[3].attack = 20;
        players[3].defense = 40;
        players[3].skill1 = new Loop();
        players[3].skill2 = new FireWall();
        players[3].skill3 = new Hash();
        players[3].skill4 = new FunctionsWithOutput();
        players[3].networkMastery = 4;
        players[3].datastructureMastery = 1;
        players[3].functionMastery = 1;
        players[3].flowMastery = 1;
      
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
