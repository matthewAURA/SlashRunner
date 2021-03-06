﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUp : MonoBehaviour {

	public GameObject powerBirdSpawn;

	public GameObject powerSlowMotion;

	public GameObject powerBlast;

	public AudioClip pickupPowerup;

	private List<Power> powerUps;

	public enum Power {
		birdSpawn, slowMotion, blast
	}

	void Awake () {
		powerUps = new List<Power> ();
		if (PlayerPrefs.GetInt ("heartPowerup") == 1) {
			powerUps.Add (Power.birdSpawn);
		}
		if (PlayerPrefs.GetInt ("timerPowerup") == 1) {
			powerUps.Add (Power.slowMotion);
		}
		if(PlayerPrefs.GetInt("destroyPowerup")== 1) {
			powerUps.Add (Power.blast);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Method for handling when object with 2D collider enters the Attack-Range-Box
	void OnTriggerEnter2D(Collider2D other) {


		
		IPowerUp powerUp = null;
		GameObject o = other.gameObject;
		if (o.tag == "Player" && o.GetComponents (typeof(Avatar)).Length > 0) {
			//Randomly select and instanciate the power up game object
			if (powerUps.Count > 0) {

				if (pickupPowerup != null) {
					AudioSource.PlayClipAtPoint (pickupPowerup, transform.position);	
				}

				int random = UnityEngine.Random.Range (0, powerUps.Count);
				//instanciates the randomly selected power up game object
				Debug.Log (random);
				switch (powerUps[random]) {
					case Power.blast:
						GameObject blast  = (GameObject) Instantiate(powerBlast, this.transform.position, this.transform.rotation);
						powerUp = blast.GetComponent<DoPowerBlast>();
						break;
					case Power.birdSpawn:
						GameObject birdSpawn  = (GameObject) Instantiate(powerBirdSpawn, this.transform.position, this.transform.rotation);
						powerUp = birdSpawn.GetComponent<PowerBirdSpawn>();
						break;
					case Power.slowMotion:
						GameObject slowMotion  = (GameObject) Instantiate(powerSlowMotion, this.transform.position, this.transform.rotation);
						powerUp = slowMotion.GetComponent<PowerSlowMotion>();
						break;
				}
			}

			foreach (Avatar obj in o.GetComponents(typeof(Avatar))) {
				if (powerUp != null) {
					obj.setPowerUp(powerUp);
				}
			}
			Destroy (this.gameObject);
		}
	}
}
