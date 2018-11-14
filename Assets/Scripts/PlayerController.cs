﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //making new float variables for speed and jump
    public float speed;
    public float jump;

    public LevelController theLevelManager;


    public float jumpTime;
    private float jumpTimeCounter;


    //making a private variable for 2D physics body of the player
    private Rigidbody2D myRigidBody;
    
    //bool for when the character is on the ground layer
    public bool onTheGround;

    //making a new layermask for ground
    public LayerMask groundLayer;

    private Collider2D myCollider;

	/// <summary>
    /// What happens when the game starts
    /// </summary>
	void Start () {
        //Finding the rigidbody of the player
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        jumpTimeCounter = jumpTime;
	}


    /// <summary>
    /// Setting new vectors for player speed and jump, update is called once per frame
    /// </summary>
    void Update () {

        onTheGround = Physics2D.IsTouchingLayers(myCollider, groundLayer);

        //Here we make the vector for speed
        myRigidBody.velocity = new Vector2(speed, myRigidBody.velocity.y);

        //If spacebar or mousebutton 0 (left click) is down, character jumps. Also works with mobile by tapping the screen.
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))
        {
            if (onTheGround)
            {
                //Here we make the vector for jump
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jump);
                jumpTimeCounter = jumpTime;
            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {   
            //if counter is over 0
            if (jumpTimeCounter > 0)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jump);
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        
        //if key isn't pressed
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {   
            //counter resets to zero
            jumpTimeCounter = 0;
        }
        
	}
    /// <summary>
    /// Is called when the player hits a boxcollider with a certain tag
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionEnter2D(Collision2D other)
    {
        //If the tag of the gameobject is "death"
        if (other.gameObject.tag == "death")
        {   
            //Takes the player to the game over screen
            theLevelManager.GameOver();
        }
    }
}
