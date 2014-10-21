using UnityEngine;
using System.Collections;

public class CameraToggle : ButtonBehaviour {

	public bool cameraMode = false;
	public Sprite onButtonSprite;
	public Sprite offButtonSprite;

	protected override void OnButtonPress(){
		cameraMode = !cameraMode;
		Debug.Log(cameraMode.ToString());

		if (cameraMode) {
			PlayerPrefs.SetInt("CameraMode",1);
		} else {
			PlayerPrefs.SetInt("CameraMode",0);
		}
	}
	

	void Update(){
		if (PlayerPrefs.GetInt("CameraMode")==1) {
			GetComponent<SpriteRenderer> ().sprite = onButtonSprite;
		} else {
			GetComponent<SpriteRenderer> ().sprite = offButtonSprite;
		}
	}
}
