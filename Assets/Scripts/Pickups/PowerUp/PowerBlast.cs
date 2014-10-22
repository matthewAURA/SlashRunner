using UnityEngine;
using System.Collections;

public class PowerBlast : MonoBehaviour {
	
	private Vector3 velocity = new Vector3(50f, 0 , 0);

	// Use this for initialization
	void Start () {
		StartCoroutine(lifeTime ());
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += velocity * Time.deltaTime;
	}

	// Method for handling when object with 2D collider enters the Attack-Range-Box
	void OnTriggerEnter2D(Collider2D other) {
		// Attempt to get the Collider2D object's GameObject. If parent existed, get the parent GameObject instead.
		GameObject o = other.gameObject.transform.parent == null ? other.gameObject : other.gameObject.transform.parent.gameObject;

		if ((o.tag == "Enemy" || o.tag == "Destructible") && o.GetComponents(typeof(AvatarAttackListener)).Length > 0) {
			foreach(AvatarAttackListener obj in o.GetComponents(typeof(AvatarAttackListener))) {
				//Assume that this attack will kill all enemies
				obj.OnAvatarAttack(Avatar.Attack.KILL);
			}
		}
	}

	public IEnumerator lifeTime() {
		yield return new WaitForSeconds(1.5f);// waits 1 second
		Destroy (this.gameObject);
	}
}
