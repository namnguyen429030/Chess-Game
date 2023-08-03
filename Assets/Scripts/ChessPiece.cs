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
}
