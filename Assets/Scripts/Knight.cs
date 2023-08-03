using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    internal override void FindValidMove()
    {
        base.FindValidMove();
        //Upper
        if(transform.position.y < 2)
        {
            if(transform.position.x > -7)
            {
                validMoves.Add(new Vector3(transform.position.x - 1, transform.position.y + 2, -1));
            }
            if(transform.position.x < -1)
            {
                validMoves.Add(new Vector3(transform.position.x + 1, transform.position.y + 2, -1));
            }
        }
        //Lower
        if (transform.position.y > -2)
        {
            if (transform.position.x > -7)
            {
                validMoves.Add(new Vector3(transform.position.x - 1, transform.position.y - 2, -1));
            }
            if (transform.position.x < -1)
            {
                validMoves.Add(new Vector3(transform.position.x + 1, transform.position.y - 2, -1));
            }
        }
        //Right
        if (transform.position.x < -2)
        {
            if (transform.position.y > -3)
            {
                validMoves.Add(new Vector3(transform.position.x + 2, transform.position.y - 1, -1));
            }
            if (transform.position.y < 3)
            {
                validMoves.Add(new Vector3(transform.position.x + 2, transform.position.y + 1, -1));
            }
        }
        //Left
        if (transform.position.x > -6)
        {
            if (transform.position.y > -3)
            {
                validMoves.Add(new Vector3(transform.position.x - 2, transform.position.y - 1, -1));
            }
            if (transform.position.y < 3)
            {
                validMoves.Add(new Vector3(transform.position.x - 2, transform.position.y + 1, -1));
            }
        }
    }
}
