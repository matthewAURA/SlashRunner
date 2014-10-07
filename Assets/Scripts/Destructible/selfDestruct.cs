using UnityEngine;
using System.Collections;

/*Destroys the current GameObject object the script is applied to after 1 second.
 *Should be used on an object already undergoing destruction, eg
 *a box breaking. Will be replaced with a 'item' object*/

public class selfDestruct : MonoBehaviour {

	public GameObject item;
	// Use this for initialization
	void Start () {

		Invoke("destruct", 0.5f);
		GameObject pickup = (GameObject) Instantiate(item, transform.position, transform.rotation);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void destruct(){
		Destroy(gameObject);
	}

}

	
