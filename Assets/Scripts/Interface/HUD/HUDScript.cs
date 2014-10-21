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
		style.fontSize = (int)(Screen.width * 0.035f);
		GUI.Label (new Rect (0, 0, Screen.width * 0.02f,Screen.height * 0.02f), "Score: " + (playerScore), style);
		Texture image = (Texture)Resources.Load ("shadedDark14");
		GUIContent content = new GUIContent();
		content.image = image;
		if (GUI.Button (new Rect (Screen.width - Screen.width * 0.07f, Screen.height * 0.03f, Screen.width * 0.05f, Screen.width * 0.05f), image)) {
			pause = true;
		}

		float left = 150;
		style.fontSize = (int)(Screen.width * 0.01f);
		if (pause) {
			image = (Texture)Resources.Load ("Resume");
			content.image = image;
			if (GUI.Button (new Rect( Screen.width / 2 - Screen.width / 12, Screen.height / 2 - Screen.height / 5f, Screen.width /5 , Screen.height / 15), image)){
				pause = false;
				Time.timeScale = 1;
			}
			image = (Texture)Resources.Load ("ExitToMenu");
			content.image = image;
			if (GUI.Button (new Rect(Screen.width / 2 - Screen.width / 12, Screen.height / 2 - Screen.height / 8.4f, Screen.width / 5 , Screen.height / 15), image)){
				Application.LoadLevel("Menus");
			}
			image = (Texture)Resources.Load ("QuitGame");
			content.image = image;
			if (GUI.Button (new Rect(Screen.width / 2 - Screen.width / 12, Screen.height / 2 - Screen.height / 25f, Screen.width / 5 , Screen.height / 15), image)){
				Application.Quit();
			}
			if (isMusicMuted){
				image = (Texture)Resources.Load ("Music");
				content.image = image;
			}else{
				image = (Texture)Resources.Load ("NoMusic");
				content.image = image;
			}
			if (GUI.Button (new Rect(Screen.width / 2 - Screen.width / 12, Screen.height / 2  + Screen.height / 25f, Screen.width / 5 , Screen.height / 15), image)){
				if(isMusicMuted == true){
					image = (Texture)Resources.Load ("NoMusic");
					content.image = image;
					isMusicMuted = false;
				}else{
					image = (Texture)Resources.Load ("Music");
					content.image = image;
					isMusicMuted = true;
				}
			}
			if (isSoundEffectMuted){
				image = (Texture)Resources.Load ("SoundEffect");
				content.image = image;
			}else{
				image = (Texture)Resources.Load ("NoSoundEffect");
				content.image = image;
			}
			if (GUI.Button (new Rect(Screen.width / 2 - Screen.width / 12, Screen.height / 2  + Screen.height / 8.5f, Screen.width / 5 , Screen.height / 15), image)){
				if(isSoundEffectMuted == true){
					Debug.Log(true);
					image = (Texture)Resources.Load ("NoSoundEffect");
					content.image = image;
					isSoundEffectMuted = false;
				}else{
					Debug.Log(false);
					image = (Texture)Resources.Load ("SoundEffect");
					content.image = image;
					isSoundEffectMuted = true;
				}
			}
		}
		if (pause == true) {
			Time.timeScale = 0;
		}
	}
}