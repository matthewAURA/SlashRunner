using UnityEngine;
using System.Collections;

public class PowerBirdSpawn : MonoBehaviour, IPowerUp {

	public GameObject birds;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UsePowerUp(Avatar target) {
		if (birds != null) {
			for(int x = 0; x<15; x++) {
				GameObject bird = (GameObject) Instantiate (birds, target.transform.position, target.transform.rotation);
				//set avatar as proximity target
				OnProximity pox = bird.GetComponent<OnProximity>();
				pox.target = (GameObject) target.gameObject;
				Destroy (this.gameObject);
			}
		}
	}
}
