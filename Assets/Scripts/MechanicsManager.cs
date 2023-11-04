using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicsManager : MonoBehaviour
{
    //this class only positions the mechanics at the right position 


    //refrence to the board
    public Board board;
    //traps mechanics
    public GameObject snake;
    public GameObject snake2;
    public GameObject snake3;
    public GameObject ladder;
    public GameObject ladder2;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        //locations for all mechanics 
        if (board.BoardGenerated)
        {
            snake.transform.position = board.tileArray[3, 1].transform.position + new Vector3(0.0f, 0.1f, 0.0f);
           
        }

        if (board.BoardGenerated)
        {
            snake2.transform.position = board.tileArray[5, 4].transform.position + new Vector3(0.0f, 0.1f, 0.0f);
           
        }

        if (board.BoardGenerated)
        {
            snake3.transform.position = board.tileArray[6, 8].transform.position + new Vector3(0.0f, 0.1f, 0.0f);

        }

        if (board.BoardGenerated)
        {
            ladder.transform.position = board.tileArray[7, 1].transform.position + new Vector3(0.0f, 0.1f, 0.0f);
            
        }


        if (board.BoardGenerated)
        {
            ladder2.transform.position = board.tileArray[0, 6].transform.position + new Vector3(0.0f, 0.1f, 0.0f);

        }

    }
}
