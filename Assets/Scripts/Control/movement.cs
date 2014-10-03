using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	private GameObject player;


	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");	
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.platform == RuntimePlatform.Android) {
						var touch = Input.GetTouch (0);
						print (Input.GetKey ("right"));
						if (touch.position.x > (Screen.width / 2)) {
								player.rigidbody2D.AddRelativeForce (new Vector2 (10, 0));
						} else {
								player.rigidbody2D.AddRelativeForce (new Vector2 (-10, 0));
						}
				} else {
						print (Input.GetKey("right"));
						if (Input.GetKey ("right")) {
								player.rigidbody2D.AddForce (new Vector2 (10, 0));
						} else if (Input.GetKey ("left")) {
								player.rigidbody2D.AddForce (new Vector2 (-10, 0));
						}

						if (Input.GetKey("space")){
								player.rigidbody2D.AddForce(new Vector2(0,50));
						}
				}
	}
}
