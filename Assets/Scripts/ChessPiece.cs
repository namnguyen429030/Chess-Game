using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;


public class ChessPiece : MonoBehaviour
{
    internal float timeMouseClick;
    internal Vector3 currentPos;
    private Vector3 difference = Vector3.zero;
    internal List<Vector3> validMoves = new List<Vector3>();
    internal int moveIndex;
    internal Vector3 oldPosition;
    private void OnMouseDown()
    {
        FindValidMove();
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        timeMouseClick = Time.time;
        currentPos = transform.position;
    }
    internal virtual void OnMouseUp()
    {
        Vector3 destination = AdjustPosition(transform.position);
        if (!IsValidMove(destination)) 
        { 
            transform.position = currentPos;
        }
        else
        {
            oldPosition = currentPos;
            transform.position = destination;
            List<GameObject> pawnsObject = GameObject.FindGameObjectsWithTag("Piece").Where(p => p.name.Split("_")[1] == "pawn").ToList();
            foreach(GameObject pawnObject in pawnsObject)
            {
                Pawn pawn = pawnObject.GetComponent<Pawn>();
                pawn.CanEnpassantLeft = false;
                pawn.CanEnpassantRight = false;
            }
        }
    }
    private void OnMouseDrag()
    {
        float timeMouseHolding = Time.time;
        if (timeMouseHolding - timeMouseClick > 0.1f)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
        }
    }
    internal bool IsValidMove(Vector3 destination)
    {
        return validMoves.Contains(destination);
    }
    internal virtual void FindValidMove()
    {
        validMoves.Clear();
    }
    internal bool CheckBlockedSameSide(Vector3 coordinate)
    {
        Vector2 coordinate2d = new Vector2(coordinate.x, coordinate.y);
        Collider2D collider = Physics2D.OverlapPoint(coordinate2d);
        string thisSide = name.Split("_")[0];
        string side = "";
        if (collider != null && collider.CompareTag("Piece"))
        {
            side = collider.name.Split("_")[0];
            return thisSide == side;
        }
        return false;
    }
    internal bool CheckBlockedDifferentSide(Vector3 coordinate)
    {
        Vector2 coordinate2d = new Vector2(coordinate.x, coordinate.y);
        Collider2D collider = Physics2D.OverlapPoint(coordinate2d);
        string thisSide = name.Split("_")[0];
        string side = "";
        if (collider.CompareTag("Piece"))
        {
            side = collider.name.Split("_")[0];
            return thisSide != side;
        }
        return false;
    }
    internal Vector3 AdjustPosition(Vector3 position)
    {
        if(position.x < 0)
        {
            position.x = (int) position.x - (float)0.5;
        }
        else
        {
            position.x = (int)position.x + (float)0.5;
        }
        if (position.y < 0)
        {
            position.y = (int)position.y - (float)0.5;
        }
        else
        {
            position.y = (int)position.y + (float)0.5;
        }
        return position;
    }
}
