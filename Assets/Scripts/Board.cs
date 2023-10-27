using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    private PlaceIndicator placeindicator;
    [SerializeField] private GameObject Parent; 
    // width and height 
    [SerializeField] private int width = 0, height = 0;
    // the planes making the board
    [SerializeField] private Tile tileprefab;

    bool clicked = false;




    void Start()
    {
        placeindicator = FindObjectOfType<PlaceIndicator>();
    }

   public void onClicked()
    {
        clicked = true;
       
    }

    void Update()
    {
        if (clicked)
        {
            GenerateBoard();
            clicked = false;
        }
    }
    public void GenerateBoard()
    {

        //Making the board
        // X and Y are flipped because in the editor doing it this way looks correct
        //all the x is alligned next to each other while they is the up and down
        for (int y = 0; y < width; y++)
        {
            for(int x = 0; x < height; x++)
            {
                //instansiate
                var spawnedTile = Instantiate(tileprefab, placeindicator.transform.position + new Vector3(x, -13, y), Quaternion.identity, Parent.transform);


                //print the tiles with the spot number
                spawnedTile.name = $"Tile {x} {y}";

                //Material change logic. (%) might look scary look it up to understand
                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);

              
            }
        }
        

    }



}
