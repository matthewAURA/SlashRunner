using System;
using UnityEngine;
using Platform;
namespace Platform
{
	public class EnemySpawner : MonoBehaviour,PlatformSpawnListener
	{
		public Transform enemy;
		public PlatformSpawner spawner;

		private float spawnHeight = 0;
		private int enemyCounter = 0;
		void Start(){
			this.spawner.registerListener (this);
			spawnHeight = 3;
		}

		public void onPlatformSpawn(Vector3 pos){
			if (UnityEngine.Random.Range (1, 5) > 3) {
				spawnEnemy (pos);
			}

		}


		private void spawnEnemy(Vector3 pos){
			var newEnemy = (Transform)Instantiate (enemy);
			newEnemy.name = "Enemy " + enemyCounter.ToString ();
			((Enemy)enemy.GetComponentInChildren (typeof(Enemy))).randomise = true;
			enemyCounter++;
			pos.y += spawnHeight;
			newEnemy.transform.position = pos;
		}


	}
}

