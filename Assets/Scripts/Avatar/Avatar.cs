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

	public static List<AvatarAttackListener> attackListenerList = new List<AvatarAttackListener>();

	public enum Attack {
		JUMPSWIPE, PIERCE, OVERHEADSWIPE, LOWSWIPE, JUMPSTOMP
	}

	void Awake() {
		inputMap = InputMap.getInputMap();
		inputMap.Add(MultiPlatformInputs.UpArrow, JumpSwipe);
		inputMap.Add(MultiPlatformInputs.SwipeUp, JumpSwipe);
		inputMap.Add (MultiPlatformInputs.RightArrow, Pierce);
		inputMap.Add (MultiPlatformInputs.SwipeRight, Pierce);
		inputMap.Add (MultiPlatformInputs.Shift, OverHeadSwipe);
		inputMap.Add (MultiPlatformInputs.SwipeUpRightDown, OverHeadSwipe);
		inputMap.Add (MultiPlatformInputs.DownArrow, LowSwipe);
		inputMap.Add (MultiPlatformInputs.SwipeDownRight, LowSwipe);
		inputMap.Add (MultiPlatformInputs.Space, JumpStomp);
		inputMap.Add (MultiPlatformInputs.SwipeUpRightDown, JumpStomp);

		groundCheck = transform.Find ("GroundCheck");
		anim = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {

	}

	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundedRadius, whatIsGround);
		Move ();
	}

	// Update is called once per frame
	void Update () {
		if (grounded && jumping) {
			jumping = false;
		}
	}

	public void Move() {
		if (moving) {
			rigidbody2D.velocity = new Vector2 (movementForce, rigidbody2D.velocity.y);
		}
	}

	public void JumpSwipe () {
		if (!jumping && grounded) {
			jumping = true;
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));

			foreach (AvatarAttackListener listener in attackListenerList) {
				listener.OnAvatarAttack(Attack.JUMPSWIPE);
			}
		}
	}

	public void Pierce () {
		Debug.Log ("Doing Pierce Attack");

		foreach (AvatarAttackListener listener in attackListenerList) {
			listener.OnAvatarAttack(Attack.PIERCE);
		}
	}

	public void OverHeadSwipe () {
		Debug.Log ("Doing Over Head Swipe");
		
		foreach (AvatarAttackListener listener in attackListenerList) {
			listener.OnAvatarAttack(Attack.OVERHEADSWIPE);
		}
	}

	public void LowSwipe () {
		Debug.Log ("Doing Low Swipe Attack");
		
		foreach (AvatarAttackListener listener in attackListenerList) {
			listener.OnAvatarAttack(Attack.LOWSWIPE);
		}
	}

	public void JumpStomp () {
		Debug.Log ("Doing Jump Stomp Attack");
		
		foreach (AvatarAttackListener listener in attackListenerList) {
			listener.OnAvatarAttack(Attack.LOWSWIPE);
		}
	}
}
