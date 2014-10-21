using UnityEngine;
using System.Collections;
using System;

public class FishScript : MonoBehaviour {

	public float distance = 20; // distance fish travels
	public float height = 10;// the height of the fish jump.
	private float startTime;

	private Vector3 startPos;
	private Vector3 endPos;

	// Use this for initialization
	void Start () {
		startPos = new Vector3 (rigidbody2D.position.x, rigidbody2D.position.y);
		endPos = startPos;
		if (transform.localRotation.y == 0) {
			endPos.x = rigidbody2D.position.x + distance;
		}else{
			endPos.x = rigidbody2D.position.x - distance;
		}
		height -= rigidbody2D.position.y;

		startTime = Time.time;
		Destroy (gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () {
		float cTime = (Time.time - startTime)* 0.5f;
		Vector3 currentPos = Vector3.Lerp(startPos, endPos, cTime);
		float angle = rigidbody2D.rotation;
		Debug.Log (angle);
		// add a value to Y, using Sine to give a curved trajectory in the Y direction
		currentPos.y += height * Mathf.Sin(Mathf.Clamp01(cTime) * Mathf.PI);
		
		// finally assign the computed position to our gameObject:
		transform.position = currentPos;
		// add torque to the fish to make it look like turning.
		transform.RotateAround(currentPos, new Vector3(0,0,1),2.5f * 0.5f);
	
	}
}