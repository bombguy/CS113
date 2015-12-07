using UnityEngine;
using System.Collections;
using System;

public class GameInformation : MonoBehaviour {
	public static baseEnemy[] enemies;
	public static basePlayer[] players;
	public static baseSkill[] inventorySkills;

<<<<<<< HEAD
    public static int level { get; set; }
=======
	void Start() {
		players = new basePlayer[4];
		players [0] = gameObject.AddComponent<sudo> ();
		players [1] = gameObject.AddComponent<rmdir> ();
		players [2] = gameObject.AddComponent<mkdir> ();
		players [3] = gameObject.AddComponent<ls> ();

//		players [0] = new sudo ();
//		players [1] = new rmdir ();
//		players [2] = new mkdir ();
//		players [3] = new ls ();
>>>>>>> 6f9e8fad1445f634e63dbb262b345de02b11ae47

    public void initPlayers(){
        players[0] = gameObject.AddComponent<sudo>();
        players[1] = gameObject.AddComponent<rmdir>();
        players[2] = gameObject.AddComponent<mkdir>();
        players[3] = gameObject.AddComponent<ls>();
    }
    public void initLevel() {
        switch (level)
        {
            case 1:
                for (int i = 0; i < enemies.Length; ++i)
                {
                    enemies[i] = gameObject.AddComponent<C>();
                }
                break;
            default:
                break;
        }   
    }
    public void initInventory() {
        inventorySkills = new baseSkill[25];
        inventorySkills[0] = new Arrays();
        inventorySkills[1] = new DDOS();
        inventorySkills[2] = new DefaultFunctions();
        inventorySkills[3] = new FireWall();
        inventorySkills[4] = new FunctionsWithInputOutput();
        inventorySkills[5] = new FunctionsWithOutput();
        inventorySkills[6] = new Hash();
        inventorySkills[7] = new IfElse();
        inventorySkills[8] = new InfiniteLoop();
        inventorySkills[9] = new PacketSniffing();
        inventorySkills[11] = new Stack();
        inventorySkills[12] = new Arrays();
        inventorySkills[13] = new DDOS();
        inventorySkills[14] = new DefaultFunctions();
        inventorySkills[15] = new FireWall();
        inventorySkills[16] = new FunctionsWithInputOutput();
        inventorySkills[17] = new FunctionsWithOutput();
        inventorySkills[18] = new Hash();
        inventorySkills[19] = new IfElse();
        inventorySkills[20] = new InfiniteLoop();
        inventorySkills[21] = new PacketSniffing();
        inventorySkills[22] = new Recursion();
        inventorySkills[23] = new Stack();
        inventorySkills[24] = new DDOS();

    
    }
    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
        level = 1;
        players = new basePlayer[4];
        enemies = new baseEnemy[4];
    }

<<<<<<< HEAD
    void Start() {
        initPlayers();
        initLevel();
        initInventory();
        
=======
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



	}

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
		Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
>>>>>>> 6f9e8fad1445f634e63dbb262b345de02b11ae47
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
