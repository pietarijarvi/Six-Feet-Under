using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoints : MonoBehaviour {

    // making a field for the pick up points
    public int scorePoints;

    // making a ScoreBoard typed field
    private ScoreBoard scoreBoard;

	void Start () {

        // the ScoreBoard that is used in the game
        scoreBoard = FindObjectOfType<ScoreBoard>();
	}
	

    // here the point is being picked up when a player with a collider hits the pick up point's collider
    private void OnTriggerEnter2D(Collider2D collision)
    {

        // making sure that the one who hits the point is the player
        if (collision.gameObject.name == "Player")
        {
            // here the pick up point is added to the score count if the player picks it up
            scoreBoard.AddPoints(scorePoints);
            // here the pick up point is destroyed when it is picked
            gameObject.SetActive(false);
        }
    }
}
