using UnityEngine;
using System.Collections;

public abstract class Movement : MonoBehaviour
{
	/// <summary>
	/// Speed of the movement
	/// </summary>
	public float speed = 1.0f;

	void Update()
	{
		ComputeMovement();
	}

	void FixedUpdate()
	{
		UpdateMovement();
	}

	/// <summary>
	/// Compute object movement requirements
	/// </summary>
	protected abstract void ComputeMovement();

	/// <summary>
	/// Move the object
	/// </summary>
	protected abstract void UpdateMovement();
}

