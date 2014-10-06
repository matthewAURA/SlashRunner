using UnityEngine;
using System.Collections;

public class FollowingDistanceCamera : MonoBehaviour {

	/// Target on which to fixate onto
	public Transform target;
	
	public float marginX = 0f;		// Distance in the x axis the player can move before the camera follows.
	public float marginY = 5f;		// Distance in the y axis the player can move before the camera follows.

	// Specifies camera positional offsets relative to the target
	public float offsetX = 0.0f;
	public float offsetY = 0.0f;

	// Damping time for camera
	public float dampingTime = 0.5f;

	// Initialise the velocity and destination of the camera
	private Vector3 velocity = Vector3.zero;
	private Vector3 destination = Vector3.zero;
	
	// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
	bool IsOutOfXMarginRange()
	{
		return Mathf.Abs(transform.position.x - target.position.x + offsetX) > marginX;
	}
	
	// Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
	bool IsOutOfYMarginRange()
	{
		return Mathf.Abs(transform.position.y - target.position.y + offsetY) > marginY;
	}

	bool IsGoingUp() {
		return target.position.y > transform.position.y;
	}

	void Awake() {
		//transform.position = new Vector3(target.position.x, target.position.y);
	}
	
	void FixedUpdate ()
	{
		// Only update camera position if target exists
		if (target) {
			// Camera doesnt move if player within margin.
			float posX = transform.position.x;
			float posY = transform.position.y;
			
			// Sets value for camera x position if player outside margin in x direction
			if (IsOutOfXMarginRange ()) {
				posX = target.position.x + offsetX + 3f;
			}

			// Sets value for camera y position if player outside margin in y direction
			if (IsOutOfYMarginRange ()) {
				if(IsGoingUp()){
					posY = target.position.y + offsetY - 3f; // **** For some reason... adding the -3f makes the camera smoother...
				} else {
					posY = target.position.y + offsetY + 3f;
				}
			}

			// Set the camera's position
			destination = new Vector3(posX, posY, transform.position.z);
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampingTime);
		}
	}
}
