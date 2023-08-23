using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class ChessGame : MonoBehaviour
{
    [SerializeField]
    private GameObject board;
    public Time Duration { get; set; }
    public bool IsEndTurn { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(board, new Vector3(0, 0, 0), Quaternion.identity);
        SwitchTurn("black");
    }
    void Update()
    {
        
    }
    public void SwitchTurn(string side)
    {
        List<ChessPiece> pieces = GameObject.FindGameObjectsWithTag("Piece").Select(p => p.GetComponent<ChessPiece>()).ToList();
        foreach(ChessPiece piece in pieces)
        {
            if(piece.Side == side)
            {
                piece.validMoves.Clear();
            }
            if(piece is Pawn)
            {
                Pawn pawn = piece as Pawn;
                pawn.CanEnpassantLeft = false;
                pawn.CanEnpassantRight = false;
            }
        }
    }
}
