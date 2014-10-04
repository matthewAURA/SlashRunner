using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour {

	/// <summary>
	/// Object to follow
	/// </summary>
	public Transform target;

	private float width;

	/// <summary>
	/// Template to spawn more of
	/// </summary>
	public Transform spawn;

	/// <summary>
	/// Y height to spawn templates at
	/// </summary>
	private float yHeight;

	private Transform active;

	private Queue sectionQueue;

	// Use this for initialization
	void Start () {
		yHeight = this.spawn.position.y;
		width = this.target.collider2D.bounds.size.x;
		this.sectionQueue = new Queue ();
		this.sectionQueue.Enqueue ((Transform)Instantiate(spawn)); 
		this.active = (Transform)this.sectionQueue.Peek();
	}
	
	// Update is called once per frame
	void Update () {
		if (target && spawn) {
			//If we have reached the end of the active block
			if (this.target.position.x + width/2 > this.active.position.x + this.active.collider2D.bounds.size.x/2){
				//Update the active
				this.active = (Transform)Instantiate(this.active);
				this.active.position = new Vector3(this.active.position.x + this.active.collider2D.bounds.size.x - width/2,yHeight);
				this.sectionQueue.Enqueue(this.active);
				if (this.sectionQueue.Count > 3){
					Destroy(((Transform)this.sectionQueue.Dequeue()).gameObject);
				}
			}


		}
	}

}
