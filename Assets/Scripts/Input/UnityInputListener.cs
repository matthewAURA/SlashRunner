using UnityEngine;
using System.Collections;

public class UnityInputListener : MonoBehaviour {

	private InputMap inputMap = InputMap.getInputMap();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor) {
			if (Input.GetAxis ("Vertical") > 0) {
				inputMap.FireInputEvents(MultiPlatformInputs.UpArrow);
			} else if (Input.GetAxis ("Vertical") < 0) {
				inputMap.FireInputEvents(MultiPlatformInputs.DownArrow);
			} else if (Input.GetAxis ("Horizontal") > 0) {
				inputMap.FireInputEvents(MultiPlatformInputs.RightArrow);
			} else if (Input.GetAxis ("Horizontal") < 0) {
				inputMap.FireInputEvents(MultiPlatformInputs.LeftArrow);
			}
		}
	}
}
