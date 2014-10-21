using UnityEngine;
using System.Collections;

public class Success : MonoBehaviour {

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// Method for handling when object with 2D collider enters the Attack-Range-Box
	void OnTriggerEnter2D(Collider2D other) {
		
		// Attempt to get the Collider2D object's GameObject. If parent existed, get the parent GameObject instead.
		GameObject o = other.gameObject;

		if (o.tag == "Player") {
			Application.LoadLevel("LevelEndSuccess");
		}
	}	
}
