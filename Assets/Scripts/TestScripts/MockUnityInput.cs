using UnityEngine;
using System.Collections;

public class MockUnityInput : MonoBehaviour {
	
	public InputMap inputMap;
	
	// Use this for initialization
	void Start () {
		inputMap = InputMap.getInputMap();
		inputMap.Add(MultiPlatformInputs.UpArrow, upArrowKey);
		inputMap.Add(MultiPlatformInputs.DownArrow, downArrowKey);
		inputMap.Add(MultiPlatformInputs.LeftArrow, leftArrowKey);
		inputMap.Add(MultiPlatformInputs.RightArrow, rightArrowKey);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void upArrowKey() {
		Debug.Log("The up arrow key was pressed");
	}
	
	public void downArrowKey() {
		Debug.Log("The down arrow key was pressed");
	}
	
	public void leftArrowKey() {
		Debug.Log("The left arrow key was pressed");
	}
	
	public void rightArrowKey() {
		Debug.Log("The right arrow key was pressed");
	}

}
