using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Causes the object to play it's animation and 'bounce'
/// vertically at random time intervals.
/// </summary>
public class RandomIntervalFlappyBounce : MonoBehaviour
{
	/// <summary>
	/// Dictates the random cooldown of the bounce effect
	/// in seconds
	/// </summary>
	public double lowerLimit = 0.5;
	public double upperLimit = 1;

	// Used to keep track of when next bounce should be
	private double cooldown = 0;
	private System.Random rnd = new System.Random(Guid.NewGuid().GetHashCode());

	private const int BOUNCE_STRENGTH = 500;
	private const int GRAVITY_SCALE = 2;
	private const int X_VELOCITY_MIN = 15;
	private const int X_VELOCITY_MAX = 25;

	void Start ()
	{
		// Birds flap their wings when flying
		var animator = GetComponent<Animator> ();
		if (animator != null)
		{
			animator.enabled = true;
		}

		// If bird facing left, face right
		if (transform.localScale.x < 0)
		{
			transform.localScale = new Vector3(transform.localScale.x * -1,
			                                   transform.localScale.y);
		}

		// Allow bird start moving
		rigidbody2D.gravityScale = GRAVITY_SCALE;
		rigidbody2D.velocity = new Vector3 (rnd.Next(X_VELOCITY_MIN, X_VELOCITY_MAX), 0);

		// Destroy birds when well off offscreen
		Destroy (gameObject, 10);
	}

	void Update ()
	{
		if (cooldown <= 0)
		{
			// Downward velocity should be 0'd just like in the original game
			rigidbody2D.velocity = new Vector3(rigidbody2D.velocity.x, 0);
			rigidbody2D.AddForce (new Vector3(0, 1, 0) * BOUNCE_STRENGTH);

			RefreshCooldown();
		}
		else
		{
			cooldown -= Time.deltaTime;
		}
	}
	
	/// <summary>
	/// Refreshes the cooldown, setting it to some random
	/// value dictated by the upper and lower bounds.
	/// </summary>
	private void RefreshCooldown()
	{
		cooldown = rnd.NextDouble ();
	}
}
