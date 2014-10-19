using UnityEngine;
using System.Collections;

public class OneWayPlatform : MonoBehaviour {

	GameObject playerObj;
	float platformTop;
	float playerFeet;
	// Use this for initialization

	void Start () {
		playerObj = GameObject.Find ("Character");
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
		//does not work for sloped platforms
		if(playerObj.rigidbody2D.velocity.y <= 0 && platformTop < playerObj.GetComponent<Avatar>().playerFeet){
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
