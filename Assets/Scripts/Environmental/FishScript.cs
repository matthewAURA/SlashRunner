using UnityEngine;
using System.Collections;
using System;

public class FishScript : MonoBehaviour {

	public double lowerLimit = 0.5;
	public double upperLimit = 1;
	
	// Used to keep track of when next bounce should be
	private double cooldown = 0;
	private System.Random rnd = new System.Random(Guid.NewGuid().GetHashCode());
	
	private const int BOUNCE_STRENGTH = 500;
	private const int GRAVITY_SCALE = 2;
	private const int X_VELOCITY_MIN = 15;
	private const int X_VELOCITY_MAX = 25;
	private bool isDown;
	private int rotation_x;
	private int rotation_y;
	private int rotation_z;

	// Use this for initialization
	void Start () {
		// Birds flap their wings when flying
		var animator = GetComponent<Animator> ();
		if (animator != null)
		{
			animator.enabled = true;
		}
		
		// Allow bird start moving
		rigidbody2D.gravityScale = GRAVITY_SCALE;
		rigidbody2D.velocity = new Vector3 (0, 10, 0);
		isDown = false;
		// Destroy birds when well off offscreen
		Destroy (gameObject, 10);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		if (position.y < 5 && !isDown) {
			rigidbody2D.velocity = new Vector3 (-0.5f, 10, 0);
			rigidbody2D.AddTorque(-0.7f);
		}else{
			isDown = true;
		}

		if (isDown) {
			rigidbody2D.AddTorque(-4);
			rigidbody2D.velocity = new Vector3 (-1.5f, -10, 0);
		}
	}
}