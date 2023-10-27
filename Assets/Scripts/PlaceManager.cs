using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceManager : MonoBehaviour
{
    private PlaceIndicator placeIndicator;
    public GameObject ObjectToPlace;
   // public GameObject gameobject;
    public Board board;
    private GameObject newPlacedObject;
    bool clicked = false;
    // Start is called before the first frame update
    void Start()
    {
        placeIndicator = FindObjectOfType<PlaceIndicator>();
        Board board = GetComponent<Board>();
    }


    public void Clicked()
    {
        clicked = true;
        board.GenerateBoard();
        //Destroy(board.Parent);
        newPlacedObject = Instantiate(ObjectToPlace, placeIndicator.transform.position, placeIndicator.transform.rotation);
        
    }

}
