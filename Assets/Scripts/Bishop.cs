using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessPiece
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
    }
}
