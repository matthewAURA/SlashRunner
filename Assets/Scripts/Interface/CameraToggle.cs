using UnityEngine;
using System.Collections;

public class CameraToggle : MonoBehaviour {

	public bool cameraMode = false;
	GUIStyle style;
	// Use this for initialization
	void Start () {
		style = new GUIStyle ();
		style.fontSize = 30;
		style.fixedWidth = 500;
		style.fixedWidth = 500;
	}

	void OnGUI(){
		cameraMode = GUI.Toggle(new Rect(200, 200, 150, 20), cameraMode,"Camera Mode",style);
		//GUI.Label (new Rect(230, 200, 150, 20), "Camera Mode",style);
		//GUI.enabled = cameraMode;
	}

	void Update(){
		if (cameraMode) {
			PlayerPrefs.SetInt("CameraMode", 1);		
		} else {
			PlayerPrefs.SetInt("CameraMode",0);		
		}
	}
}
