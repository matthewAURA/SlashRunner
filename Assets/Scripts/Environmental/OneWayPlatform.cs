using UnityEngine;
using System.Collections;

public class OneWayPlatform : MonoBehaviour {

	Rigidbody2D player;
	Avatar avatar;

	// Use this for initialization
	void Start () {
		GameObject g = GameObject.Find ("Avatar");
		player = g.rigidbody2D;
		avatar = g.GetComponent<Avatar> ();
	}
	
	// Update is called once per frame
	void Update () {
		//does not work for sloped platforms
		if(player.velocity.y <= 0 && this.transform.position.y < player.position.y){
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
