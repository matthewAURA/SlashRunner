using UnityEngine;
using System.Collections;

/* Destroys current GameObject (Script is applied to) replacing it with the child
 * remains object, based on action. Currently on left arrow, will change to
 * being hit by gesture */

public class Destructible : Health, AvatarAttackListener {
	
	void Start () {
	
	}

	public GameObject remains;
	// Update is called once per frame
	public void Destruct () {
		//if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			GameObject pieces = (GameObject) Instantiate(remains, new Vector3(transform.position.x, transform.position.y, transform.position.z+5), transform.rotation);
			Destroy (gameObject);
		//}


	
	}

	public void OnAvatarAttack(Avatar.Attack attack)
	{
		Debug.Log ("Avatar Attacked Enemy");
		Avatar.attackListenerList.Remove (this);
		
		GameObject scoreSystem = GameObject.FindGameObjectWithTag("MainCamera");
		ScoringSystem s = (ScoringSystem)scoreSystem.GetComponent("ScoringSystem");
		s.IncreaseScore(2000);

		GameObject o = transform.parent == null ? this.gameObject : this.gameObject.transform.parent.gameObject;
		this.takeDamage (1);
	}

	protected override void BeforeDeath(){
		this.Destruct ();
	}
}
