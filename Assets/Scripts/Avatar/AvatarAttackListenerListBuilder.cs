﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AvatarAttackListenerListBuilder : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		// Let the attack range collision box follow the target
		if (target != null) {
			transform.position = new Vector3 (target.position.x, target.position.y);
		} else {
			Debug.Log ("******* SHOULD ATTACH TO A TARGET *******");
		}
	}

	// Method for handling when object with 2D collider enters the Attack-Range-Box
	void OnTriggerEnter2D(Collider2D other) {

		// Attempt to get the Collider2D object's GameObject. If parent existed, get the parent GameObject instead.
		GameObject o = other.gameObject.transform.parent == null ? other.gameObject : other.gameObject.transform.parent.gameObject;

		if ((o.tag == "Enemy" || o.tag == "Destructable") && o.GetComponents(typeof(AvatarAttackListener)).Length > 0) {
			Debug.Log ("Added " + o.tag + " to list");
			// Add to the list
			Avatar.attackListenerList.Add ((AvatarAttackListener)(o.GetComponents(typeof(AvatarAttackListener))[0]));
		}
	}

	// Method for handling when object with 2D collider exits the Attack-Range-Box
	void OnTriggerExit2D(Collider2D other) {
		// Attempt to get the Collider2D object's GameObject. If parent existed, get the parent GameObject instead.
		GameObject o = other.gameObject.transform.parent == null ? other.gameObject : other.gameObject.transform.parent.gameObject;
		if ((o.tag == "Enemy" || o.tag == "Destructable") && o.GetComponents(typeof(AvatarAttackListener)).Length > 0) {
			Debug.Log ("Removed " + o.tag + " from list");
			// Remove from the list
			Avatar.attackListenerList.Remove ((AvatarAttackListener)(o.GetComponents(typeof(AvatarAttackListener))[0]));
		}
	}

}