using UnityEngine;
using System.Collections;

public class Barrel : Destructible {

	[SerializeField] LayerMask whatIsGround = 0;
	Transform groundCheck;								
	public float groundedRadius = 0.2f;	
	public bool grounded = false;
	public int movementForce = -5;

	public float jumpForce = 800f;

	public bool bounce = false;

	void Awake() {
		groundCheck = transform.Find ("GroundCheck");
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(lifeTime ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		Rigidbody2D rigidbody = GetComponent<Rigidbody2D> ();
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundedRadius, whatIsGround);
		if (grounded && rigidbody.velocity.y == 0 && bounce) {
			rigidbody2D.AddForce (new Vector2 (0f, jumpForce));
		}
		rigidbody2D.velocity = new Vector2 (movementForce, rigidbody2D.velocity.y);
	}

	public void OnAvatarAttack(Avatar.Attack attack)
	{

	}

	// Method for handling when object with 2D collider enters the Attack-Range-Box
	void OnCollisionEnter2D(Collision2D other) {
		
		// Attempt to get the Collider2D object's GameObject. If parent existed, get the parent GameObject instead.
		GameObject o = other.gameObject;
		if (o.tag == "Player" && o.GetComponents(typeof(EnemyAttackListener)).Length > 0) {
			// Debug.Log ("Added " + o.tag + " to list");
			foreach(EnemyAttackListener obj in o.GetComponents(typeof(EnemyAttackListener))) {
				obj.OnEnemyAttack();
				Avatar.attackListenerList.Remove (this);
				this.takeDamage (1);
			}
		}
	}

	public IEnumerator lifeTime() {
		yield return new WaitForSeconds(5f);// waits 5 seconds
		Destroy (this.gameObject);
	}
}
