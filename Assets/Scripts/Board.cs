using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private GameObject WhiteTile, BlackTile, WhiteKing, BlackKing, WhiteQueen, BlackQueen, WhiteKnight, BlackKnight, WhiteBishop, BlackBishop, WhiteRook, BlackRook, WhitePawn, BlackPawn;
    
    private const float TILE_HEIGHT = 0.5f;
    private const float TILE_WIDTH = 0.5f;
    // Start is called before the first frame update
    void Awake()
    {
        SetUp();
    }
    private void SetUp()
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
                    SetUpPiece(BlackTile);
                }
                else
                {
                    WhiteTile = Instantiate(WhiteTile, new Vector3(x - TILE_WIDTH, y - TILE_HEIGHT, 0), Quaternion.identity);
                    WhiteTile.name = i + "" + j;
                    SetUpPiece(WhiteTile);
                }
            }
        }
    }
    private void SetUpPiece(GameObject tile)
    {
        Vector3 chessPosition = new Vector3(tile.transform.position.x, tile.transform.position.y, -1);
        switch (tile.name)
        {
            case "a1":
            case "h1":
                WhiteRook = Instantiate(WhiteRook, chessPosition, Quaternion.identity);
                WhiteRook.name = "white_rook_" + tile.name;
                break;
            case "b1":
            case "g1":
                WhiteKnight = Instantiate(WhiteKnight, chessPosition, Quaternion.identity);
                WhiteKnight.name = "white_knight_" + tile.name;
                break;
            case "c1":
            case "f1":
                WhiteBishop = Instantiate(WhiteBishop, chessPosition, Quaternion.identity);
                WhiteBishop.name = "white_bishop_" + tile.name;
                break;
            case "d1":
                WhiteQueen = Instantiate(WhiteQueen, chessPosition, Quaternion.identity);
                WhiteQueen.name = "white_queen_" + tile.name;
                break;
            case "e1":
                WhiteKing = Instantiate(WhiteKing, chessPosition, Quaternion.identity);
                WhiteKing.name = "white_king_" + tile.name;
                break;
            case "a2":
            case "b2":
            case "c2":
            case "d2":
            case "e2":
            case "f2":
            case "g2":
            case "h2":
                WhitePawn = Instantiate(WhitePawn, chessPosition, Quaternion.identity);
                WhitePawn.name = "white_pawn_" + tile.name;
                break;
            case "a8":
            case "h8":
                BlackRook = Instantiate(BlackRook, chessPosition, Quaternion.identity);
                BlackRook.name = "black_rook_" + tile.name;
                break;
            case "b8":
            case "g8":
                BlackKnight = Instantiate(BlackKnight, chessPosition, Quaternion.identity);
                BlackKnight.name = "black_knight_" + tile.name;
                break;
            case "c8":
            case "f8":
                BlackBishop = Instantiate(BlackBishop, chessPosition, Quaternion.identity);
                BlackBishop.name = "black_bishop_" + tile.name;
                break;
            case "d8":
                BlackQueen = Instantiate(BlackQueen, chessPosition, Quaternion.identity);
                BlackQueen.name = "black_queen_" + tile.name;
                break;
            case "e8":
                BlackKing = Instantiate(BlackKing, chessPosition, Quaternion.identity);
                BlackKing.name = "black_king_" + tile.name;
                break;
            case "a7":
            case "b7":
            case "c7":
            case "d7":
            case "e7":
            case "f7":
            case "g7":
            case "h7":
                BlackPawn = Instantiate(BlackPawn, chessPosition, Quaternion.identity);
                BlackPawn.name = "black_pawn_" + tile.name;
                break;
            default: break;
        }
    }
}
