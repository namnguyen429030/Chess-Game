using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pawn : ChessPiece
{
    internal bool CanEnpassantRight { get; set; } = false;
    internal bool CanEnpassantLeft { get; set; } = false;
    internal bool CanEnpassantRightAnyMore { get; set; } = true;
    internal bool CanEnpassantLeftAnyMore { get; set; } = true;
    internal override void FindValidMove()
    {
        base.FindValidMove();
        string side = name.Split("_")[0];
        switch(side)
        {
            case "white":
                if(transform.position.y == -2.5)
                {
                    validMoves.Add(new Vector3(transform.position.x, transform.position.y + 2, -1));
                }
                if (CanEnpassantLeft)
                {
                    validMoves.Add(new Vector3(transform.position.x - 1, transform.position.y + 1, -1));
                }
                if (CanEnpassantRight)
                {
                    validMoves.Add(new Vector3(transform.position.x + 1, transform.position.y + 1, -1));
                }
                validMoves.Add(new Vector3(transform.position.x, transform.position.y + 1, -1));
                break;
            case "black":
                if(transform.position.y == 2.5)
                {
                    validMoves.Add(new Vector3(transform.position.x, transform.position.y - 2, -1));
                }
                if (CanEnpassantLeft)
                {
                    validMoves.Add(new Vector3(transform.position.x - 1, transform.position.y - 1, -1));
                }
                if (CanEnpassantRight)
                {
                    validMoves.Add(new Vector3(transform.position.x + 1, transform.position.y - 1, -1));
                }
                validMoves.Add(new Vector3(transform.position.x, transform.position.y - 1, -1));
                break;
        }
    }
    internal override void OnMouseUp()
    {
        base.OnMouseUp();
        string side = name.Split("_")[0];
        switch (side)
        {
            case "white":
                if (transform.position.y == -0.5)
                {
                    Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
                    Collider2D rightPiece = Physics2D.OverlapPoint(currentPos + new Vector2(1, 0));
                    Collider2D leftPiece = Physics2D.OverlapPoint(currentPos + new Vector2(-1, 0));
                    if (rightPiece != null && rightPiece.CompareTag("Piece"))
                    {
                        string[] rightPieceDef = rightPiece.name.Split("_");
                        Debug.Log(rightPieceDef[1] + " " + rightPieceDef[0]);
                        if (rightPieceDef[1] == "pawn" && rightPieceDef[0] == "black")
                        {
                            Pawn pawn = rightPiece.GetComponent<Pawn>();
                            Debug.Log("accepted");
                            if (pawn.CanEnpassantLeftAnyMore)
                            {
                                Debug.Log("can enpassant");
                                pawn.CanEnpassantLeft = true;
                                pawn.CanEnpassantLeftAnyMore = false;
                            }
                        }
                    }
                    if (leftPiece != null && leftPiece.CompareTag("Piece"))
                    {
                        string[] leftPieceDef = leftPiece.name.Split("_");
                        Debug.Log(leftPieceDef[1] + " "+ leftPieceDef[0]);
                        if (leftPieceDef[1] == "pawn" && leftPieceDef[0] == "black")
                        {
                            Pawn pawn = leftPiece.GetComponent<Pawn>();
                            Debug.Log("accepted");
                            if (pawn.CanEnpassantRightAnyMore)
                            {
                                Debug.Log("can enpassant");
                                pawn.CanEnpassantRight = true;
                                pawn.CanEnpassantRightAnyMore = false;
                            }
                        }
                    }
                }
                break;
            case "black":
                if (transform.position.y == 0.5)
                {
                    Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
                    Collider2D rightPiece = Physics2D.OverlapPoint(currentPos + new Vector2(1, 0));
                    Collider2D leftPiece = Physics2D.OverlapPoint(currentPos + new Vector2(-1, 0));
                    if (rightPiece != null && rightPiece.CompareTag("Piece"))
                    {
                        string[] rightPieceDef = rightPiece.name.Split("_");
                        Debug.Log(rightPieceDef[1] + " " + rightPieceDef[0]);
                        if (rightPieceDef[1] == "pawn" && rightPieceDef[0] == "white")
                        {
                            Pawn pawn = rightPiece.GetComponent<Pawn>();
                            Debug.Log("accepted");
                            if (pawn.CanEnpassantLeftAnyMore)
                            {
                                Debug.Log("can enpassant");
                                pawn.CanEnpassantLeft = true;
                                pawn.CanEnpassantLeftAnyMore = false;
                            }
                        }
                    }
                    if (leftPiece != null && leftPiece.CompareTag("Piece"))
                    {
                        string[] leftPieceDef = leftPiece.name.Split("_");
                        Debug.Log(leftPieceDef[1] + " " + leftPieceDef[0]);
                        if (leftPieceDef[1] == "pawn" && leftPieceDef[0] == "white")
                        {
                            Pawn pawn = leftPiece.GetComponent<Pawn>();
                            Debug.Log("accepted");
                            if (pawn.CanEnpassantRightAnyMore)
                            {
                                Debug.Log("can enpassant");
                                pawn.CanEnpassantRight = true;
                                pawn.CanEnpassantRightAnyMore = false;
                            }
                        }
                    }
                }
                break;
        }
    }
}
