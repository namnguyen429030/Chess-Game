using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Rook
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
        //Right side
        for (float i = transform.position.x + 1; i < 0; i++)
        {
            Vector3 destionation = new Vector3(i, transform.position.y, -1);
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
        }
        //Left side
        for (float i = transform.position.x - 1; i > -8; i--)
        {
            Vector3 destionation = new Vector3(i, transform.position.y, -1);
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
        }
        //Upper side
        for (float i = transform.position.y + 1; i < 4; i++)
        {
            Vector3 destionation = new Vector3(transform.position.x, i, -1);
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
        }
        //Lower side
        for (float i = transform.position.y - 1; i > -4; i--)
        {
            Vector3 destionation = new Vector3(transform.position.x, i, -1);
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
        }
    }
}
