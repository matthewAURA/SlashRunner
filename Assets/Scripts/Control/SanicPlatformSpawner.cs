using UnityEngine;
using System.Collections;

namespace Platform{

[RequireComponent(typeof(AudioSource))]
public class SanicPlatformSpawner: PlatformSpawner {

	private bool sanic = false;

	protected override bool shouldSpawnNewSection() {

		if (sanic && base.shouldSpawnNewSection()){
			return true;
		}
		return false;
			
	}

	void OnTriggerEnter2D(Collider2D other) {
		GameObject o = other.gameObject;
		if (!sanic && o.tag == "Player") {
			sanic = true;
			audio.Play();
			Debug.Log(audio);
		}
	}

}
}