using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {
	private float playerScore = 0;
	private bool pause = false;
	private bool isMusicMuted = true;
	private string musicButton;
	private bool isSoundEffectMuted = true;
	private string soundEffectButton;

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
			GUI.Box(new Rect( Screen.width / 2 - 170 / 2, 100, 170, 245), "Menu");
			if (GUI.Button (new Rect(left, 140, 150, 40), "Resume")){
				pause = false;
				Time.timeScale = 1;
			}
			if (GUI.Button (new Rect(left , 180, 150, 40), "Exit to Main Menu")){
				Application.LoadLevel("Menus");
			}
			if (GUI.Button (new Rect(left , 220, 150, 40), "Quit")){
				Application.Quit();
			}
			if (isMusicMuted){
				musicButton = "ON";
			}else{
				musicButton = "OFF";
			}
			GUI.Label(new Rect (left , 275, 150, 40),"Music");
			if (GUI.Button (new Rect(left + 90, 270, 40, 30), musicButton)){
				if(isMusicMuted == true){
					Debug.Log(true);
					musicButton = "OFF";
					isMusicMuted = false;
				}else{
					Debug.Log(false);
					musicButton = "ON";
					isMusicMuted = true;
				}
			}
			if (isSoundEffectMuted){
				soundEffectButton = "ON";
			}else{
				soundEffectButton = "OFF";
			}
			GUI.Label(new Rect (left , 305, 150, 40),"Sound Effect");
			if (GUI.Button (new Rect(left + 90, 310, 40, 30), soundEffectButton)){
				if(isSoundEffectMuted == true){
					Debug.Log(true);
					soundEffectButton = "OFF";
					isSoundEffectMuted = false;
				}else{
					Debug.Log(false);
					soundEffectButton = "ON";
					isSoundEffectMuted = true;
				}
			}
		}
		if (pause == true) {
			Time.timeScale = 0;
		}
	}
}