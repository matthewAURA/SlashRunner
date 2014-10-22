using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {
	private float playerScore = 0;
	private bool pause = false;
	private bool isMusicMuted = true;
	private string musicButton;

	private Texture image;
	private GUIContent content;
	private int coin;
	private int initialCoin;

	void Start(){
		playerScore = PlayerPrefs.GetInt ("Score");
		content = new GUIContent ();
		coin = PlayerPrefs.GetInt ("Coins");
		initialCoin = coin;
		if (coin == null) {
			coin = 0;	
		}
	}

	void Update(){
		playerScore = PlayerPrefs.GetInt ("ScoreInt");
		coin = PlayerPrefs.GetInt ("Coins");
	}

	void OnGUI(){
		GUIStyle style = new GUIStyle ();
		GUIContent content = new GUIContent();
		style.fontSize = (int)(Screen.width * 0.04f);
		GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
		Transform transform = cam.transform.Find ("Heart");
		transform.localPosition = new Vector3 (-14, 8.5f, 1);

		transform = cam.transform.Find ("PoweUpDisplay");
		transform.localPosition = new Vector3 (9, 8.5f, 1);

		//Score
		GUI.Label (new Rect (Screen.width * 0.15f, Screen.height * 0.03f, Screen.width * 0.2f,Screen.height * 0.1f), "Score: " + (playerScore), style);

		//Coin
		Texture image = (Texture)Resources.Load ("gold-coin-icon");
		GUI.Label (new Rect (Screen.width * 0.5f, Screen.height * 0.02f, Screen.width * 0.1f,Screen.height * 0.1f), image);
		GUI.Label (new Rect (Screen.width * 0.57f, Screen.height * 0.03f, Screen.width * 0.1f,Screen.height * 0.1f), (coin - initialCoin).ToString(),style);

		//Pause button
		image = (Texture)Resources.Load ("Pause");
		content.image = image;
		if (GUI.Button (new Rect (Screen.width - Screen.width * 0.09f, Screen.height * 0.03f, Screen.width * 0.07f, Screen.width * 0.07f), image)) {
			pause = true;
		}
		
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
			if (AudioListener.volume == 0){
				image = (Texture)Resources.Load ("NoMusic");
				content.image = image;
				isMusicMuted = false;
			}else{
				image = (Texture)Resources.Load ("Music");
				content.image = image;
				isMusicMuted = true;
			}
			if (GUI.Button (new Rect(Screen.width / 2 - Screen.width / 12, Screen.height / 2  + Screen.height / 25f, Screen.width / 5 , Screen.height / 15), image)){
				if(isMusicMuted == true){
					image = (Texture)Resources.Load ("NoMusic");
					content.image = image;
					isMusicMuted = false;
					AudioListener.volume = 0;
				}else{
					image = (Texture)Resources.Load ("Music");
					content.image = image;
					isMusicMuted = true;
					AudioListener.volume = 100;
				}
			}
		}
		if (pause == true) {
			Time.timeScale = 0;
		}
	}
}