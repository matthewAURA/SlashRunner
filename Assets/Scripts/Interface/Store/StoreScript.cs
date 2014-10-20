using UnityEngine;
using System.Collections;

public class StoreScript : MonoBehaviour {
	private int birdPowerup;
	private int hearthPowerup;
	private int timerPowerup;
	void Start(){
		birdPowerup = PlayerPrefs.GetInt("birdPowerup");
		hearthPowerup = PlayerPrefs.GetInt("hearthPowerup");
		timerPowerup = PlayerPrefs.GetInt("timerPowerup");
		if (birdPowerup == null) {
			birdPowerup = 0;
			PlayerPrefs.SetInt("birdPowerup", birdPowerup);
		}
		if (hearthPowerup == null) {
			hearthPowerup = 0;
			PlayerPrefs.SetInt("hearthPowerup", hearthPowerup);
		}
		if (timerPowerup == null) {
			timerPowerup = 0;
			PlayerPrefs.SetInt("timerPowerup", timerPowerup);
		}
	}
	
	void OnGUI(){
		Texture image = (Texture)Resources.Load ("birdPowerUp");
		GUIContent content = new GUIContent ();
		content.image = image;
		GUIStyle style = new GUIStyle ();
		style.fontSize = (int)(Screen.width * 0.03f);
		style.alignment = TextAnchor.MiddleCenter;
		GUI.Label(new Rect (Screen.width / 8, Screen.height / 3.5f,Screen.width * 0.15f, Screen.height * 0.15f),"Bird Power Up",style);
		GUI.Label (new Rect (Screen.width / 7.3f, Screen.height / 2.5f, Screen.width * 0.15f, Screen.height * 0.1f), image);
		style.alignment = TextAnchor.MiddleLeft;
		style.fontSize = (int)(Screen.width * 0.025f);
		GUI.Label(new Rect (Screen.width / 7f, Screen.height / 2.2f,Screen.width * 0.15f, Screen.height * 0.15f),birdPowerup.ToString(),style);
		GUI.Label(new Rect (Screen.width / 5f, Screen.height / 2.2f,Screen.width * 0.15f, Screen.height * 0.15f),"100",style);
		style.alignment = TextAnchor.MiddleCenter;
		style.fontSize = (int)(Screen.width * 0.03f);
		if(GUI.Button (new Rect (Screen.width /6f, Screen.height / 1.75f, Screen.width * 0.07f, Screen.height * 0.07f), "Buy")) {
			birdPowerup += 1;
			PlayerPrefs.SetInt("birdPowerup", birdPowerup);
		}
		image = (Texture)Resources.Load ("timerPowerUp");
		content.image = image;
		GUI.Label(new Rect (Screen.width / 2, Screen.height / 3.5f,Screen.width * 0.15f, Screen.height * 0.15f),"Timer Power Up",style);
		GUI.Label (new Rect (Screen.width / 1.8f, Screen.height / 2.5f, Screen.width * 0.15f, Screen.height * 0.1f), image);
		style.alignment = TextAnchor.MiddleLeft;
		style.fontSize = (int)(Screen.width * 0.025f);
		GUI.Label(new Rect (Screen.width / 1.9f, Screen.height / 2.2f,Screen.width * 0.15f, Screen.height * 0.15f),timerPowerup.ToString(),style);
		GUI.Label(new Rect (Screen.width / 1.75f, Screen.height / 2.2f,Screen.width * 0.15f, Screen.height * 0.15f),"100",style);
		style.alignment = TextAnchor.MiddleCenter;
		style.fontSize = (int)(Screen.width * 0.03f);
		if(GUI.Button (new Rect (Screen.width /1.9f, Screen.height / 1.75f, Screen.width * 0.07f, Screen.height * 0.07f), "Buy")) {
			timerPowerup += 1;
			PlayerPrefs.SetInt("timerPowerup", timerPowerup);
		}
	}
}
