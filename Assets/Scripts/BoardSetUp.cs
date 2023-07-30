using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSetUp : MonoBehaviour
{
    public GameObject WhiteTile, BlackTile, WhiteKing, BlackKing, WhiteQueen, BlackQueen, WhiteKnight, BlackKnight, WhiteBishop, BlackBishop, WhiteRook, BlackRook, WhitePawn, BlackPawn;
    public Dictionary<GameObject, GameObject> Tiles { get; private set; }
    private const float TILE_HEIGHT = 0.5f;
    private const float TILE_WIDTH = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Tiles = new Dictionary<GameObject, GameObject>();
        for (char i = 'a'; i < 'i'; i++)
        {
            float x = i - 104;
            for(int j = 1;j < 9; j++)
            {
                float y = (float)(j - 4);
                if (((int)i % 2 == 0 && j % 2 == 0) || ((int)i % 2 != 0 && j % 2 != 0)) {
                    Tiles.Add(Instantiate(BlackTile, new Vector3(x - TILE_WIDTH, y - TILE_HEIGHT, 0), Quaternion.identity), null);
                }
                else
                {
                    Tiles.Add(Instantiate(WhiteTile, new Vector3(x - TILE_WIDTH, y - TILE_HEIGHT, 0), Quaternion.identity), null);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
