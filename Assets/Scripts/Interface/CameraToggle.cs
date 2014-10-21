using UnityEngine;
using System.Collections;

public class CameraToggle : ButtonBehaviour {

	public bool cameraMode;
	public Sprite onButtonSprite;
	public Sprite offButtonSprite;

	void Start(){
		Debug.Log (cameraMode);
		if (PlayerPrefs.GetInt("CameraMode")==1) {
			cameraMode=true;
			GetComponent<SpriteRenderer> ().sprite = onButtonSprite;
		} else {
			cameraMode=false;
			GetComponent<SpriteRenderer> ().sprite = offButtonSprite;
		}
	}

	protected override void OnButtonPress(){
		cameraMode = !cameraMode;
		Debug.Log(cameraMode.ToString());

		if (cameraMode) {
			PlayerPrefs.SetInt("CameraMode",1);
			GetComponent<SpriteRenderer> ().sprite = onButtonSprite;
		} else {
			PlayerPrefs.SetInt("CameraMode",0);
			GetComponent<SpriteRenderer> ().sprite = offButtonSprite;
		}
	}
		
}
