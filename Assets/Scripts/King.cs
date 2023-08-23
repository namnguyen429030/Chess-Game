using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    public bool IsChecked { get; set; }
    internal override void FindValidMove()
    {
        base.FindValidMove();
        //Right
        if (transform.position.x < 0)
        {
            Vector3 destination1 = new Vector3(transform.position.x + 1, transform.position.y, -1);
            Vector3 destination2 = new Vector3(transform.position.x + 1, transform.position.y + 1, -1);
            Vector3 destination3 = new Vector3(transform.position.x + 1, transform.position.y - 1, -1);
            if(!CheckBlockedSameSide(destination1)){
                validMoves.Add(destination1);
            }
            if(transform.position.y < 3 && !CheckBlockedSameSide(destination2))
            { 
                validMoves.Add(destination2);
            }
            if(transform.position.y > -3 && !CheckBlockedSameSide(destination3))
            {
                validMoves.Add(destination3);
            }
        }
        //Left
        if (transform.position.x > -7)
        {
            Vector3 destination1 = new Vector3(transform.position.x - 1, transform.position.y, -1);
            Vector3 destination2 = new Vector3(transform.position.x - 1, transform.position.y + 1, -1);
            Vector3 destination3 = new Vector3(transform.position.x - 1, transform.position.y - 1, -1);
            if (!CheckBlockedSameSide(destination1)) 
            {  
                validMoves.Add(destination1); 
            }
            if(transform.position.y < 3 && !CheckBlockedSameSide(destination2))
            {
                validMoves.Add(destination2);
            }
            if(transform.position.y > -3 && !CheckBlockedSameSide(destination3))
            {
                validMoves.Add(destination3);
            }
        }
        //Upper
        if (transform.position.y < 3)
        {
            Vector3 destination = new Vector3(transform.position.x, transform.position.y + 1, -1);
            if (!CheckBlockedSameSide(destination)) 
            { 
                validMoves.Add(destination); 
            }
        }
        //Lower
        if (transform.position.y > -3)
        {
            Vector3 destination = new Vector3(transform.position.x, transform.position.y - 1, -1);
            if (!CheckBlockedSameSide(destination))
            {
                validMoves.Add(destination);
            }
        }
    }
}
