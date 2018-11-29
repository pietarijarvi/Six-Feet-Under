using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleChasing : MonoBehaviour {

    // making a field for enemy's speed 
    [SerializeField]
    private float speed;

    // making a field for Player that the enemy is following
    private Transform target;

	void Start () {
        // target is the gameObject that is tagged as a Player
        // getting player's location for the enemy to follow
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
	
	void Update () {

        // move people's location towards target's (Player) location with a certain speed
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }
}
