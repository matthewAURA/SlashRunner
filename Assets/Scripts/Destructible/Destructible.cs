﻿using UnityEngine;
using System.Collections;

/* Destroys current GameObject (Script is applied to) replacing it with the child
 * remains object, based on action. Currently on left arrow, will change to
 * being hit by gesture */

public class Destructible : MonoBehaviour {
	
	void Start () {
	
	}

	public GameObject remains;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			GameObject pieces = (GameObject) Instantiate(remains, transform.position, transform.rotation);
			Destroy (gameObject);
		}


	
	}
}