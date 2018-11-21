using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Leaderboard:IComparable<Leaderboard>
{
    public float Score { get; set; }
    public string Name { get; set; }
    public int ID { get; set; }

    public Leaderboard(int id, float score, string name)
    {
        this.Score = score;
        this.Name = name;
        this.ID = id;
    }

    public int CompareTo(Leaderboard other)
    {
        //first>second return -1
        //first<second return 1
        //first==second return 0

        if (other.Score < this.Score)
        {
            return -1;
        }

        else if (other.Score > this.Score)
        {
            return 1;
        }
        return 0;
    }
}
