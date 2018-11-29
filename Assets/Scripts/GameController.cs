using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //making a boolean for game being paused
    private bool gamePaused;

    // Use this for initialization
    void Start()
    {
        // game isn't paused at the start
        gamePaused = false;
    }


    // Update is called once per frame
    void Update()
    {
        //If escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if game isn't paused
            if (gamePaused == false)
            {
                //pauses the game and makes boolean true
                Time.timeScale = 0;
                gamePaused = true;
            }
            //if boolean true (game is paused) and escape key is pressed
            else if (gamePaused == true)
            {
                //Game unpauses and boolean set back to false
                Time.timeScale = 1;
                gamePaused = false;
            }
        }
    }
}
