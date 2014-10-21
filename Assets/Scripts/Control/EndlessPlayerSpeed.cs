using UnityEngine;
using System.Collections;

namespace Platform {

	public class EndlessPlayerSpeed : SpeedUpAvatarScript,PlatformSpawnListener {
		
		public PlatformSpawner spawner;

		void Start(){
			spawner.registerListener (this);
		}

		public void onPlatformSpawn(Vector3 position){
			Debug.Log ("speed up!");
			this.speedUp ();
		}
}
}