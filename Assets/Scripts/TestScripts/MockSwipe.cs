using UnityEngine;
using System.Collections;

public class MockSwipe : MonoBehaviour {

	public InputMap inputMap;

	// Use this for initialization
	void Start () {
		Debug.Log("Starting the test for swipe input");
		inputMap = InputMap.getInputMap();
		inputMap.Add(MultiPlatformInputs.SwipeUp, upSwipe);
		inputMap.Add(MultiPlatformInputs.SwipeRight, rightSwipe);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void upSwipe() {
		Debug.Log("An up swipe was recorded");
	}

	public void rightSwipe() {
		Debug.Log("A right swipe was recorded");
	}
}
