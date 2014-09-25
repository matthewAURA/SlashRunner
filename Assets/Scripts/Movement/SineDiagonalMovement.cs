using UnityEngine;
using System.Collections;

/// <summary>
/// Allows the object to exhibit diagonally back-and-forth
/// movement with a velocity described by a sine wave.
/// </summary>
public sealed class SineDiagonalMovement: SineMovement
{
	/// <summary>
	/// Range of horizontal motion
	/// </summary>
	public float magnitudeX = 1.0f;

	/// <summary>
	/// Range of horizontal motion
	/// </summary>
	public float magnitudeY = 1.0f;

	protected sealed override void ComputeMovement()
	{
		if ((timer += Time.deltaTime) >= 60 * Mathf.PI)
		{
			timer = 0;
		}
		
		newPosition = new Vector2(magnitudeX * Mathf.Sin(timer*speed) + origX,
		                                 magnitudeY * Mathf.Sin(timer*speed) + origY);	
	}
}