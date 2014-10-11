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
		Texture2D image = (Texture2D)Resources.Load ("shadedDark14");
		GUI.skin.button.normal.background = image;
		if (GUI.Button (new Rect (Screen.width - 50, 0, 40, 40), "")) {
			pause = true;
		}
		if (pause) {
			GUI.Box(new Rect( Screen.width / 2, 100, 100, 40), "Menu");
			if (GUI.Button (new Rect(Screen.width/2 , 140, 100, 40), "Resume")){
				pause = false;
			}
			if (GUI.Button (new Rect(Screen.width/2 , 180, 100, 40), "Main Menu")){
				Application.LoadLevel(0);
			}
			if (GUI.Button (new Rect(Screen.width/2 , 220, 100, 40), "Quit")){
				Application.Quit();
			}
		}
		if (pause == true) {
			Time.timeScale = 0;
		}else{
			Time.timeScale = 1;
		}
	}
}