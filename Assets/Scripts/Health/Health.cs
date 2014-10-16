using UnityEngine;
using System.Collections;
using System;

public class Health : MonoBehaviour {
	
	public int hp;
	public TimeSpan healthCoolDown = new TimeSpan(0, 0, 0, 1, 0);
	private DateTime lastDamage;
	public AudioClip dieSound;

	protected void takeDamage(int amount){
		if (DateTime.Now.Subtract(lastDamage) > healthCoolDown) {
			hp -= amount;
			lastDamage = DateTime.Now;
			if (hp <= 0) {
					Die ();
			} else {
					OnHealthChange ();
			}
		}
	}

	protected virtual void OnHealthChange() {

	}
	
	//Allows subclasses to override for different death behaviour
	protected virtual void BeforeDeath() {
		
	}

	//Allows subclasses to override for different death behaviour
	protected virtual void AfterDeath() {

	}

	protected void Die(){

		BeforeDeath ();

		if (dieSound != null) {
			AudioSource.PlayClipAtPoint (dieSound, transform.position);	
		}
		

		GameObject o = this.gameObject.transform.parent == null ? this.gameObject : this.gameObject.transform.parent.gameObject;
		Destroy (o);
		AfterDeath ();

	}
}
