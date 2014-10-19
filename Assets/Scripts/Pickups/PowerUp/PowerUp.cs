using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUp : MonoBehaviour {

	public GameObject powerBirdSpawn;

	public GameObject powerSlowMotion;

	private List<Power> powerUps;

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


		powerUps = new List<Power> ();
		if (PlayerPrefs.HasKey ("powerKillAll")) {
			//powerUps.Add (Power.killAll);
		}
		if (PlayerPrefs.HasKey ("powerBirdSpawn")) {
			powerUps.Add (Power.birdSpawn);
		}
		if (PlayerPrefs.HasKey ("powerSlowMotion")) {
			powerUps.Add (Power.slowMotion);
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

		//Randomly select and instanciate the power up game object
		if (powerUps.Count > 0) {
			int random = UnityEngine.Random.Range (0, powerUps.Count);
			//instanciates the randomly selected power up game object
			Debug.Log (random);
			switch (powerUps[random]) {
				case Power.killAll:
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

		// Attempt to get the Collider2D object's GameObject. If parent existed, get the parent GameObject instead.
		GameObject o = other.gameObject;
		if (o.tag == "Player" && o.GetComponents (typeof(Avatar)).Length > 0) {
			foreach (Avatar obj in o.GetComponents(typeof(Avatar))) {
				if (powerUp != null) {
					obj.powerUp = powerUp;
					Debug.Log ("Set power up");
				}
			}
			//StartCoroutine(Kill());
			Destroy (this.gameObject);
		}
	}

	public IEnumerator Kill() {
		yield return new WaitForSeconds(3f); // waits 3 seconds
		Destroy (this.gameObject);
	}
}
