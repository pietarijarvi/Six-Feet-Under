using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour {

    private bool doublePoints;

    private bool powerupActive;

    private float powerupLengthCounter;

    private float normalPointsPerSecond;

    private ScoreBoard scoreBoard;

    void Start () {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
	
	void Update () {
       
        if (powerupActive)
        {
            powerupLengthCounter -= Time.deltaTime;

            if (doublePoints)
            {
                scoreBoard.pointsPerSecond = normalPointsPerSecond * 2.75f;
                scoreBoard.shouldDouble = true;
            }

            if (powerupLengthCounter <= 0)
            {

                scoreBoard.pointsPerSecond = normalPointsPerSecond;
                scoreBoard.shouldDouble = false;

                powerupActive = false;
            }
        }

    }

    public void ActivatePowerUp(bool points, float time)
    {
        doublePoints = points;
        powerupLengthCounter = time;

        normalPointsPerSecond = scoreBoard.pointsPerSecond;

        powerupActive = true;
    }
}
