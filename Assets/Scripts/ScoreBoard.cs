using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    // making the flieds for the score system

    public Text scoreText;
    public Text highScoreText;

    public static float scoreCount;
    public float highScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    public Text enterName;




    void Start()
    {
        // takes the high score from the previous achievement and saves it to the high score
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }

    }


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
    // adding the pick up points to the score count
    public void AddPoints(int points)
    {
        scoreCount += points;
    }

}


