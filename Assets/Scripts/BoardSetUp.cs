using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BoardSetUp : MonoBehaviour
{
    [SerializeField]
    private GameObject WhiteTile, BlackTile;
    private const float TILE_HEIGHT = 0.5f;
    private const float TILE_WIDTH = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        SetUpBoard();
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void SetUpBoard()
    {
        for (char i = 'a'; i < 'i'; i++)
        {
            float x = i - 104;
            for (int j = 1; j < 9; j++)
            {
                float y = (float)(j - 4);
                if (((int)i % 2 == 0 && j % 2 == 0) || ((int)i % 2 != 0 && j % 2 != 0))
                {
                    BlackTile = Instantiate(BlackTile, new Vector3(x - TILE_WIDTH, y - TILE_HEIGHT, 0), Quaternion.identity);
                    BlackTile.name = i + "" + j;
                }
                else
                {
                    WhiteTile = Instantiate(WhiteTile, new Vector3(x - TILE_WIDTH, y - TILE_HEIGHT, 0), Quaternion.identity);
                    WhiteTile.name = i + "" + j;
                }
            }
        }
    }
}
