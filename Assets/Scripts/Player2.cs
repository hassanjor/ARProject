using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : Player1
{

  
    // Start is called before the first frame update
    void Start()
    {
        //deactivate the roll button, and dice
        button.gameObject.SetActive(false);
        dice.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
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
        if (Player2Turn == true)
        {
            //If board spawned and start already happened and the dice was rolled move the player to the rolled value
            if (board.BoardGenerated && !StartGame && dice.rollDice)
            {
                PlayerMovement();
                dice.rollDice = false;
                diceRolled = true;
                //re position the dice at the middle after
                dice._rb.position = board.tileArray[5, 5].transform.position + new Vector3(0, 2, 0);
                Player1Turn = true;
                Player2Turn = false;
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
                Player1Turn = false;
                Player2Turn = true;
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
                    Player2Turn = false;
                    Player1Turn = true;
                }
             
            }

            //Snake 2
            if (currentPosition == 55)
            {
                Player1Turn = false;
                Player2Turn = true;
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
                    Player2Turn = false;
                    Player1Turn = true;
                }
               
            }

            //Ladder check
            if (currentPosition == 7)
            {
                Player1Turn = false;
                Player2Turn = true;
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
                    Player2Turn = false;
                    Player1Turn = true;
                }
               
            }

        }
    }
}
