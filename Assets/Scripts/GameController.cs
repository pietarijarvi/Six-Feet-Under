using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //making a boolean for game being paused
    private bool gamePaused;
    [SerializeField]
    private float speed = 0.5f;
    [SerializeField]
    private GameObject pauseCanvas;

    /// <summary>
    /// What is set when game is started
    /// </summary>
    void Start()
    {
        // game isn't paused at the start
        gamePaused = false;
        pauseCanvas = GameObject.Find("Pause");
    }


    /// <summary>
    /// Pause function for the game
    /// </summary>
    void Update()
    {
        //If escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePaused = !gamePaused;
        }
            //if game is paused
        if (gamePaused)
        {
            ActivateCanvas();
        }          
        else
        {
            DisableCanvas();       
        }
        
        //Finding the background renderer from quad
        Vector2 offset = new Vector2(Time.time * speed, 0);
        GameObject.Find("Quad").GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
    /// <summary>
    /// Activates the canvas
    /// </summary>
    void ActivateCanvas()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
        gamePaused = true;
    }
    /// <summary>
    /// Disables the canvas
    /// </summary>
    void DisableCanvas()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }
}
