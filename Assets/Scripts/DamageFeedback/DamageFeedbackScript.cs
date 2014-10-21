using UnityEngine;
using System.Collections;

public class DamageFeedbackScript : MonoBehaviour {
	Vector3 originalCameraPosition;
	Vector3 camPos;
	float shakeAmt = 0;
	
	public Camera mainCamera;

	void Start(){
		Debug.Log("OASHD:OASHBF:OBHSFA");
	}

	void OnTriggerEnter2D(Collider2D other) {
		// Attempt to get the Collider2D object's GameObject. If parent existed, get the parent GameObject instead.
		GameObject o = other.gameObject;
		if (o.tag == "Player") {
			Debug.Log("OASHD:OASHBF:OBHSFA");
			shakeAmt = 0.15f;
			InvokeRepeating("CameraShake", 0, .01f);
			Invoke("StopShaking", 0.3f);
		}

		
	}
	
	void CameraShake()
	{
		if(shakeAmt>0) 
		{
			Time.timeScale = 0.8f;
			float quakeAmt = Random.value*shakeAmt*2 - shakeAmt;
			Vector3 pp = mainCamera.transform.position;
			pp.y+= quakeAmt; // can also add to x and/or z
			mainCamera.transform.position = pp;
		}
	}
	
	void StopShaking()
	{

		CancelInvoke("CameraShake");
		Time.timeScale = 1;

	}

}
