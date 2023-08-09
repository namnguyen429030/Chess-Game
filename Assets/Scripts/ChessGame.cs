using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessGame : MonoBehaviour
{
    [SerializeField]
    private GameObject board;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(board, new Vector3(0,0,0), Quaternion.identity);
    }
}
