using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Avatar : MonoBehaviour {

	[SerializeField] LayerMask whatIsGround = 0;
	Transform groundCheck;								
	float groundedRadius = 0.2f;	
	bool grounded = false;
	private bool moving = true;

	private InputMap inputMap;
	public float jumpForce = 70f;
	public float movementForce = 10f;


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
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundedRadius, whatIsGround);

		move ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void move() {
		if (moving) {
			rigidbody2D.velocity = new Vector2 (movementForce, rigidbody2D.velocity.y);
		}
	}

	public void jump () {
		if (grounded) {
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
		}
	}
}
