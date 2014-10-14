using UnityEngine;
using System.Collections;

public class OneWayPlatform : MonoBehaviour {

	Rigidbody2D player;
	Avatar avatar;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Avatar").rigidbody2D;

		avatar = GameObject.Find ("Avatar").GetComponent<Avatar> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("grounded: " + avatar.grounded);
		if(!avatar.grounded && player.velocity.y <= -1){
			activate();
		}else{
			deactivate();
		}
		//Debug.Log ("feet: " + feet.position.y + " platform: " + this.transform.position.y);
	}

	void deactivate(){
		Debug.Log ("deactivate");
		this.collider2D.enabled = false;
	}

	void activate(){
		Debug.Log ("activate");
		this.collider2D.enabled = true;
	}
}
