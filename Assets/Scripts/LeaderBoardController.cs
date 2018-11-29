using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.SqliteClient;
using UnityEngine.UI;

public class LeaderBoardController : MonoBehaviour
{
    //connection variable used to connect to the database
    private string conn;
    //texts that show the data in the scene
    private Text scoreText;
    private Text nameText;
    private Text rankText;
    float score;
    //SerializeField is used to see the private field in Unity
    [SerializeField] private Text inputText;

    /// <summary>
    /// What happens when the game is started
    /// </summary>
    void Start()
    {
        //Finding text components in gameover scene
        inputText = GameObject.Find("EnterName").GetComponent<Text>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        rankText = GameObject.Find("Rank").GetComponent<Text>();
        nameText = GameObject.Find("Name").GetComponent<Text>();
        //conn variable is the link to the database inside the asset
        conn = "URI=file:" + Application.dataPath + "/PeliProjektiDB.db";
        //Getting scores from database
        GetScores();
    }

    public void AddScore()
    {
        //score is got from scoreboard class
        score = ScoreBoard.GetScoreCount();
        //name is the text input in the inputfield
        name = inputText.text.ToString();
        //connecting to the database
        using (IDbConnection dbconn = new SqliteConnection(conn))
        {   //opening connection
            dbconn.Open();
            //using connection
            using (IDbCommand dbCmd = dbconn.CreateCommand())
            {   //Defining how data is inserted with String.Format
                string sqlQuery = String.Format("INSERT INTO HighScores(Name,Score) VALUES(\"{0}\",\"{1}\")", name, score);
                

                dbCmd.CommandText = sqlQuery;
                //Executing the command 
                dbCmd.ExecuteScalar();
                //Getting scores again so that leaderboard updates when the button is clicked
                GetScores();
                //closing connection
                dbconn.Close();              
            }
            
        }
    }

    /// <summary>
    /// Gets data from the database
    /// </summary>
    public void GetScores()
    {
        //return a string from the database with past player name and their respective score
        using (IDbConnection dbconn = new SqliteConnection(conn))
        {
            //opening connection to database
            dbconn.Open();
            using (IDbCommand dbCmd = dbconn.CreateCommand())
            {
                //Select all from highscores table and sort them from highest to lowest
                string sqlQuery = String.Format("SELECT * FROM HighScores ORDER BY Score DESC");
                dbCmd.CommandText = sqlQuery;

                nameText.text = "";
                scoreText.text = "";
                rankText.text = "";
                
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    int i = 0;
                    int rank = 1;
                    //setting database to show only the top 5 scores
                    while (reader.Read()&& i<5)
                    {
                        i++;
                        //what name and score correlate to in the database ("(1)" is the position for name and "(2)" position for score)
                        string name = reader.GetString(1);
                        float score = reader.GetFloat(2);
                        
                        //setting how the data should be displayed in the text objects
                        nameText.text += name.ToString() + "\n";
                        scoreText.text += score.ToString() + "\n";
                        rankText.text += rank.ToString() + "\n";
                        rank++;
                    }
                    //closing reader and connection
                    dbconn.Close();
                    reader.Close();                    
                }
            }
        }
    }
}