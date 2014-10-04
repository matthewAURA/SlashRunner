using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Avatar : MonoBehaviour {

	[SerializeField] LayerMask whatIsGround = 0;
	Transform groundCheck;								
	float groundedRadius = 0.2f;	
	bool grounded = false;
	bool jumping = false;
	private bool moving = true;
	Animator anim;

	private InputMap inputMap;
	public float jumpForce = 500f;
	public float movementForce = 5f;


	void Awake() {
		inputMap = InputMap.getInputMap();
		inputMap.Add(MultiPlatformInputs.UpArrow, jump);
		inputMap.Add(MultiPlatformInputs.SwipeUp, jump);
		groundCheck = transform.Find ("GroundCheck");
		anim = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {

	}

	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundedRadius, whatIsGround);
		Debug.Log (grounded);
		move ();
	}

	// Update is called once per frame
	void Update () {
		if (grounded && jumping) {
			jumping = false;
		}
	}

	public void move() {
		if (moving) {
			//rigidbody2D.AddForce(new Vector2(movementForce, 0f));
			if(grounded) {
				rigidbody2D.velocity = new Vector2 (movementForce, rigidbody2D.velocity.y);
			}else {
				if (jumping){
					rigidbody2D.velocity = new Vector2 (movementForce*0.9f, rigidbody2D.velocity.y);
				} else {
					rigidbody2D.velocity = new Vector2 (movementForce*0.3f, rigidbody2D.velocity.y);
				}

			}
		}
	}

	public void jump () {
		if (!jumping && grounded) {
			jumping = true;
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
		}
	}
}
