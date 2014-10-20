using UnityEngine;
using System.Collections;

public class StoreScript : MonoBehaviour {
	public int birdPowerAmount = 300;
	public int heathPowerAmount = 1000;
	public int timerPowerAmount = 2000;

	public Font headerFont;
	public Font bodyFont;

	private int birdPowerup;
	private int hearthPowerup;
	private int timerPowerup;
	private int coin;
	void Start(){
		PlayerPrefs.DeleteKey ("birdPowerup");
		PlayerPrefs.DeleteKey ("hearthPowerup");
		PlayerPrefs.DeleteKey ("timerPowerup");
		birdPowerup = PlayerPrefs.GetInt("birdPowerup");
		hearthPowerup = PlayerPrefs.GetInt("hearthPowerup");
		timerPowerup = PlayerPrefs.GetInt("timerPowerup");
		timerPowerup = PlayerPrefs.GetInt("coin");
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
		// GUI for bird power up
		content.image = image;// load image
		GUIStyle style = new GUIStyle ();
		style.fontSize = (int)(Screen.width * 0.1f);// set font size
		style.alignment = TextAnchor.MiddleCenter;// set alignment
		style.font = headerFont;
		GUI.Label (new Rect ( (Screen.width / 2) - (Screen.width * 0.5f) / 2, Screen.height * 0.1f, Screen.width * 0.5f, Screen.height * 0.2f), "Store", style);
		style.fontSize = (int)(Screen.width * 0.025f);
		style.font = bodyFont;
		GUI.Label(new Rect (Screen.width / 8, Screen.height / 3.5f,Screen.width * 0.15f, Screen.height * 0.15f),"Bird Power Up",style); // header 
		GUI.Label (new Rect (Screen.width / 7.3f, Screen.height / 2.5f, Screen.width * 0.15f, Screen.height * 0.1f), image);// image
		style.alignment = TextAnchor.MiddleLeft;
		style.fontSize = (int)(Screen.width * 0.02f);
		GUI.Label(new Rect (Screen.width / 7f, Screen.height / 2.2f,Screen.width * 0.15f, Screen.height * 0.15f),birdPowerup.ToString(),style);
		GUI.Label(new Rect (Screen.width / 5f, Screen.height / 2.2f,Screen.width * 0.15f, Screen.height * 0.15f),"100",style);
		style.alignment = TextAnchor.MiddleCenter;
		style.fontSize = (int)(Screen.width * 0.025f);
		if (birdPowerup == 0) {
			if(GUI.Button (new Rect (Screen.width /6f, Screen.height / 1.75f, Screen.width * 0.07f, Screen.height * 0.07f), "Buy") && coin >= birdPowerAmount ) {
				birdPowerup += 1;
				PlayerPrefs.SetInt("birdPowerup", birdPowerup);
			}
		}


		image = (Texture)Resources.Load ("timerPowerUp");
		content.image = image;
		GUI.Label(new Rect (Screen.width / 2.5f, Screen.height / 3.5f,Screen.width * 0.15f, Screen.height * 0.15f),"Timer Power Up",style);
		GUI.Label (new Rect (Screen.width / 2.2f, Screen.height / 2.5f, Screen.width * 0.15f, Screen.height * 0.1f), image);
		style.alignment = TextAnchor.MiddleLeft;
		style.fontSize = (int)(Screen.width * 0.02f);
		GUI.Label(new Rect (Screen.width / 2.3f, Screen.height / 2.2f,Screen.width * 0.15f, Screen.height * 0.15f),timerPowerup.ToString(),style);
		GUI.Label(new Rect (Screen.width / 2.1f, Screen.height / 2.2f,Screen.width * 0.15f, Screen.height * 0.15f),"100",style);
		style.alignment = TextAnchor.MiddleCenter;
		style.fontSize = (int)(Screen.width * 0.025f);
		if (timerPowerup == 0) {
			if(GUI.Button (new Rect (Screen.width /2.3f, Screen.height / 1.75f, Screen.width * 0.07f, Screen.height * 0.07f), "Buy") && coin >= timerPowerAmount) {
				timerPowerup += 1;
				PlayerPrefs.SetInt("timerPowerup", timerPowerup);
			}
		}

		image = (Texture)Resources.Load ("HeartPowerUp");
		content.image = image;
		GUI.Label(new Rect (Screen.width / 1.38f, Screen.height / 3.5f,Screen.width * 0.15f, Screen.height * 0.15f),"Heart Power Up",style);
		GUI.Label (new Rect (Screen.width / 1.3f, Screen.height / 2.5f, Screen.width * 0.15f, Screen.height * 0.1f), image);
		style.alignment = TextAnchor.MiddleLeft;
		style.fontSize = (int)(Screen.width * 0.02f);
		GUI.Label(new Rect (Screen.width / 1.32f, Screen.height / 2.2f,Screen.width * 0.15f, Screen.height * 0.15f),hearthPowerup.ToString(),style);
		GUI.Label(new Rect (Screen.width / 1.25f, Screen.height / 2.2f,Screen.width * 0.15f, Screen.height * 0.15f),"100",style);
		style.alignment = TextAnchor.MiddleCenter;
		style.fontSize = (int)(Screen.width * 0.025f);
		if (hearthPowerup == 0) {
			if(GUI.Button (new Rect (Screen.width /1.32f, Screen.height / 1.75f, Screen.width * 0.07f, Screen.height * 0.07f), "Buy") && coin >= timerPowerAmount) {
				hearthPowerup += 1;
				PlayerPrefs.SetInt("hearthPowerup", timerPowerup);
			}else{

			}
		}

	}
}
