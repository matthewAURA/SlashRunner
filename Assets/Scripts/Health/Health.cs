using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public int hp;
	
	public void takeDamage(int amount){
		hp -= amount;
		if (hp == 0) {
			die ();
		}
	}
	
	//Allows subclasses to override for different death behaviour
	public void BeforeDeath() {
		
	}

	//Allows subclasses to override for different death behaviour
	public void AfterDeath() {

	}
	
	void die(){
		BeforeDeath ();
		GameObject o = this.gameObject.transform.parent == null ? this.gameObject : this.gameObject.transform.parent.gameObject;
		Destroy (o);
		AfterDeath ();
	}
}