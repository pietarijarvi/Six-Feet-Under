using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    private float slowLenght = 2f;
    // making a ScoreBoard typed field
    private ScoreBoard scoreBoard;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        // making sure that the one who hits the point is the player
        if (collision.gameObject.name == "Player")
        {
            SlowTime();
            
        }
    }

    private void SlowTime()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
