using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


public class BoardManager : MonoBehaviour {

    public GameObject floorTile;
    public GameObject wallTile;
    public int rows = 10;
    public int columns = 10;

    private Transform boardHolder;
    private List<Vector2> gridPositions;


    void InitList() {
        gridPositions.Clear();
        for (int x = 0; x < columns - 1; ++x) {
            for (int y = 0; y < columns - 1; ++y) {
                gridPositions.Add(new Vector2(x, y));
            }
        }
    }

    void boardSetup() {
        boardHolder = new GameObject("Board").transform;
        for (int x = -1; x < columns + 1; ++x) {
            for (int y = -1; y < rows + 1; ++y) {
                GameObject toInstantiate = floorTile;
                if (x == -1 || x == columns || y == -1 || y == rows)
                    toInstantiate = wallTile;
                GameObject instance = Instantiate(toInstantiate, new Vector2(x, y), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }
    }
    public void SetUpScene(int level) {
        boardSetup();
        InitList();
    }
    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
