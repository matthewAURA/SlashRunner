using UnityEngine;
using System.Collections;

public abstract class SineMovement : Movement {

	/// <summary>
	/// Range of sine motion
	/// </summary>
	public float magnitude = 1.0f;

	protected float timer;
	protected float origX;
	protected float origY;
	protected Vector3 newPosition;
	
	void Start ()
	{
		timer = 0;
		origX = transform.position.x;
		origY = transform.position.y;
	}

	protected sealed override void UpdateMovement()
	{
		transform.position = newPosition;
	}
}