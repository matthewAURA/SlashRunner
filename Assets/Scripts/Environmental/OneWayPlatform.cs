using UnityEngine;
using System.Collections;

public class OneWayPlatform : MonoBehaviour {

	Rigidbody2D player;
	Avatar avatar;
	float platformTop;
	float playerFeet;
	// Use this for initialization
	void Start () {
		GameObject g = GameObject.Find ("Character");
		player = g.rigidbody2D;
		avatar = g.GetComponent<Avatar> ();

		platformTop = this.transform.collider2D.bounds.center.y + this.transform.collider2D.bounds.size.y / 2;
		/*
		Debug.Log ("platform height: "+this.transform.collider2D.bounds.size.y);
		Debug.Log ("platform y: "+this.transform.collider2D.bounds.center.y);
		Debug.Log ("platform top: " + platformTop);

		float playerFeet = player.collider2D.bounds.center.y - player.collider2D.bounds.size.y / 2;
		Debug.Log ("player height: "+player.collider2D.bounds.size.y);
		Debug.Log ("player y: "+player.collider2D.bounds.center.y);
		Debug.Log ("player feet: " + playerFeet);
		*/
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (avatar.grounded);
		//does not work for sloped platforms
		float playerFeet = player.position.y + player.collider2D.bounds.size.y / 2;
		if(player.velocity.y <= 0 && platformTop < playerFeet){
			activate();
		}else{
			deactivate();
		}
	}

	void deactivate(){
		//Debug.Log ("deactivate");
		this.collider2D.enabled = false;
	}

	void activate(){
		//Debug.Log ("activate");
		this.collider2D.enabled = true;
	}
}
