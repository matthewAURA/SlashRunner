using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttackActionScript : MonoBehaviour, AvatarAttackListener {

	private List<GameObject> itemsWithinRange;
	public Transform target;

	// Use this for initialization
	void Start () {
		Avatar.RegisterAttackListener (this);
		itemsWithinRange = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {

		// Let the attack range collision box follow the target
		if (target != null) {
			transform.position = new Vector3 (target.position.x, target.position.y);
		} else {
			Debug.Log ("******* SHOULD ATTACH TO A TARGET *******");
		}
	}

	// Method for handling when object with 2D collider enters the Attack-Range-Box
	void OnTriggerEnter2D(Collider2D other) {

		// Attempt to get the Collider2D object's GameObject. If parent existed, get the parent GameObject instead.
		GameObject o = other.gameObject.transform.parent == null ? other.gameObject : other.gameObject.transform.parent.gameObject;
		Debug.Log ("Added " + o.tag + " to list");

		// Add to the list
		itemsWithinRange.Add (o);

	}

	// Method for handling when object with 2D collider exits the Attack-Range-Box
	void OnTriggerExit2D(Collider2D other) {
		// Attempt to get the Collider2D object's GameObject. If parent existed, get the parent GameObject instead.
		GameObject o = other.gameObject.transform.parent == null ? other.gameObject : other.gameObject.transform.parent.gameObject;
		Debug.Log ("Removed " + o.tag + " from list");

		// Remove from the list
		itemsWithinRange.Remove (o);
	}


	// Method for handling when the player sends out an attack notification
	public void OnAvatarAttack(Avatar.Attack attack) {

		// List for storing items to be deleted
		List<GameObject> markForDelete = new List<GameObject>();

		// For each item in the list, check the tag of the GameObject and 
		// perform appropriate tasks
		foreach (GameObject o in itemsWithinRange) {

			// ENEMY Tag
			if(o.tag == "Enemy") {

				Debug.Log ("Killing enemy with " + attack.ToString() + " attack");

				if(attack == Avatar.Attack.JUMP) {

					// TODO: JUMP ATTACK ACTION
					markForDelete.Add(o);
					Destroy (o);

				} else if (attack == Avatar.Attack.PIERCE) {

					// TODO: JUMP ATTACK ACTION
					markForDelete.Add(o);
					Destroy (o);

				} else {
					Debug.Log ("Unknown attack mode");
				}
			
			// DESTRUCTABLE tag
			} else if (o.tag == "Destructable") {
				Debug.Log ("Destroying blocks");

			// NON INTERESTED tags
			} else {
				continue;
			}
		}

		// Remove items that has been marked for deletion.
		foreach (GameObject o in markForDelete) {
			Debug.Log ("Removed " + o.tag + " from list");
			itemsWithinRange.Remove(o);
		}
	}
}
