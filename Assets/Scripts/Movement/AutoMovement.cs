﻿using UnityEngine;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class AutoMovement : MonoBehaviour
{
	/// <summary>
	/// Object speed
	/// </summary>
	public Vector2 speed = new Vector2(10, 10);
	
	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2(-1, 0);
	
	private Vector2 movement;
	
	void Update()
	{
		// Compute directional velocity
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
	}
	
	void FixedUpdate()
	{
		// Apply directional velocity to the rigidbody
		rigidbody2D.velocity = movement;
	}
}