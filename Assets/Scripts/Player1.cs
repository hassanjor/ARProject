using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player1 : MonoBehaviour
{
    //Refrence to hide rolling the dice button 
    public Button button;
    //Board refrence 
    public Board board;
    //Dice reference 
    public Dice dice;
    //reference to the player object
    public GameObject player1;
    //determines if player should be in starting game position
    private bool StartGame = true;

    private bool DiceFinished = true; // Set to true initially
    //Tracks the player current position
    private int currentPosition = 0;
   
    void Start()
    {
        button.gameObject.SetActive(false);
        dice.gameObject.SetActive(false);
    }

    void StartPlayerPosition()
    {
        Vector3 worldPosition = board.tileArray[currentPosition % board.width, currentPosition / board.width].transform.position;
        transform.position = worldPosition;
    }

    void PlayerMovement()
    {
        int result = dice.rollValue;
        currentPosition += result;
        Vector3 worldPosition = board.tileArray[currentPosition % board.width, currentPosition / board.width].transform.position;
        transform.position = worldPosition;

    }
    
    public void Clicked()
    {
        button.gameObject.SetActive(false);
    }

    void Update()
    {

        if (board.BoardGenerated && StartGame)
        {
            player1.SetActive(true);
            StartPlayerPosition();
            StartGame = false;
            button.gameObject.SetActive(true);
            dice.gameObject.SetActive(true);
            dice._rb.position = board.tileArray[5, 5].transform.position + new Vector3(0, 2, 0);
        }

        if (board.BoardGenerated && !StartGame && dice.rollDice)
        {
            PlayerMovement();
            dice.rollDice = false;

        }

    }
}
