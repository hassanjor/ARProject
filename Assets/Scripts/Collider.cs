using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    //refrence to board
    public Board board;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //only if the board is generated put colliders around it so the dice doesnt fall off
        if(board.BoardGenerated)
        {
            transform.position = board.tileArray[4, 9].transform.position;
        }
        
    }
}
