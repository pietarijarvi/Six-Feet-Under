using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MonoBehaviour is the base class from which every Unity script derives.
public class CameraController : MonoBehaviour {

    public PlayerController zombie;
    private Vector3 positionOfZombie;
    private float distanceToMove;

	// Use this for initialization
	void Start () {

        //finds player(zombie) from the game
        zombie = FindObjectOfType<PlayerController>();
        
        //where the zombie is in the game
        positionOfZombie = zombie.transform.position;
    }

    // Update is called once per frame
    void Update () {

        distanceToMove = zombie.transform.position.x - positionOfZombie.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        positionOfZombie = zombie.transform.position;
	}
}
