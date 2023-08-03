using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    internal override void FindValidMove()
    {
        base.FindValidMove();
        //Right
        validMoves.Add(new Vector3(transform.position.x + 1, transform.position.y, -1));
        validMoves.Add(new Vector3(transform.position.x + 1, transform.position.y + 1, -1));
        validMoves.Add(new Vector3(transform.position.x + 1, transform.position.y - 1, -1));
        //Left
        validMoves.Add(new Vector3(transform.position.x - 1, transform.position.y, -1));
        validMoves.Add(new Vector3(transform.position.x - 1, transform.position.y + 1, -1));
        validMoves.Add(new Vector3(transform.position.x - 1, transform.position.y - 1, -1));
        //Upper
        validMoves.Add(new Vector3(transform.position.x, transform.position.y + 1, -1));
        //Lower
        validMoves.Add(new Vector3(transform.position.x, transform.position.y - 1, -1));
    }
}
