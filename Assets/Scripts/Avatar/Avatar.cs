using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Avatar : MonoBehaviour {

	[SerializeField] LayerMask whatIsGround = 0;
	Transform groundCheck;								
	float groundedRadius = 0.2f;	
	bool grounded = false;

	private InputMap inputMap;


	void Awake() {
		inputMap = InputMap.getInputMap();
		inputMap.Add(MultiPlatformInputs.UpArrow, jump);
		inputMap.Add(MultiPlatformInputs.SwipeUp, jump);
		groundCheck = transform.Find ("GroundCheck");
	}

	// Use this for initialization
	void Start () {

	}

	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {
		if (grounded) {
			Debug.Log ("I am on the ground");
		} else {
			Debug.Log ("Not on the ground");
		}
	}

	public void jump () {
		Debug.Log("I am jumpping");
	}
}
