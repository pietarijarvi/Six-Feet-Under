using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //used gamesplusjames youtube tutorial for reference on some parts

    //making new float variables for speed and jump
    //and for the speed increase system (milestone and multiplier)
    [SerializeField]
    private float speed;
    [SerializeField]
    private float speedMultiplier;

    //speedIncreaseMilestone is the distance the player reaches before speeding up
    [SerializeField]
    private float speedIncreaseMilestone;

    private float speedMilestoneCount;

    //setting max speed 
    [SerializeField]
    private float maxSpeed = 35;

    [SerializeField]
    private float jump;

    [SerializeField]
    private LevelController theLevelManager;

    //making a private variable for 2D physics body of the player
    private Rigidbody2D myRigidBody;

    //bool for when the character is on the ground layer
    private bool onTheGround;

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundCheckRadius;

    //boolean for the ability to double jump
    private bool doubleJump;

    //making a new layermask for ground
    [SerializeField]
    private LayerMask groundLayer;

    /// <summary>
    /// What happens when the game starts
    /// </summary>
    void Start()
    {
        //Finding the rigidbody of the player
        myRigidBody = GetComponent<Rigidbody2D>();

        //setting milestone count as the increasing milestone
        speedMilestoneCount = speedIncreaseMilestone;
    }


    /// <summary>
    /// Setting new vectors for player speed and jump. Setting when the player can double jump.
    /// </summary>
    void Update()
    { 

        // Here the maximum speed is set as player's speed if the speed goes over the maximum
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        onTheGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //Here the speed is increasing if the player has reached the milestone where the speed should increase
        if (transform.position.x > speedIncreaseMilestone)
        {
            //the speed increasing distance is duplicating
            speedMilestoneCount += speedIncreaseMilestone;

            // makes the speed increasing distance go up certain amount so that the speed increases evenly
            speedIncreaseMilestone = speedIncreaseMilestone * (2 * speedMultiplier);

            //here the speed is increased
            speed = speed * speedMultiplier;
        }


        //Here we make the vector for speed
        myRigidBody.velocity = new Vector2(speed, myRigidBody.velocity.y);

        //If spacebar or mousebutton 0 (left click) is down, character jumps. Also works with mobile by tapping the screen.
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (onTheGround)
            {
                Jump();
                doubleJump = true;
            }
            else
            {
                if (doubleJump)
                {
                    Jump();
                    doubleJump = false;
                }
            }
        }
        //If you press the down arrow while in the air
        if (Input.GetKey(KeyCode.DownArrow)&&!onTheGround)
        {   //Increase gravity of player character
            GetComponent<Rigidbody2D>().AddForce(Physics2D.gravity*7f);
        }
    }
    /// <summary>
    /// Method for jumping
    /// </summary>
    private void Jump()
    {
        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jump);
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