using UnityEngine;
using System.Collections;

public class Scene_Tracking : MonoBehaviour {

	private static int previousScene;
	private static int currentScene;

	void Awake () {
		DontDestroyOnLoad(gameObject);
		currentScene = Application.loadedLevel;
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevel != currentScene) {
			previousScene = currentScene;
			currentScene = Application.loadedLevel;
			Debug.Log("Scene tracking");
			Debug.Log (previousScene);
			Debug.Log (currentScene);
		}
	}

	public static int GetPreviousScene() {
		return previousScene;
	}
}