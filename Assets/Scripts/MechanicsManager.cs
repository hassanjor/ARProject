using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicsManager : MonoBehaviour
{

    public Board board;
    public GameObject snake;
    public GameObject snake2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (board.BoardGenerated)
        {
            snake.transform.position = board.tileArray[3, 1].transform.position + new Vector3(0.0f, 0.1f, 0.0f); 
        }

        if (board.BoardGenerated)
        {
            snake2.transform.position = board.tileArray[5, 4].transform.position + new Vector3(0.0f, 0.1f, 0.0f);
        }


    }
}
