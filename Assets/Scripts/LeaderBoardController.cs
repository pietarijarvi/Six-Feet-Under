using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.SqliteClient;
using UnityEngine.UI;

public class LeaderBoardController : MonoBehaviour
{
    //used for connecting to the database
    private string connection;
    //List where scores are stored
    private List<Leaderboard> scores = new List<Leaderboard>();
    public GameObject scorePrefab;
    public Transform scoreParent;
    public int topScores;
    public int saveScores;
    public Text enterName;

    /// <summary>
    /// What happens when the game is started
    /// </summary>
    void Start()
    {
        //Connecting to database file in a specific location
        connection = "URI=file:" + Application.dataPath + "/PeliProjektiDB.db";

        //Deleting unneeded scores
        DeleteExtras();
        
        //Showing scores
        ShowScores();

    }

    /// <summary>
    /// Inserting score and name to leaderboard
    /// </summary>
    public void InsertScore()
    {
        //If inputfield is not empty
        if (enterName.text != string.Empty)
        {
            //Score is scoreCount made in ScoreBoard script
            float score = ScoreBoard.scoreCount;
            //Adding entered name and score that we got in the game
            AddScores(enterName.text, score);
            enterName.text = string.Empty;
            ShowScores();
        }
    }
    /// <summary>
    /// Add scores to database
    /// </summary>
    /// <param name="name"></param>
    /// <param name="theScore"></param>
    public void AddScores(string name, float theScore)
    {   //connecting to the database
        using (IDbConnection dbconnection = new SqliteConnection(connection))
        {   //opening connection
            dbconnection.Open();
            //using connection
            using (IDbCommand dbCmd = dbconnection.CreateCommand())
            {   //Defining how data is inserted with String.Format
                string sqlQuery = String.Format("INSERT INTO HighScores(Name,Score) VALUES(\"{0}\",\"{1}\")", name, theScore);

                dbCmd.CommandText = sqlQuery;
                //Executing the command 
                dbCmd.ExecuteScalar();
                //closing connection
                dbconnection.Close();
            }
        }
    }
    /// <summary>
    /// Get scores from leaderboard
    /// </summary>
    void GetScores()
    {
        //clearing list so we dont show same scores multiple times
        scores.Clear();
        //connecting to database
        using (IDbConnection dbconnection = new SqliteConnection(connection))
        {
            //opening connection
            dbconnection.Open();
            //using connection
            using (IDbCommand dbCmd = dbconnection.CreateCommand())
            {
                //Selects everything from database table
                string sqlQuery = "SELECT * FROM HighScores ORDER BY Score DESC";
                //giving query (db command) a commandtext
                dbCmd.CommandText = sqlQuery;
                //reading data from database, ExecuteReader executes command we created, reader will have the data from database 
                using (IDataReader reader = dbCmd.ExecuteReader())
                {   //while reader reads
                    while (reader.Read())
                    {   //adding PlayerID, Score and Name with positions in the database (0,1,2)
                        scores.Add(new Leaderboard(reader.GetInt32(0), reader.GetInt32(2), reader.GetString(1)));

                    }
                    //closing connection to database
                    dbconnection.Close();
                    //closing the reader
                    reader.Close();
                }
            }
        }
    }
    
    /// <summary>
    /// Showing our scores
    /// </summary>
    public void ShowScores()
    {
        GetScores();
        //Where tag is score
        foreach (GameObject score in GameObject.FindGameObjectsWithTag("Score"))
        {
            Destroy(score);
        }

        for (int i = 0; i < topScores; i++)
        {
            if (i <= scores.Count - 1)
            {
                GameObject tmp = Instantiate(scorePrefab);
                Leaderboard tmpScore = scores[i];
                tmp.GetComponent<ShowingScores>().SetScore(tmpScore.Name, tmpScore.Score.ToString(), '#' + (i + 1).ToString());
                tmp.transform.SetParent(scoreParent);
                tmp.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }
        }
    }
    /// <summary>
    /// Deleting extra scores from the bottom that we dont need anymore
    /// </summary>
    void DeleteExtras()
    {
        GetScores();

        if (saveScores <= scores.Count)
        {
            int deleteCount = scores.Count - saveScores;
            scores.Reverse();

            using (IDbConnection dbconnection = new SqliteConnection(connection))
            {
                dbconnection.Open();
                using (IDbCommand dbCmd = dbconnection.CreateCommand())
                {
                    for (int i = 0; i < deleteCount; i++)
                    {


                        string sqlQuery = String.Format("DELETE FROM HighScores WHERE PlayerID = \"{0}\"", scores[i].ID);

                        dbCmd.CommandText = sqlQuery;
                        dbCmd.ExecuteScalar();
                        
                    }
                    dbconnection.Close();
                }   
            }
        }
    }
}