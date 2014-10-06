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

	//Attack Ranges
	public int jumpAttackRange = 5;
	public int maxSlashAttackRange = 5;
	public int minSlashAttackRange = 2;

	private static List<AvatarAttackListener> attackListenerList = new List<AvatarAttackListener>();

	public enum Attack {
		Jump, Slash
	}

	public static void RegisterAttackListener(AvatarAttackListener listener) {
		attackListenerList.Add (listener);
	}

	void Awake() {
		inputMap = InputMap.getInputMap();
		inputMap.Add(MultiPlatformInputs.UpArrow, Jump);
		inputMap.Add(MultiPlatformInputs.SwipeUp, Jump);
		inputMap.Add (MultiPlatformInputs.RightArrow, Slash);
		inputMap.Add (MultiPlatformInputs.SwipeRight, Slash);

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

	public void Jump () {
		if (!jumping && grounded) {
			jumping = true;
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
		}
	}

	public void Slash () {
		Debug.Log ("I am slashing");
		foreach (AvatarAttackListener listener in attackListenerList) {
			listener.OnAvatarAttack(Attack.Slash);
		}
	}
}
