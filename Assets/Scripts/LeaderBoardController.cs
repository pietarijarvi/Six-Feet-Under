using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.SqliteClient;
using UnityEngine.UI;

public class LeaderBoardController : MonoBehaviour
{

    private string connection;
    private List<Leaderboard> scores = new List<Leaderboard>();
    public GameObject scorePrefab;
    public Transform scoreParent;
    public int topScores;
    public int saveScores;
    public Text enterName;

    // Use this for initialization
    void Start()
    {
        connection = "URI=file:" + Application.dataPath + "/PeliProjektiDB.db";

        DeleteExtras();

        ShowScores();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InsertScore()
    {
        if (enterName.text != string.Empty)
        {
            float score = ScoreBoard.scoreCount;
            AddScores(enterName.text, score);
            enterName.text = string.Empty;
            ShowScores();
        }
    }

    public void AddScores(string name, float newScore)
    {
        using (IDbConnection dbconnection = new SqliteConnection(connection))
        {
            dbconnection.Open();
            using (IDbCommand dbCmd = dbconnection.CreateCommand())
            {
                string sqlQuery = String.Format("INSERT INTO HighScores(Name,Score) VALUES(\"{0}\",\"{1}\")", name, newScore);

                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbconnection.Close();
            }
        }
    }

    void GetScores()
    {
        scores.Clear();
        using (IDbConnection dbconnection = new SqliteConnection(connection))
        {
            dbconnection.Open();
            using (IDbCommand dbCmd = dbconnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM HighScores";

                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        scores.Add(new Leaderboard(reader.GetInt32(0), reader.GetInt32(2), reader.GetString(1)));

                    }
                    dbconnection.Close();
                    reader.Close();
                }
            }
        }
        scores.Sort();
    }

    void DeleteScores(int id)
    {
        using (IDbConnection dbconnection = new SqliteConnection(connection))
        {
            dbconnection.Open();
            using (IDbCommand dbCmd = dbconnection.CreateCommand())
            {
                string sqlQuery = String.Format("DELETE FROM HighScores WHERE PlayerID = \"{0}\"", id);

                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbconnection.Close();
            }
        }
    }

    public void ShowScores()
    {
        GetScores();

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