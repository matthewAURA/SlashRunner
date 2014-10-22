using UnityEngine;
using System.Collections;

/* Destroys current GameObject (Script is applied to) replacing it with the child
 * remains object, based on action. Currently on left arrow, will change to
 * being hit by gesture */

public class Destructible : Health, AvatarAttackListener {

	private float wait;

	public virtual void Awake() {

	}

	void Start () {
	
	}

	public GameObject remains;

	public void Destruct () {
		if(remains != null){
			Instantiate(remains, new Vector3(transform.position.x, transform.position.y, transform.position.z+5), transform.rotation);
		}
	}
	
	protected void DetermineWaitTime(Avatar.Attack attack) {
		switch (attack) {
		case Avatar.Attack.JUMPSWIPE:
			wait = 0.3f;
			break;
		case Avatar.Attack.LOWSWIPE:
			wait = 0.2f;
			break;
		case Avatar.Attack.JUMPSTOMP:
			wait = 0.5f;
			break;
		case Avatar.Attack.OVERHEADSWIPE:
			wait = 0.2f;
			break;
		default:
			break;
		}
	}

	public virtual void OnAvatarAttack(Avatar.Attack attack)
	{
		// Debug.Log ("Avatar Attacked Enemy");
		Avatar.attackListenerList.Remove (this);
		DetermineWaitTime(attack);
		
		this.takeDamage (1);
	}

	protected override void BeforeDeath(){

		Transform attackRangeBox = this.gameObject.transform.parent.Find ("AttackRange");
		if(attackRangeBox != null) {
			Destroy (attackRangeBox.gameObject);
		}

		if (dieSound != null) {
			AudioSource.PlayClipAtPoint (dieSound, transform.position);	
		}

	}

	public IEnumerator waitTime() {
		yield return new WaitForSeconds(wait);// waits 5 seconds
		this.Destruct ();
		GameObject o = this.gameObject.transform.parent == null ? this.gameObject : this.gameObject.transform.parent.gameObject;
		Destroy (o);
		AfterDeath ();
		
	}
	
	protected override void Die(){
		
		BeforeDeath ();
		
		//if (dieSound != null) {
		//	AudioSource.PlayClipAtPoint (dieSound, transform.position);	
		//}
		
		StartCoroutine(waitTime ());

	}

}
