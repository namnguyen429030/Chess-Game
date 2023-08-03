using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessPiece
{
    internal override void FindValidMove()
    {
        base.FindValidMove();
        //Right half
        int moveIndex = 1;
        for (float i = transform.position.x + 1; i < 0; i++)
        {
            float upperHalf = transform.position.y + moveIndex;
            float lowerHalf = transform.position.y - moveIndex;
            if (upperHalf < 4)
            {
                validMoves.Add(new Vector3(i, upperHalf, -1));
            }
            if (lowerHalf > -4)
            {
                validMoves.Add(new Vector3(i, lowerHalf, -1));
            }
            moveIndex++;
        }
        moveIndex = 1;
        //Left half
        for (float i = transform.position.x - 1; i > -8; i--)
        {
            float upperHalf = transform.position.y + moveIndex;
            float lowerHalf = transform.position.y - moveIndex;
            if (upperHalf < 4)
            {
                validMoves.Add(new Vector3(i, upperHalf, -1));
            }
            if (lowerHalf > -4)
            {
                validMoves.Add(new Vector3(i, lowerHalf, -1));
            }
            moveIndex++;
        }
        //Right side
        for (float i = transform.position.x + 1; i < 0; i++)
        {
            validMoves.Add(new Vector3(i, transform.position.y, -1));
        }
        //Left side
        for (float i = transform.position.x - 1; i > -8; i--)
        {
            validMoves.Add(new Vector3(i, transform.position.y, -1));
        }
        //Upper side
        for (float i = transform.position.y + 1; i < 4; i++)
        {
            validMoves.Add(new Vector3(transform.position.x, i, -1));
        }
        //Lower side
        for (float i = transform.position.y - 1; i > -4; i--)
        {
            validMoves.Add(new Vector3(transform.position.x, i, -1));
        }
    }
}
