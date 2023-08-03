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
            Vector3 destionation = new Vector3(i, transform.position.y, -1);
            if (CheckBlocked(destionation))
            {
                break;
            }
            validMoves.Add(destionation);
        }
        //Left side
        for (float i = transform.position.x - 1; i > -8; i--)
        {
            Vector3 destionation = new Vector3(i, transform.position.y, -1);
            if (CheckBlocked(destionation))
            {
                break;
            }
            validMoves.Add(destionation);
        }
        //Upper side
        for (float i = transform.position.y + 1; i < 4 ; i++)
        {
            Vector3 destionation = new Vector3(transform.position.x, i, -1);
            if (CheckBlocked(destionation))
            {
                break;
            }
            validMoves.Add(destionation);
        }
        //Lower side
        for (float i = transform.position.y - 1; i> -4 ; i--)
        {
            Vector3 destionation = new Vector3(transform.position.x, i, -1);
            if (CheckBlocked(destionation))
            {
                break;
            }
            validMoves.Add(destionation);
        }
    }
}
