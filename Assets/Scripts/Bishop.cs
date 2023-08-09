using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessPiece
{
    internal override void FindValidMove()
    {
        base.FindValidMove();
        //Quarter 1
        float j = transform.position.y + 1;
        for (float i = transform.position.x + 1; i < 0 && j < 4; i++)
        {
            Vector3 destionation = new Vector3(i, j, -1);
            if (CheckBlockedSameSide(destionation))
            {
                break;
            }
            if (CheckBlockedDifferentSide(destionation))
            {
                validMoves.Add(destionation);
                break;
            }
            validMoves.Add(destionation);
            j++;
        }
        //Quarter 2
        j = transform.position.y - 1;
        for (float i = transform.position.x + 1; i < 0 && j > -4; i++)
        {
            Vector3 destionation = new Vector3(i, j, -1);
            if (CheckBlockedSameSide(destionation))
            {
                break;
            }
            if (CheckBlockedDifferentSide(destionation))
            {
                validMoves.Add(destionation);
                break;
            }
            validMoves.Add(destionation); j--;
        }
        //Quarter 3
        j = transform.position.y + 1;
        for (float i = transform.position.x - 1; i > -8 && j < 4; i--)
        {
            Vector3 destionation = new Vector3(i, j, -1);
            if (CheckBlockedSameSide(destionation))
            {
                break;
            }
            if (CheckBlockedDifferentSide(destionation))
            {
                validMoves.Add(destionation);
                break;
            }
            validMoves.Add(destionation); j++;
        }
        //Quarter 4
        j = transform.position.y - 1;
        for (float i = transform.position.x - 1; i > -8 && j > -4; i--)
        {
            Vector3 destionation = new Vector3(i, j, -1);
            if (CheckBlockedSameSide(destionation))
            {
                break;
            }
            if (CheckBlockedDifferentSide(destionation))
            {
                validMoves.Add(destionation);
                break;
            }
            validMoves.Add(destionation); j--;
        }
    }
}
