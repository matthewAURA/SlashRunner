using UnityEngine;
using System.Collections;

public class MockSwipe : MonoBehaviour {

	public InputMap inputMap;

	// Use this for initialization
	void Start () {
		inputMap = InputMap.getInputMap();
		inputMap.Add(MultiPlatformInputs.SwipeUp, upSwipe);
		inputMap.Add(MultiPlatformInputs.SwipeDown, downSwipe);
		inputMap.Add(MultiPlatformInputs.SwipeLeft, leftSwipe);
		inputMap.Add(MultiPlatformInputs.SwipeRight, rightSwipe);
		inputMap.Add(MultiPlatformInputs.SwipeUpLeft, upLeftSwipe);
		inputMap.Add(MultiPlatformInputs.SwipeUpRight, upRightSwipe);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void upSwipe() {
		Debug.Log("An up swipe was recorded");
	}

	public void downSwipe() {
		Debug.Log("A down swipe was recorded");
	}

	public void leftSwipe() {
		Debug.Log("A left swipe was recorded");
	}

	public void rightSwipe() {
		Debug.Log("A right swipe was recorded");
	}

	public void upLeftSwipe() {
		Debug.Log("An up left swipe was recorded");
	}

	public void upRightSwipe() {
		Debug.Log("An up right swipe was recorded");
	}
}
