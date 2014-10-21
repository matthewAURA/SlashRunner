using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scene_Tracking : MonoBehaviour {

	private static string previousScene = "Menus";
	private static string currentScene = "Menus";
	private static List<string> scenes = new List<string>();

	void Awake () {
		DontDestroyOnLoad(gameObject);
		scenes.Clear ();
		scenes.Add("Menus");
		scenes.Add("Tutorial");
		scenes.Add("level01");
		scenes.Add("level02");
		scenes.Add("level03");
		scenes.Add("level04");
		scenes.Add("Menus");
		currentScene = Application.loadedLevelName;
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName != currentScene) {
			previousScene = currentScene;
			currentScene = Application.loadedLevelName;
		}
	}

	public static string GetPreviousScene() {
		if (Application.loadedLevelName != currentScene) {
			previousScene = currentScene;
			currentScene = Application.loadedLevelName;
		}
		return previousScene;
	}

	public static string GetNextLevel() {
		int nextLevel = scenes.IndexOf(previousScene) + 1;
		return scenes[nextLevel];
	}

	public static string GetNextLevelInGame() {
		int nextLevel = scenes.IndexOf(currentScene) + 1;
		return scenes[nextLevel];
	}

}