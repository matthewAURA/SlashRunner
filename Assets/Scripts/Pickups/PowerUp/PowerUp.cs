using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUp : MonoBehaviour {

	private List<IPowerUp> powerUps;

	public enum Power {
		killAll, birdSpawn, slowMotion
	}

	void Awake () {
		//For testing purposes only
		if(!PlayerPrefs.HasKey("powerKillAll")) {
			PlayerPrefs.SetInt("powerKillAll",1);
		}
		if(!PlayerPrefs.HasKey("powerBirdSpawn")) {
			PlayerPrefs.SetInt("powerBirdSpawn",1);
		}
		if(!PlayerPrefs.HasKey("powerSlowMotion")) {
			PlayerPrefs.SetInt("powerSlowMotion",1);
		}


		powerUps = new List<IPowerUp> ();
		if (PlayerPrefs.HasKey ("powerKillAll")) {
			//powerUps.Add(new PowerKillAll());
		}
		if (PlayerPrefs.HasKey ("powerBirdSpawn")) {
			//powerUps.Add(new PowerBirdSpawn());
		}
		if (PlayerPrefs.HasKey ("powerSlowMotion")) {
			//powerUps.Add(new PowerSlowMotion);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void addPlayerPower(Power power) {
		switch (power) {
			case Power.killAll:
				if(!PlayerPrefs.HasKey("powerKillAll")) {
					PlayerPrefs.SetInt("powerKillAll",1);
				}
				break;
			case Power.birdSpawn:
				if(!PlayerPrefs.HasKey("powerBirdSpawn")) {
					PlayerPrefs.SetInt("powerBirdSpawn",1);
				}
				break;
			case Power.slowMotion:
				if(!PlayerPrefs.HasKey("powerSlowMotion")) {
					PlayerPrefs.SetInt("powerSlowMotion",1);
				}
				break;
		}
	}
	
	// Method for handling when object with 2D collider enters the Attack-Range-Box
	void OnTriggerEnter2D(Collider2D other) {
		IPowerUp powerUp = null;
		if (powerUps.Count > 0) {
			int random = UnityEngine.Random.Range (1, powerUps.Count);
			powerUp = powerUps[random];
		}

		// Attempt to get the Collider2D object's GameObject. If parent existed, get the parent GameObject instead.
		GameObject o = other.gameObject;
		if (o.tag == "Player" && o.GetComponents (typeof(Avatar)).Length > 0) {
			foreach (Avatar obj in o.GetComponents(typeof(Avatar))) {
				if (powerUp != null) {
					obj.powerUp = powerUp;
				}
			}
			ParticleSystem particleSystem = GetComponent<ParticleSystem>();
			particleSystem.startColor = Color.red;

			//StartCoroutine(Kill());
			Destroy (this.gameObject);
		}
	}

	public IEnumerator Kill() {
		yield return new WaitForSeconds(3f); // waits 3 seconds
		Destroy (this.gameObject);
	}
}
