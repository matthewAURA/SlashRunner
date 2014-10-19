using UnityEngine;
using System.Collections;

namespace Platform{

public class PlatformSpawner : MonoBehaviour {
	
	/// <summary>
	/// Object to follow
	/// </summary>
	public Transform target;

	
	/// <summary>
	/// Template to spawn more of
	/// </summary>
	public Transform spawn;
	

	private float platformSpawnHeight;
	private int sectionsSinceHeightChanged = 0;
	private Transform active;
	private int platformID;
	private Queue sectionQueue;
	private ArrayList listeners;
	
	// Use this for initialization
	void Start () {
		if (this.listeners == null) {
				this.listeners = new ArrayList ();
		}
		this.platformSpawnHeight = this.spawn.transform.position.y;
		this.platformID = 0;
		this.sectionQueue = new Queue ();
		this.sectionQueue.Enqueue ((Transform)Instantiate(spawn)); 
		this.active = (Transform)this.sectionQueue.Peek();
	}
	
	// Update is called once per frame
	void Update () {
		if (target && spawn) {
			//If we have reached the end of the active block
			if (this.shouldSpawnNewSection()){
				//Update the active

				this.active = this.spawnSection(this.calculateSpawnPosition());
				this.sectionQueue.Enqueue(this.active);
				if (this.sectionQueue.Count > 5){
					Destroy(((Transform)this.sectionQueue.Dequeue()).gameObject);
				}
			}
			
			
		}
	}

	public void registerListener(PlatformSpawnListener p){
		if (this.listeners == null) {
				this.listeners = new ArrayList();
		}
		this.listeners.Add (p);
	}


	private bool shouldSpawnNewSection(){
		var width = this.target.collider2D.bounds.size.x;
		return this.target.position.x + width / 2 > this.active.position.x - this.active.collider2D.bounds.size.x*2;
	}

	private bool shouldChangePlatformHeight(){
		this.sectionsSinceHeightChanged++;
		if (sectionsSinceHeightChanged < 3) {
			return false;
		}else if (sectionsSinceHeightChanged > 6){
			sectionsSinceHeightChanged =0;
			return true;
		}else{
			if (UnityEngine.Random.Range (0, 10) > 8){
					sectionsSinceHeightChanged =0;
					return true;
			}else{
					return false;
			}
		}
	}

	private bool shouldSpawnNewGameObject(){
			return (UnityEngine.Random.Range (0, 10) > 3);
	}

	private Vector3 calculateSpawnPosition(){
		var width = this.target.collider2D.bounds.size.x;
		if (shouldChangePlatformHeight ()) {
			this.platformSpawnHeight += Random.Range(-5,5);
		}

		return new Vector3 (this.active.position.x + this.active.collider2D.bounds.size.x - width / 2, this.platformSpawnHeight);
	}

	private Transform spawnSection(Vector3 position){
		var newSection = (Transform)Instantiate (this.spawn);
		newSection.name = spawn.name + " " + this.platformID.ToString ();
		this.platformID++;
		newSection.position = position;
		position.y = this.platformSpawnHeight + this.spawn.collider2D.bounds.size.y;
		//Notifiy listeners
		if (shouldSpawnNewGameObject()){
			var listener = this.listeners[(int)Random.Range(0,this.listeners.Count)];
			((PlatformSpawnListener)listener).onPlatformSpawn(position);
		}
	



		return newSection;
	} 
	
}
}
