using System;
using UnityEngine;
using Platform;
namespace Platform
{
	public class EntitySpawner : MonoBehaviour,PlatformSpawnListener
	{
		public Transform objectToSpawn;
		public PlatformSpawner spawner;

		private int enemyCounter = 0;
		private float addHeight;
		void Start(){
			this.spawner.registerListener (this);
			addHeight = ((Collider2D)objectToSpawn.GetComponentInChildren (typeof(Collider2D))).bounds.size.y;
		}



		public void onPlatformSpawn(Vector3 pos){
				spawnNewObject (pos);
		}


		private void spawnNewObject(Vector3 pos){
			var newObject = (Transform)Instantiate (objectToSpawn);
			newObject.name = "Enemy " + enemyCounter.ToString ();
			if (((Enemy)objectToSpawn.GetComponentInChildren (typeof(Enemy))) != null) {
				((Enemy)objectToSpawn.GetComponentInChildren (typeof(Enemy))).randomise = true;
			}
			pos.y += addHeight;
			enemyCounter++;
			newObject.transform.position = pos;
		}


	}
}

