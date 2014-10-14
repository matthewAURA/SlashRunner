using UnityEngine;
using System.Collections;

public class UnityInputListener : MonoBehaviour {
	
	private InputMap inputMap = InputMap.getInputMap();
	
	private bool keyUp = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor) {
			if (Input.GetAxis ("Vertical") > 0) {
				if(keyUp) {
					inputMap.FireInputEvents(MultiPlatformInputs.UpArrow);
					keyUp = false;
				}
			} else if (Input.GetAxis ("Vertical") < 0) {
				if(keyUp) {
					inputMap.FireInputEvents(MultiPlatformInputs.DownArrow);
					keyUp = false;
				}
			} else if (Input.GetAxis ("Horizontal") > 0) {
				if(keyUp) {
					inputMap.FireInputEvents(MultiPlatformInputs.RightArrow);
					keyUp = false;
				}
			} else if (Input.GetKeyDown("space")) {
				if(keyUp) {
					inputMap.FireInputEvents(MultiPlatformInputs.SpaceBar);
					keyUp = false;
				}
			} else if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift)) {
				if(keyUp) {
					inputMap.FireInputEvents(MultiPlatformInputs.Shift);
					keyUp = false;
				}
			} else if (Input.GetKeyDown(KeyCode.Return)) {
				if(keyUp) {
					inputMap.FireInputEvents(MultiPlatformInputs.Return);
					keyUp = false;
				}
			} else {
				keyUp = true;
			}
		}
	}
}
