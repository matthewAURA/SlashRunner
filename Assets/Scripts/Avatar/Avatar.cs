using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Avatar : MonoBehaviour {

	private InputMap inputMap;

	// Use this for initialization
	void Start () {
		Debug.Log("I am here");
		inputMap = InputMap.getInputMap();
		inputMap.Add(MultiPlatformInputs.UpArrow, jump);
		inputMap.Add(MultiPlatformInputs.SwipeUp, jump);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void jump () {
		Debug.Log("I am jumpping");
	}
}
