using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    internal override void FindValidMove()
    {
        base.FindValidMove();
        //Right
        if (transform.position.x < 0)
        {
            validMoves.Add(new Vector3(transform.position.x + 1, transform.position.y, -1));
            if(transform.position.y < 3)
            { 
                validMoves.Add(new Vector3(transform.position.x + 1, transform.position.y + 1, -1));
            }
            if(transform.position.y > -3)
            {
                validMoves.Add(new Vector3(transform.position.x + 1, transform.position.y - 1, -1));
            }
        }
        //Left
        if (transform.position.x > -7)
        {
            validMoves.Add(new Vector3(transform.position.x - 1, transform.position.y, -1));
            if(transform.position.y < 3)
            {
                validMoves.Add(new Vector3(transform.position.x - 1, transform.position.y + 1, -1));
            }
            if(transform.position.y > -3)
            {
                validMoves.Add(new Vector3(transform.position.x - 1, transform.position.y - 1, -1));
            }
        }
        //Upper
        if (transform.position.y < 3)
        {
            validMoves.Add(new Vector3(transform.position.x, transform.position.y + 1, -1));
        }
        //Lower
        if (transform.position.y > -3)
        {
            validMoves.Add(new Vector3(transform.position.x, transform.position.y - 1, -1));
        }
    }
}
