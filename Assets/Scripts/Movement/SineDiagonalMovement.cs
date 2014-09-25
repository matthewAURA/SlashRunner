using UnityEngine;
using System.Collections;

/// <summary>
/// Allows the object to exhibit diagonally back-and-forth
/// movement with a velocity described by a sine wave.
/// </summary>
public class SineDiagonalMovement: MonoBehaviour
{
	/// <summary>
	/// Range of horizontal motion
	/// </summary>
	public float magnitudeX = 1.0f;

	/// <summary>
	/// Range of horizontal motion
	/// </summary>
	public float magnitudeY = 1.0f;
	
	/// <summary>
	/// Speed of the movement
	/// </summary>
	public float speed = 1.0f;
	
	float timer;
	float origX;
	float origY;
	
	void Start()
	{
		timer = 0;
		origX = transform.position.x;
		origY = transform.position.y;
	}
	
	void Update ()
	{
		if ((timer += Time.deltaTime) >= 60 * Mathf.PI)
		{
			timer = 0;
		}
		
		transform.position = new Vector2(magnitudeX * Mathf.Sin(timer*speed) + origX,
		                                 magnitudeY * Mathf.Sin(timer*speed) + origY);
		
	}
}