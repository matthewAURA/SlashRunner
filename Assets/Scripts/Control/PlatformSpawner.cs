using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour {
	
	/// <summary>
	/// Object to follow
	/// </summary>
	public Transform target;

	
	/// <summary>
	/// Template to spawn more of
	/// </summary>
	public Transform spawn;
	
	/// <summary>
	/// Y height to spawn templates at
	/// </summary>
	private float yHeight;
	
	private Transform active;
	private int platformID;
	private Queue sectionQueue;
	
	// Use this for initialization
	void Start () {
		this.platformID = 0;
		yHeight = this.spawn.position.y;
		this.sectionQueue = new Queue ();
		this.sectionQueue.Enqueue ((Transform)Instantiate(spawn)); 
		this.active = (Transform)this.sectionQueue.Peek();
	}
	
	// Update is called once per frame
	void Update () {
		if (target && spawn) {
			//If we have reached the end of the active block
			if (this.shouldSpawn()){
				//Update the active

				this.active = this.spawnSection(this.calculateSpawnPosition());
				this.sectionQueue.Enqueue(this.active);
				if (this.sectionQueue.Count > 5){
					Destroy(((Transform)this.sectionQueue.Dequeue()).gameObject);
				}
			}
			
			
		}
	}

	private bool shouldSpawn(){
		var width = this.target.collider2D.bounds.size.x;
		return this.target.position.x + width / 2 > this.active.position.x - this.active.collider2D.bounds.size.x*2;
	}

	private Vector3 calculateSpawnPosition(){
		var width = this.target.collider2D.bounds.size.x;
		return new Vector3 (this.active.position.x + this.active.collider2D.bounds.size.x - width / 2, yHeight);
	}

	private Transform spawnSection(Vector3 position){
		var newSection = (Transform)Instantiate (this.spawn);
		newSection.name = spawn.name + " " + this.platformID.ToString ();
		this.platformID++;
		newSection.position = position;
		return newSection;
	}
	
}
