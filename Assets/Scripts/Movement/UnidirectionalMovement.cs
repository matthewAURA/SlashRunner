using UnityEngine;

/// <summary>
/// Simply moves the current game object in a single direction
/// </summary>
public sealed class UnidirectionalMovement : Movement
{
	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2(-1, 0);

	private Vector2 speed2d;
	private Vector2 movement;

	void Start()
	{
		speed2d = new Vector2 (speed, speed);
	}

	protected sealed override void ComputeMovement()
	{
		// Compute directional velocity
		movement = new Vector2(
			speed2d.x * direction.x,
			speed2d.y * direction.y);
	}

	protected sealed override void UpdateMovement()
	{
		// Apply directional velocity to the rigidbody
		rigidbody2D.velocity = movement;
	}
	

}