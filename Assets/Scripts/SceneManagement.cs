using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
   
    
   public void Restart()
    {
        SceneManager.LoadScene("BlankAR");
    }

    //if quit button is presses leave the game/editor 
    public void EndGame()
    {
        //Quits actual build version of the game
        Application.Quit();

    }
}
