using UnityEngine;
using System.Collections;

/// <summary>
/// Represents a camera with smoothed (dampened) movement.
/// </summary>
public class DampenedCamera : MonoBehaviour
{
	/// <summary>
	/// Dampening time
	/// </summary>
	public float dampeningTime = 0.15f;

	/// <summary>
	/// Target on which to fixate onto
	/// </summary>
	public Transform target;

	/// <summary>
	/// Specifies camera positional offsets relative to the target
	/// </summary>
	public float offsetX = 0.0f;
	public float offsetY = 0.0f;

	Vector3 velocity = Vector3.zero;

	void FixedUpdate () 
	{
		// Only update camera position if target exists
		if (target)
		{
			Vector3 point = camera.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
			Vector3 destination = transform.position + delta;
			destination.x += offsetX;
			destination.y += offsetY;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampeningTime);
		}
		
	}
}