using UnityEngine;
using System.Collections;

public class FollowingDistanceCamera : MonoBehaviour {

	/// Target on which to fixate onto
	public Transform target;
	
	public float xMargin = 2f;		// Distance in the x axis the player can move before the camera follows.
	public float yMargin = 10f;		// Distance in the y axis the player can move before the camera follows.
	public float xCamerSpeed = 1f;		// How fast the camera follows the player in the x direction.
	public float yCamerSpeed = 1f;		// How fast the camera follows the player in the y direction.

	// Specifies camera positional offsets relative to the target
	public float offsetX = 15.0f;
	public float offsetY = 0.0f;
	
	// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
	bool CheckXMargin()
	{
		return Mathf.Abs(transform.position.x - target.position.x + offsetX) > xMargin;
	}
	
	// Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
	bool CheckYMargin()
	{
		return Mathf.Abs(transform.position.y - target.position.y + offsetY) > yMargin;
	}
	
	
	void FixedUpdate ()
	{
		// Only update camera position if target exists
		if (target) {
			// Camer doesnt move if player within margin.
			float posX = transform.position.x;
			float posY = transform.position.y;
			
			// Sets value for camera x position if player outside margin in x direction
			if (CheckXMargin ()) {
				posX = Mathf.Lerp (transform.position.x, target.position.x + offsetX, xCamerSpeed * Time.deltaTime);
			}

			// Sets value for camera y position if player outside margin in y direction
			if (CheckYMargin ()) {
				posY = Mathf.Lerp (transform.position.y, target.position.y + offsetY, yCamerSpeed * Time.deltaTime);
			}

			// Set the camera's position
			transform.position = new Vector3(posX, posY, transform.position.z);
		}
	}
}
