using UnityEngine;
using System.Collections;

/// <summary>
/// Allows the object to exhibit vertically back-and-forth
/// movement with a velocity described by a sine wave
/// </summary>
public sealed class SineVerticalMovement : SineMovement
{	
	protected sealed override void ComputeMovement()
	{
		if ((timer += Time.deltaTime) >= 60 * Mathf.PI)
		{
			timer = 0;
		}
		
		newPosition = new Vector2(origX,	magnitude * Mathf.Sin(timer*speed) + origY);
	}
}