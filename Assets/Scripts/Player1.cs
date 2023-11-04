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
    public  bool StartGame = true;
    //Tracks the player current position
    public int currentPosition = 0;
    //emulator stuff for lerping 
    public int interpolationFramesCount = 45; 
    public int elapsedFrames = 0;

    //manipulates button spawning
    public bool diceRolled = false;
    //both static variables so the values stay the same in parent and child
    public static bool Player1Turn = true;
    public static bool Player2Turn = false;
    //animations references to detect when they are done
    public string animationName;
    public string ladderAnimationName;
    void Start()
    {
        //deactivate the roll button, and dice
        button.gameObject.SetActive(false);
        dice.gameObject.SetActive(false);
    }

   public void StartPlayerPosition()
    {
        //move player to the first Tile
        Vector3 worldPosition = board.tileArray[currentPosition % board.width, currentPosition / board.width].transform.position;
        transform.position = worldPosition;

    }

    public void PlayerMovement()
    {
        //Move player depending on the dice rolled value
        int result = dice.rollValue;
        //+= adds onto it so it always is saving the position
        currentPosition += result;
        //lerping using a value
        float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
        //this considers the width and height of the board that the player cant go off it and will instead go to the next row 
        Vector3 worldPosition = board.tileArray[currentPosition % board.width, currentPosition / board.width].transform.position;
        //set is walking to true so the animation plays
        animator.SetBool("isWalking?", true);
        // Start a coroutine to smoothly move the player
        StartCoroutine(MovePlayer(worldPosition));

    }

  public IEnumerator MovePlayer(Vector3 targetPosition)
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
        //back to idle
        animator.SetBool("isWalking?", false);
    }

    public void Clicked()
    {
        //whenever the roll button is clicked deactivate it 
         button.gameObject.SetActive(false);
    }



    void Update()
    {
        //dont check any of this unless its player 1 turn
        //first time will always be player 1 turn 
        if (Player1Turn == true)
        {
            Debug.Log(currentPosition);

            //If the board was spawned move the player to the first Tile
            //and move the dice to the middle
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
                //re position the dice at the middle after
                dice._rb.position = board.tileArray[5, 5].transform.position + new Vector3(0, 2, 0);
                //change turns
                Player1Turn = false;
                Player2Turn = true;

            }
            //manipulating button appearing
            if (diceRolled)
            {
                button.gameObject.SetActive(true);
                diceRolled = false;
            }


            //Snake check 
            if (currentPosition == 23)
            {
                //this is important as it makes sure the player moves to the intended position
                //before the next turn starts
                Player1Turn = true;
                Player2Turn = false;
                //disable button
                button.gameObject.SetActive(false);
                //play the sad animation
                animator.SetBool("Lost?", true);
                Debug.Log("AAAAAAAAAAA");

                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                // Check if the sad animation is over
                if (stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1.0f)
                {
                    //move player down to snake tail
                    StartCoroutine(MovePlayer(board.tileArray[4, 0].transform.position));
                    //set current position to the position player was moved to 
                    currentPosition = 4;
                    //stop sad animation
                    animator.SetBool("Lost?", false);
                    //activate button again
                    button.gameObject.SetActive(true);
                    //change turns
                    Player1Turn = false;
                    Player2Turn = true;
                }
               

            }

            //Snake 2
            if (currentPosition == 55)
            {
                //this is important as it makes sure the player moves to the intended position
                //before the next turn starts
                Player1Turn = true;
                Player2Turn = false;
                //disable button
                button.gameObject.SetActive(false);
                //play the sad animation
                animator.SetBool("Lost?", true);
                Debug.Log("AAAAAAAAAAA");
                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                // Check if the specific animation is over
                if (stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1.0f)
                {
                    //move player down to snake tail
                    StartCoroutine(MovePlayer(board.tileArray[6, 3].transform.position));
                    //set current position to the position player was moved to 
                    currentPosition = 36;
                    //stop sad animation
                    animator.SetBool("Lost?", false);
                    //activate button again
                    button.gameObject.SetActive(true);
                    //change turns
                    Player1Turn = false;
                    Player2Turn = true;
                }
              

            }

            //snake 3 check
            if (currentPosition == 96)
            {
                //this is important as it makes sure the player moves to the intended position
                //before the next turn starts
                Player1Turn = true;
                Player2Turn = false;
                //disable button
                button.gameObject.SetActive(false);
                //play the sad animation
                animator.SetBool("Lost?", true);
                Debug.Log("AAAAAAAAAAA");
                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                // Check if the specific animation is over
                if (stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1.0f)
                {
                    //move player down to snake tail
                    StartCoroutine(MovePlayer(board.tileArray[7, 7].transform.position));
                    //set current position to the position player was moved to 
                    currentPosition = 77;
                    //stop sad animation
                    animator.SetBool("Lost?", false);
                    //activate button again
                    button.gameObject.SetActive(true);
                    //change turns
                    Player1Turn = false;
                    Player2Turn = true;
                }


            }

            //Ladder check
            if (currentPosition == 7)
            {
                //this is important as it makes sure the player moves to the intended position
                //before the next turn starts
                Player1Turn = true;
                Player2Turn = false;
                //disable button
                button.gameObject.SetActive(false);
                //play the happy animation
                animator.SetBool("Victory?", true);
                Debug.Log("YAYYYYYY");

                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                // Check if the specific animation is over
                if (stateInfo.IsName(ladderAnimationName) && stateInfo.normalizedTime >= 1.0f)
                {
                    //move player up the ladder
                    StartCoroutine(MovePlayer(board.tileArray[7, 2].transform.position));
                    //set current position to the position player was moved to 
                    currentPosition = 27;
                    //stop happy animation
                    animator.SetBool("Victory?", false);
                    //activate button again
                    button.gameObject.SetActive(true);
                    //change turns
                    Player1Turn = false;
                    Player2Turn = true;
                }
            }

                //Ladder2 check 
                if (currentPosition == 50)
                {
                    //this is important as it makes sure the player moves to the intended position
                    //before the next turn starts
                    Player1Turn = true;
                    Player2Turn = false;
                    //disable button
                    button.gameObject.SetActive(false);
                    //play the happy animation
                    animator.SetBool("Victory?", true);
                    Debug.Log("YAYYYYYY");

                    AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                    // Check if the specific animation is over
                    if (stateInfo.IsName(ladderAnimationName) && stateInfo.normalizedTime >= 1.0f)
                    {
                        //move player up the ladder
                        StartCoroutine(MovePlayer(board.tileArray[0, 7].transform.position));
                        //set current position to the position player was moved to 
                        currentPosition = 70;
                        //stop happy animation
                        animator.SetBool("Victory?", false);
                        //activate button again
                        button.gameObject.SetActive(true);
                        //change turns
                        Player1Turn = false;
                        Player2Turn = true;
                    }

                }

        }
    }
}
