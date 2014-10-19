using UnityEngine;
using System.Collections;

/// <summary>
/// Speeds up player objects by a certain velocity.
/// Only occurs once.
/// </summary>
public class SpeedUpAvatarScript : MonoBehaviour {

	public float increase = 5;
	
	void Start ()
	{
		// Increase avatar speed
		GameObject character = GameObject.Find ("Character");
		character.GetComponent<Avatar> ().movementForce += increase;

		// Increase speed of any objects that may be linked to avatar
		GameObject playerGroup = GameObject.Find ("6 - Player");
		foreach (var u in playerGroup.GetComponentsInChildren<UnidirectionalMovement>())
		{
			u.speed += increase;
		}

		// Adjust camera to compensate
		GameObject cam = GameObject.Find ("Main Camera");
		cam.GetComponent<FollowingDistanceCamera> ().offsetX += increase/2;
	}
}
