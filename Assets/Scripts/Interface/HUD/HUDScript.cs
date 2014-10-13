using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {
	private float playerScore = 0;
	private bool pause = false;

	void Start(){
		playerScore = PlayerPrefs.GetInt ("Score");
	}

	void Update(){
		playerScore = PlayerPrefs.GetInt ("ScoreInt");
	}

	void OnGUI(){
		GUIStyle style = new GUIStyle ();
		style.fontSize = 30;
		GUI.Label (new Rect (0, 0, 100, 30), "Score: " + (playerScore), style);
		Texture image = (Texture)Resources.Load ("shadedDark14");
		GUIContent content = new GUIContent();
		content.image = image;
		if (GUI.Button (new Rect (Screen.width - 50, 0, 40, 40), image)) {
			pause = true;
		}
		int left = Screen.width / 2 - 150 / 2;
		if (pause) {
			GUI.Box(new Rect( Screen.width / 2 - 170 / 2, 100, 170, 180), "Menu");
			if (GUI.Button (new Rect(left, 140, 150, 40), "Resume")){
				pause = false;
			}
			if (GUI.Button (new Rect(left , 180, 150, 40), "Exit to Main Menu")){
				UnityEngine.Application.LoadLevel(0);
			}
			if (GUI.Button (new Rect(left , 220, 150, 40), "Quit")){
				UnityEngine.Application.Quit();
			}
		}
		if (pause == true) {
			Time.timeScale = 0;
		}else{
			Time.timeScale = 1;
		}
	}
}