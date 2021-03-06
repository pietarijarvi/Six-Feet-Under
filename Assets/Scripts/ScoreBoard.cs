﻿using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    // making the fields for the score system

    private Text scoreText;
    private Text highScoreText;

    private bool shouldDouble;

    private static float scoreCount;
    private float highScoreCount;
    
    public float pointsPerSecond;

    [SerializeField]
    private bool scoreIncreasing;


    public static float GetScoreCount(){return scoreCount;}

    public static void SetScoreCount(float newScoreCount){scoreCount = newScoreCount;}

    /// <summary>
    /// What is set when starting the game
    /// </summary>
    void Start()
    {
        scoreText = GameObject.Find("TextScore").GetComponent<Text>();
        highScoreText = GameObject.Find("TextHighScore").GetComponent<Text>();
        // takes the high score from the previous achievement and saves it to the high score
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }

    }

    /// <summary>
    /// Increasing score with time
    /// </summary>
    void Update()
    {
        // this increases the score value
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }
        

        // when the player reaches the highscore this begins to count the score also to the high score
        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            // the PlayerPrefs saves the high score value when the score reaches the high score
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        // adding the score values to the scoreText and highScoreText
        // the Mathf.Round rounds the score value to the closest whole number
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);

    }
    /// <summary>
    /// adding the pick up points to the score count
    /// </summary>
    /// <param name="points"></param>
    public void AddPoints(int points)
    {

        if(shouldDouble)
        {
            points = points * 2;
        }

        scoreCount += points;
    }
}


