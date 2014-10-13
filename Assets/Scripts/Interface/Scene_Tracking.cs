using UnityEngine;
using System.Collections;

public class Scene_Tracking : MonoBehaviour {

	private static int previousScene;
	private static int currentScene;

	void Awake () {
		DontDestroyOnLoad(gameObject);
		currentScene = UnityEngine.Application.loadedLevel;
	}
	
	// Update is called once per frame
	void Update () {
		if (UnityEngine.Application.loadedLevel != currentScene) {
			previousScene = currentScene;
			currentScene = UnityEngine.Application.loadedLevel;
		}
	}

	public static int GetPreviousScene() {
		return previousScene;
	}
}