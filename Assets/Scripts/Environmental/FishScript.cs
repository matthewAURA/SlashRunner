using UnityEngine;
using System.Collections;
using System;

public class FishScript : MonoBehaviour {

	private const int GRAVITY_SCALE = 2;
	private bool isDown; // if the fish reaches maximum heigh ==> isDown is true
	public int height = 4;// the maximum height of the fish
	private float beginX = -0.5f;// variable make the fish move to in the x axis when it starts moving
	public float finalX = -1.5f;// variable make the fish move to in the x axis when it reaches maximum height
	private float beginTorque = -0.8f; // variable make the fish spins at the start.
	public float finalTorque = -7; // varible that make the fish spins when it reaches maximum height

	// Use this for initialization
	void Start () {

		if (transform.localRotation.y == 0) {
			beginX *= -1;
			finalX *= -1;
		}

		// Allow fish start moving
		rigidbody2D.gravityScale = GRAVITY_SCALE;
		rigidbody2D.velocity = new Vector3 (0, 10, 0);
		isDown = false;
		// Destroy birds when well off offscreen
		Destroy (gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 position = transform.position;

		if (position.y < height && !isDown) {
			
			rigidbody2D.velocity = new Vector3 (beginX, 20, 0);
			rigidbody2D.AddTorque(beginTorque);
		}else{
			isDown = true;
		}

		if (isDown) {
			rigidbody2D.AddTorque(finalTorque);
			rigidbody2D.velocity = new Vector3 (finalX, -10, 0);
		}
	}
}