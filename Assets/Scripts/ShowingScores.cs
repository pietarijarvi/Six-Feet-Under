using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


  public class ShowingScores:MonoBehaviour { 
    public GameObject score;
    public GameObject scoreName;
    public GameObject rank;
  
        public void SetScore(string name, string score, string rank)
        {
            this.rank.GetComponent<Text>().text = rank;
            this.score.GetComponent<Text>().text = score;
            this.scoreName.GetComponent<Text>().text = name;
        }
}
