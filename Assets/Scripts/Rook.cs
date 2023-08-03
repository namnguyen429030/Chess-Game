using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece
{
    internal override void FindValidMove()
    {
        base.FindValidMove();
        //Right side
        for(float i = transform.position.x + 1; i < 0; i++)
        {
            validMoves.Add(new Vector3(i, transform.position.y, -1));
        }
        //Left side
        for (float i = transform.position.x - 1; i > -8; i--)
        {
            validMoves.Add(new Vector3(i, transform.position.y, -1));
        }
        //Upper side
        for (float i = transform.position.y + 1; i < 4 ; i++)
        {
            validMoves.Add(new Vector3(transform.position.x, i, -1));
        }
        //Lower side
        for (float i = transform.position.y - 1; i> -4 ; i--)
        {
            validMoves.Add(new Vector3(transform.position.x, i, -1));
        }
    }
}
