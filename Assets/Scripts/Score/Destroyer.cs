﻿using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			UnityEngine.Application.LoadLevel(1);
			return;
		}
		else if (other.gameObject.transform.parent) {
			Destroy (other.gameObject.transform.parent.gameObject);
		} else {
			Destroy(other.gameObject);
		}
	}
}
