using UnityEngine;
using System.Collections;

public class DoPowerBlast : MonoBehaviour, IPowerUp {

	private InputMap input;

	public GameObject powerBlast;

	private Avatar avatar;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UsePowerUp(Avatar target) {
		avatar = target;
		input = InputMap.getInputMap ();
		input.Add (MultiPlatformInputs.Shake, Blast);
		Instantiate(powerBlast, avatar.transform.position, avatar.transform.rotation);
	}
	
	void Blast() {
		Instantiate(powerBlast, avatar.transform.position, avatar.transform.rotation);
	}
}
