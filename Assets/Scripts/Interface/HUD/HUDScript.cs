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
		style.fontSize = (int)(Screen.width * 0.02f);
		GUI.Label (new Rect (0, 0, Screen.width * 0.02f,Screen.height * 0.02f), "Score: " + (playerScore), style);
		Texture image = (Texture)Resources.Load ("shadedDark14");
		GUIContent content = new GUIContent();
		content.image = image;
		if (GUI.Button (new Rect (Screen.width - Screen.width * 0.05f, Screen.height * 0.03f, Screen.width * 0.04f, Screen.width * 0.04f), image)) {
			pause = true;
		}
		float left = 150;
		style.fontSize = (int)(Screen.width * 0.01f);
		if (pause) {
			GUI.Box(new Rect( Screen.width / 2 - Screen.width / 12, Screen.height / 2 - Screen.height / 4, Screen.width / 6 , Screen.height / 2.5f), "Menu");
			if (GUI.Button (new Rect( Screen.width / 2 - Screen.width / 14, Screen.height / 2 - Screen.height / 5f, Screen.width / 7 , Screen.height / 15), "Resume")){
				pause = false;
				Time.timeScale = 1;
			}
			if (GUI.Button (new Rect(Screen.width / 2 - Screen.width / 14, Screen.height / 2 - Screen.height / 7.4f, Screen.width / 7 , Screen.height / 15), "Exit to Main Menu")){
				Application.LoadLevel("Menus");
			}
			if (GUI.Button (new Rect(Screen.width / 2 - Screen.width / 14, Screen.height / 2 - Screen.height / 14.5f, Screen.width / 7 , Screen.height / 15), "Quit Game")){
				Application.Quit();
			}
			if (isMusicMuted){
				musicButton = "ON";
			}else{
				musicButton = "OFF";
			}
			GUI.Label(new Rect (Screen.width / 2 - Screen.width / 14, Screen.height / 2 - Screen.height / 15f +  Screen.height / 13, Screen.width / 7 , Screen.height / 15),"Music");
			if (GUI.Button (new Rect(Screen.width / 2, Screen.height / 2 - Screen.height / 15f +  Screen.height / 14, Screen.width / 35 , Screen.height / 20), musicButton)){
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
			GUI.Label(new Rect(Screen.width / 2 - Screen.width / 14, Screen.height / 2 - Screen.height / 15f +  Screen.height * 2f / 14 , Screen.width / 7 , Screen.height / 15),"Sound Effect");
			if (GUI.Button (new Rect(Screen.width / 2 , Screen.height / 2 - Screen.height / 15f +  Screen.height * 2f / 14 , Screen.width / 35 , Screen.height / 20), soundEffectButton)){
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