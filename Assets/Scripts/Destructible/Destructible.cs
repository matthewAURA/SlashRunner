using UnityEngine;
using System.Collections;

/* Destroys current GameObject (Script is applied to) replacing it with the child
 * remains object, based on action. Currently on left arrow, will change to
 * being hit by gesture */

public class Destructible : MonoBehaviour {
	
	void Start () {
	
	}

	void Update(){

	}

	public GameObject remains;
	// Update is called once per frame
	public void Destruct () {
		//if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			GameObject pieces = (GameObject) Instantiate(remains, new Vector3(transform.position.x, transform.position.y, transform.position.z+5), transform.rotation);
			Destroy (gameObject);
		//}


	
	}
}
