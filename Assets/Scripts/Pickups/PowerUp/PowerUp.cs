using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void GeneratePowerUp() {
		
	}
	
	// Method for handling when object with 2D collider enters the Attack-Range-Box
	void OnTriggerEnter2D(Collider2D other) {
		IPowerUp powerUp;
		
		
		
		// Attempt to get the Collider2D object's GameObject. If parent existed, get the parent GameObject instead.
		GameObject o = other.gameObject;
		if (o.tag == "Player" && o.GetComponents(typeof(Avatar)).Length > 0) {
			// Debug.Log ("Added " + o.tag + " to list");
			foreach(Avatar obj in o.GetComponents(typeof(Avatar))) {
				obj.powerUp = powerUp;
			}
		}
	}	
}
