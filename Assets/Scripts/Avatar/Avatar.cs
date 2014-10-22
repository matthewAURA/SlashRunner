using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Avatar : Destructible, EnemyAttackListener {
	
	[SerializeField] LayerMask whatIsGround = 0;
	Transform groundCheck;								
	public float groundedRadius = 0.2f;	
	public bool grounded = false;
	bool jumping = false;
	private bool moving = true;
	Animator anim;
	GameObject slash;

	public AudioClip slashSound;
	public AudioClip healthSound;
	public AudioClip blastSound;
	public AudioClip slowSound;

	private IPowerUp powerUp;

	private InputMap inputMap;
	public float jumpForce = 500f;
	public float movementForce = 5f;
	public Sprite attackAnimation;

	public float playerFeet;
	
	public static List<AvatarAttackListener> attackListenerList = new List<AvatarAttackListener>();
	public static List<IAvatarHeathChangeListener> healthChangeListenerList = new List<IAvatarHeathChangeListener>();
	public static List<IPowerUpChangeListener> powerUpChangeListenerList = new List<IPowerUpChangeListener>();

	public enum Attack {
		JUMPSWIPE, PIERCE, OVERHEADSWIPE, LOWSWIPE, JUMPSTOMP, KILL
	}
	
	void Awake() {

		// Clean up
		attackListenerList.Clear ();
		healthChangeListenerList.Clear ();
		powerUpChangeListenerList.Clear ();
		inputMap = InputMap.getInputMap();
		inputMap.ClearDictionary ();

		// Adding input maps (delegates)
		inputMap.Add(MultiPlatformInputs.UpArrow, JumpSwipe);
		inputMap.Add(MultiPlatformInputs.SwipeUp, JumpSwipe);
		inputMap.Add (MultiPlatformInputs.RightArrow, Pierce);
		inputMap.Add (MultiPlatformInputs.SwipeRight, Pierce);
		inputMap.Add (MultiPlatformInputs.Shift, OverHeadSwipe);
		inputMap.Add (MultiPlatformInputs.SwipeRightDown, OverHeadSwipe);
		inputMap.Add (MultiPlatformInputs.SwipeRightDown, LowSwipe);
		inputMap.Add (MultiPlatformInputs.DownArrow, LowSwipe);
		inputMap.Add (MultiPlatformInputs.SwipeDown, LowSwipe);
		inputMap.Add (MultiPlatformInputs.SpaceBar, JumpStomp);
		inputMap.Add (MultiPlatformInputs.SwipeUpRightDown, JumpStomp);
		inputMap.Add (MultiPlatformInputs.Shake, GoBerserk);
		inputMap.Add (MultiPlatformInputs.Return, GoBerserk);
		
		groundCheck = transform.Find ("GroundCheck");
		anim = GetComponent<Animator> ();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundedRadius, whatIsGround);
		Move ();
		playerFeet = this.collider2D.bounds.center.y - this.collider2D.bounds.size.y / 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (slash != null)
		{
			slash.transform.position = new Vector3 (gameObject.transform.position.x + 5, 
			                                        gameObject.transform.position.y, 0);
		}
		if (grounded && jumping) {
			jumping = false;
		}
	}

	public static void RegisterHeathChangeListener (IAvatarHeathChangeListener listener) {
		healthChangeListenerList.Add (listener);
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
			
			// Debug.Log ("Doing Jump Attack");
			anim.SetTrigger("char_downslash");

			FireAttackActionEvent(Attack.JUMPSWIPE);	
		}
	}
	
	public void Pierce () {
		// Debug.Log ("Doing Pierce Attack");
		anim.SetTrigger("char_stab");

		FireAttackActionEvent(Attack.PIERCE);
	}
	
	public void OverHeadSwipe () {
		// Debug.Log ("Doing Over Head Swipe");
		anim.SetTrigger("char_downslash");

		FireAttackActionEvent(Attack.OVERHEADSWIPE);
	}
	
	public void LowSwipe () {
		// Debug.Log ("Doing Low Swipe Attack");
		anim.SetTrigger("char_upslash");

		FireAttackActionEvent(Attack.LOWSWIPE);
	}
	
	public void JumpStomp () {
		if (!jumping && grounded) {
			jumping = true;
			rigidbody2D.AddForce (new Vector2 (0f, (jumpForce*1.5f)));
			
			// Debug.Log ("Doing Jump Stomp Attack");
			anim.SetTrigger("char_stomp");

			FireAttackActionEvent(Attack.JUMPSTOMP);
		}
	}

	public void GoBerserk() {
		if (powerUp != null) {
			powerUp.UsePowerUp (this);


			if (blastSound != null && powerUp is DoPowerBlast) {
				AudioSource.PlayClipAtPoint (blastSound, transform.position);	
			}
			if (healthSound != null && powerUp is PowerBirdSpawn) {
				AudioSource.PlayClipAtPoint (healthSound, transform.position);	
			}
			if (slowSound != null && powerUp is PowerSlowMotion) {
				AudioSource.PlayClipAtPoint (slowSound, transform.position);	
			}

			setPowerUp(null);
		}
	}

	public void OnEnemyAttack() {
		// Debug.Log ("Enemy attacked avatar");
		this.takeDamage(1);
	}

	public void Kill() {
		this.Die ();
	}

	protected override void AfterDeath() {
		Application.LoadLevel("Gameover");
	}
	
	protected override void BeforeDeath() {
		this.Destruct ();
	}

	public override void OnHealthChange() {
		// Debug.Log ("AvatarTakingDamage");
		foreach (IAvatarHeathChangeListener listener in healthChangeListenerList) {
			listener.OnAvatarHealthChange(hp);
		}
	}

	
	private void FireAttackActionEvent(Avatar.Attack attack) {
		if (slashSound != null && attackListenerList.Count == 0) {
			AudioSource.PlayClipAtPoint (slashSound, transform.position);	
		}
		
		for (int i = attackListenerList.Count - 1; i >= 0; i--) {
			attackListenerList[i].OnAvatarAttack(attack);
		}
		
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Damage is caused if player is hit by colliders harmful to players
		DamagePlayerOnContact damagePlayer =
			otherCollider.GetComponent<DamagePlayerOnContact> ();
		if (damagePlayer != null)
		{
			// The health object is not attached to the avatar, hence the Find
			//GameObject healthObj = GameObject.Find("Health");
			//Health health = healthObj.GetComponent<Health>();
			//if (health != null)
			//{
			//	health.takeDamage (damagePlayer.damage);
			//	Destroy (otherCollider.gameObject);
			//}
			this.takeDamage (damagePlayer.damage);
			Destroy (otherCollider.gameObject);
		}

	}

	public IPowerUp GetPowerUp() {
		return powerUp;
	}

	public void setPowerUp(IPowerUp setPowerUp) {
		powerUp = setPowerUp;
		//notifies all game objects in power up listener list
		foreach (IPowerUpChangeListener listener in powerUpChangeListenerList) {
			listener.OnAvatarPowereUpChange (powerUp);
		}
	}

	protected override void Die(){
		
		BeforeDeath ();
		
		if (dieSound != null) {
			AudioSource.PlayClipAtPoint (dieSound, transform.position);	
		}

		Wait ();
		
	}

	void Wait() 
	{
		StartCoroutine(WaitToDie(1));
	}
	
	IEnumerator WaitToDie(float waitTime) 
	{
		GameObject o = this.gameObject.transform.parent == null ? this.gameObject : this.gameObject.transform.parent.gameObject;
		//Hide avatar sprite
		Renderer renderer = o.GetComponentInChildren< Renderer >();
		renderer.enabled = false;
		//Wait for destruction animation
		yield return new WaitForSeconds(waitTime);
		GameObject sword = this.gameObject.transform.Find("Sword").gameObject;
		Destroy(sword);
		Destroy(o);
		//Continue with after death scene
		AfterDeath ();
	}
}
