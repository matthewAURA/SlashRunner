using UnityEngine;
using System.Collections;
using System;

public class FishScript : MonoBehaviour {

	private const int GRAVITY_SCALE = 2;
	private bool isDown;
	private float beginX = -0.5f;
	private float finalX = -1.5f;
	private float beginTorque = -0.8f;
	private float finalTorque = -7;

	// Use this for initialization
	void Start () {
		// Birds flap their wings when flying
		var animator = GetComponent<Animator> ();
		if (animator != null)
		{
			animator.enabled = true;
		}
		if (transform.localScale.y == 0) {
			beginX *= -1;
			finalX *= -1;
			beginTorque *= -1;
			finalTorque *= -1;
		}


		// Allow fish start moving
		rigidbody2D.gravityScale = GRAVITY_SCALE;
		rigidbody2D.velocity = new Vector3 (0, 10, 0);
		isDown = false;
		// Destroy birds when well off offscreen
		Destroy (gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 position = transform.position;

		if (position.y < 4 && !isDown) {
			
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