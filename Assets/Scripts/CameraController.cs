using UnityEngine;

public class CameraController : MonoBehaviour {
    
    //Setting transforms for the camera movement and the player character
    [SerializeField]
    private Transform cameraMovement;
    [SerializeField]
    private Transform zombie;

    /// <summary>
    /// Here we set how the camera follows the player
    /// </summary>
    void LateUpdate ()
    {
        /* Vector3 consists of three axis: x,y and z. We set that the cameras location is zombie's position in the x axis + a float value.
         * This makes it so that the player character is more to the left of the screen instead of the middle. Then we set the y and z positions to 0
         * so that the camera will not follow the player once the character jumps or falls.*/
        cameraMovement.position = new Vector3(zombie.position.x +10f, 0, 0);
	}
}
