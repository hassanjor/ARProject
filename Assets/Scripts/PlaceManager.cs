using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaceManager : MonoBehaviour
{
    private PlaceIndicator placeIndicator;
    public GameObject ObjectToPlace;
    public GameObject Indicator;
    public Board board;
    private GameObject newPlacedObject;
    bool clicked = false;
    public Button button;
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
        
        button.gameObject.SetActive(false);
        Indicator.SetActive(false);

        Destroy(board.Parent);
        Destroy(Indicator);
        Destroy(button);

        newPlacedObject = Instantiate(ObjectToPlace, placeIndicator.transform.position, placeIndicator.transform.rotation);
        
    }

}
