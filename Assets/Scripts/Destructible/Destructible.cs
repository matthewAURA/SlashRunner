using UnityEngine;
using System.Collections;

/* Destroys current GameObject (Script is applied to) replacing it with the child
 * remains object, based on action. Currently on left arrow, will change to
 * being hit by gesture */

public class Destructible : Health, AvatarAttackListener {

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

	public virtual void OnAvatarAttack(Avatar.Attack attack)
	{
		// Debug.Log ("Avatar Attacked Enemy");
		Avatar.attackListenerList.Remove (this);
		
		this.takeDamage (1);
	}

	protected override void BeforeDeath(){

		GameObject attackRangeBox = this.gameObject.transform.parent.Find ("AttackRange").gameObject;
		if(attackRangeBox != null) {
			Destroy (attackRangeBox);
		}

		if (dieSound != null) {
			AudioSource.PlayClipAtPoint (dieSound, transform.position);	
		}
		
		// TODO: ADD DELAY
		
		this.Destruct ();
	}


}
