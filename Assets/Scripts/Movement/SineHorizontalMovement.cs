using UnityEngine;
using System.Collections;

/// <summary>
/// Allows the object to exhibit horizontally back-and-forth
/// movement with a velocity described by a sine wave
/// </summary>
public class SineHorizontalMovement: MonoBehaviour
{
	/// <summary>
	/// Range of sine motion
	/// </summary>
	public float magnitude = 1.0f;
	
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
		
		transform.position = new Vector2(magnitude * Mathf.Sin(timer*speed) + origX, origY);
		
	}
}