using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player1 : MonoBehaviour
{
    //Refrence to animator 
    public Animator animator;
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
    //Tracks the player current position
    private int currentPosition = 0;
    public int interpolationFramesCount = 45; // Number of frames to completely interpolate between the 2 positions
    int elapsedFrames = 0;
    bool diceRolled = false;
    Vector3 snake1pos;
    public string animationName;
    void Start()
    {
        //deactivate the roll button and dice
        button.gameObject.SetActive(false);
        dice.gameObject.SetActive(false);

        snake1pos = board.tileArray[2, 3].transform.position;
    }

    void StartPlayerPosition()
    {
        //move player to the first Tile
        Vector3 worldPosition = board.tileArray[currentPosition % board.width, currentPosition / board.width].transform.position;
        transform.position = worldPosition;

    }

    void PlayerMovement()
    {
        //Move player depending on the dice rolled value
        int result = dice.rollValue;
        currentPosition += result;
        float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
        //this considers the width and height of the board that the player cant go off it and will instead go to the next row 
        Vector3 worldPosition = board.tileArray[currentPosition % board.width, currentPosition / board.width].transform.position;
        // Start a coroutine to smoothly move the player
        animator.SetBool("isWalking?", true);
        StartCoroutine(MovePlayer(worldPosition));

    }

    IEnumerator MovePlayer(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        // Adjust the duration for player to reach target
        float duration = 1.0f; 

        Vector3 startingPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //the final position is exactly the target position
        transform.position = targetPosition;
        animator.SetBool("isWalking?", false);
    }

    public void Clicked()
    {
        //whenever the roll button is clicked deactivate it 
         button.gameObject.SetActive(false);
    }



    void Update()
    {
        //If the board was spawned move the player to the first Tile
        if (board.BoardGenerated && StartGame)
        {
            player1.SetActive(true);
            StartPlayerPosition();
            StartGame = false;
            button.gameObject.SetActive(true);
            dice.gameObject.SetActive(true);
            dice._rb.position = board.tileArray[5, 5].transform.position + new Vector3(0, 2, 0);
            diceRolled = true;
        }
        //If board spawned and start already happened and the dice was rolled move the player to the rolled value
        if (board.BoardGenerated && !StartGame && dice.rollDice)
        {
            PlayerMovement();
            dice.rollDice = false;
            diceRolled = true;
            dice._rb.position = board.tileArray[5, 5].transform.position + new Vector3(0, 2, 0);
        }

        if(diceRolled)
        {
            button.gameObject.SetActive(true);
            diceRolled = false;
        }

        Debug.Log(currentPosition);
        //Snake check 
        if (currentPosition == 23)
        {
            animator.SetBool("Lost?", true);
            Debug.Log("AAAAAAAAAAA");
            // Check if the specific animation is over
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            if (stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1.0f)
            {
                StartCoroutine(MovePlayer(board.tileArray[4, 0].transform.position));
                animator.SetBool("Lost?", false);
                currentPosition = 4;
                //Vector3 worldPosition = board.tileArray[0, 4].transform.position;
                //transform.position = worldPosition;
            }
        }

        //Snake 2
        if (currentPosition == 55)
        {
            animator.SetBool("Lost?", true);
            Debug.Log("AAAAAAAAAAA");
            // Check if the specific animation is over
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            if (stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1.0f)
            {
                StartCoroutine(MovePlayer(board.tileArray[6, 3].transform.position));
                currentPosition = 36;
                animator.SetBool("Lost?", false);
            }
        }

    }
}
