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
    public ChessGame ChessGame { get; private set; }
    public string Side { get; private set; }
    internal void Awake()
    {
        ChessGame = GameObject.FindGameObjectWithTag("MainGame").GetComponent<ChessGame>();
        Side = name.Split('_')[0];
        FindValidMove();
    }
    private void OnMouseDown()
    {
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
            ChessGame.SwitchTurn(Side);
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
        string side;
        if (collider != null && collider.CompareTag("Piece"))
        {
            side = collider.name.Split("_")[0];
            return Side == side;
        }
        return false;
    }
    internal bool CheckBlockedDifferentSide(Vector3 coordinate)
    {
        Vector2 coordinate2d = new Vector2(coordinate.x, coordinate.y);
        Collider2D collider = Physics2D.OverlapPoint(coordinate2d);
        string side;
        if (collider != null && collider.CompareTag("Piece"))
        {
            side = collider.name.Split("_")[0];
            return Side != side;
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
    internal void Captured(Vector3 destination)
    {
        Vector2 destination2d = new Vector2(destination.x, destination.y);
        Collider2D target = Physics2D.OverlapPoint(destination2d);
        Destroy(target.gameObject);
    }
    internal void OnDestroy()
    {
        
    }
}
