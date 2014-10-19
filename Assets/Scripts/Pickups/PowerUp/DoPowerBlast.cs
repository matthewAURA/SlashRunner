using UnityEngine;
using System.Collections;

public class DoPowerBlast : MonoBehaviour, IPowerUp {

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
		Instantiate(powerBlast, avatar.transform.position, avatar.transform.rotation);
	}
}
