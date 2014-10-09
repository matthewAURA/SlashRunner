using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public int hp;

	protected void takeDamage(int amount){
		hp -= amount;
		if (hp <= 0) {
			Die ();
		} else {
			OnHealthChange();
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
		GameObject o = this.gameObject.transform.parent == null ? this.gameObject : this.gameObject.transform.parent.gameObject;
		Destroy (o);
		AfterDeath ();
	}
}
