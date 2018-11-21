using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Leaderboard
{
    //properties for database data
    public float Score { get; set; }
    public string Name { get; set; }
    public int ID { get; set; }

    //constructor for when a new leaderboard is created
    public Leaderboard(int id, float score, string name)
    {
        this.Score = score;
        this.Name = name;
        this.ID = id;
    }
    
}
