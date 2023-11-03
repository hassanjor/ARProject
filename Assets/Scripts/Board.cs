using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    private PlaceIndicator placeIndicator;
    public Button button;
    public GameObject Indicator;

    [SerializeField] public GameObject Parent; 
    // width and height 
    [SerializeField] public int width = 0, height = 0;
    // the planes making the board
    [SerializeField] public Tile tileprefab;

    public bool BoardGenerated = false;

    public bool clicked = false;

    //Array of tiles
    public Tile[,] tileArray;

    void Start()
    {
        placeIndicator = FindObjectOfType<PlaceIndicator>();
    }

    //Generate the board when the button is clicked
    public void Clicked()
    {
        GenerateBoard();
        BoardGenerated = true;

        button.gameObject.SetActive(false);
        Indicator.SetActive(false);

        Destroy(Indicator);
        Destroy(button);



    }

    public void GenerateBoard()
    {
        //array so we can check each tile individually 
        tileArray = new Tile[width, height];

        //Making the board
        // X and Y are flipped because in the editor doing it this way looks correct
        //all the x is alligned next to each other while they is the up and down
        for (int y = 0; y < width; y++)
        {
            for(int x = 0; x < height; x++)
            {
                //instansiate
                var spawnedTile = Instantiate(tileprefab, placeIndicator.transform.position + new Vector3(x - 5, -13, y - 5), Quaternion.identity, Parent.transform);
             

                //print the tiles with the spot number
                spawnedTile.name = $"Tile {x} {y}";

                //Material change logic. (%) might look scary look it up to understand
                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);

                // Store the tile in the array, again notice the flipping of x and y
                tileArray[y, x] = spawnedTile;
            }
        }
    }



}
