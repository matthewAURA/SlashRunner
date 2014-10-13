using UnityEngine;
using System.Collections;

public class Scene_Tracking : MonoBehaviour {

	private static int previouseScene;
	private static int currentScene;

	void Awake () {
		DontDestroyOnLoad(gameObject);
		currentScene = Application.loadedLevel;
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevel != currentScene) {
			previouseScene = currentScene;
			currentScene = Application.loadedLevel;
		}
	}

	public static int GetPreviouseScene() {
		return previouseScene;
	}
}