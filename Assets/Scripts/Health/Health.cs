using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public int hp;
	
	protected void takeDamage(int amount){
		hp -= amount;
		if (hp <= 0) {
			Die ();
		}
	}
	
	//Allows subclasses to override for different death behaviour
	protected virtual void BeforeDeath() {
		
	}

	//Allows subclasses to override for different death behaviour
	protected virtual void AfterDeath() {

	}
	
	protected void Die(){
		BeforeDeath ();
		GameObject o = this.gameObject;
		Destroy (o);
		AfterDeath ();
	}
}