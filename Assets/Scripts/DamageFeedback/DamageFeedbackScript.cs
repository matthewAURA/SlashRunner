using UnityEngine;
using System.Collections;

public class DamageFeedbackScript : MonoBehaviour {
	public float shakeAmt = 0.15f; // Shake variable to make the shake harder
	
	public Camera mainCamera;// Camera that will be shaked

	void Start(){
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera").camera;
	}

	public void shake() {
		InvokeRepeating("CameraShake", 0, .01f);
		Invoke("StopShaking", 0.3f);
	}

	// If player collides to enemy, invoke CameraShake.
	void OnTriggerEnter2D(Collider2D other) {
		GameObject o = other.gameObject;
		if (o.tag == "Player") {
			InvokeRepeating("CameraShake", 0, .01f);
			Handheld.Vibrate();
			Invoke("StopShaking", 0.3f);
		}
	}

	// Shake camera logic
	void CameraShake()
	{
		if(shakeAmt>0) 
		{
			Time.timeScale = 0.8f;
			float quakeAmt = Random.value*shakeAmt*2 - shakeAmt;
			// move the camera to quakeAmt
			Vector3 pos = mainCamera.transform.position;
			pos.y+= quakeAmt;
			pos.x += quakeAmt;
			mainCamera.transform.position = pos;
		}
	}

	// Stop the camera from shaking
	void StopShaking()
	{
		CancelInvoke("CameraShake");
		Time.timeScale = 1;

	}

}
