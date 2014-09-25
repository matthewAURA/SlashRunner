using UnityEngine;
using System.Collections;

/// <summary>
/// Allows the object to exhibit horizontally back-and-forth
/// movement with a velocity described by a sine wave
/// </summary>
public sealed class SineHorizontalMovement: SineMovement
{	
	protected sealed override void ComputeMovement()
	{
		if ((timer += Time.deltaTime) >= 60 * Mathf.PI)
		{
			timer = 0;
		}
		
		newPosition = new Vector2(magnitude * Mathf.Sin(timer*speed) + origX, origY);
	}
}