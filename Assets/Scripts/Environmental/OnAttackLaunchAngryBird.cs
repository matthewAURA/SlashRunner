using UnityEngine;
using System.Collections;

/// <summary>
/// Launches the bird off into the distance when attacked,
/// destroying a bunch of enemies at a hardcoded impact point
/// and releasing a whole bunch of coins!
/// </summary>
public class OnAttackLaunchAngryBird : MonoBehaviour, AvatarAttackListener 
{
	public GameObject craterRemains;
	
	void Start ()
	{

	}

	void Update ()
	{
	
	}

	/// <summary>
	/// Launches the bird towards the right
	/// </summary>
	public void OnAvatarAttack(Avatar.Attack attack)
	{
		Avatar.attackListenerList.Remove (this);

		// Launched bird should be affected by physics
		rigidbody2D.gravityScale = 2;

		rigidbody2D.AddForce(new Vector3(3000, 750));

		// Bomb bird destroyed enemies in its wake!
		Destroy (GameObject.Find ("BombedEnemies"));
		Instantiate (craterRemains);

		Destroy (gameObject, 3);
	}
}
