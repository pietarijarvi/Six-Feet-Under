using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {

    public bool doublePoints;

    public float powerupLength;

    private PowerupManager powerupManager;

    void Start()
    {
        powerupManager = FindObjectOfType<PowerupManager>();
    }

    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            powerupManager.ActivatePowerUp(doublePoints, powerupLength);
        }
        gameObject.SetActive(false);
    }
}
