using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;


public class ChessPiece : MonoBehaviour
{
    private float timeMouseClick;
    private Vector3 currentPos;
    private Vector3 difference = Vector3.zero;
    internal List<Vector3> validMoves = new List<Vector3>();
    internal int moveIndex;
    // Update is called once per frame
    private void OnMouseDown()
    {
        FindValidMove();
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        timeMouseClick = Time.time;
        currentPos = transform.position;
        foreach (Vector3 move in validMoves)
        {
            Debug.Log(move.x + " " + move.y);
        }
    }
    private void OnMouseUp()
    {
        if (!IsValidMove(transform.position)) 
        { 
            transform.position = currentPos;
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
    internal bool CheckBlocked(Vector3 coordinate)
    {
        Vector2 coordinate2d = new Vector2(coordinate.x, coordinate.y);
        Collider2D collider = Physics2D.OverlapPoint(coordinate2d);
        string thisSide = name.Split("_")[0];
        string side = "";
        if (collider != null && collider.CompareTag("Piece"))
        {
            side = collider.name.Split("_")[0];
            Debug.Log("Blocked at"+" " + collider.transform.position.x + " " + collider.transform.position.y);
            return thisSide == side;
        }
        Debug.Log(thisSide + " " + side);
        return false;
    }
}
