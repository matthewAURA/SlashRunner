using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour {

	/// <summary>
	/// Object to spawn more instances of
	/// </summary>
	public Transform target;

	private float yHeight;

	// Use this for initialization
	void Start () {
		yHeight = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (target) {
			var tPos = target.position;
			tPos.y = yHeight;
			Debug.Log (yHeight);

			if (tPos.x + target.collider2D.bounds.size.x/2 > transform.position.x+ this.collider2D.bounds.size.x/2){
				tPos.x = tPos.x - target.collider2D.bounds.size.x/2 + this.collider2D.bounds.size.x/2;
				transform.position = tPos;
			}


		}
	}
}
