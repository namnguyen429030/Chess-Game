using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    internal override void FindValidMove()
    {
        base.FindValidMove();
        string side = name.Split("_")[0];
        switch(side)
        {
            case "white":
                if(transform.position.y == -2.5)
                {
                    validMoves.Add(new Vector3(transform.position.x, transform.position.y + 2, -1));
                }
                validMoves.Add(new Vector3(transform.position.x, transform.position.y + 1, -1));
                break;
            case "black":
                if(transform.position.y == 2.5)
                {
                    validMoves.Add(new Vector3(transform.position.x, transform.position.y - 2, -1));
                }
                validMoves.Add(new Vector3(transform.position.x, transform.position.y - 1, -1));
                break;
        }
    }
}
