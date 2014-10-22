using UnityEngine;
using System.Collections;

public class StoreScript : MonoBehaviour {
	public int destroyPowerAmount = 300;
	public int heartPowerAmount = 1000;
	public int timerPowerAmount = 2000;

	public Font headerFont;
	public Font bodyFont;

	private int destroyPowerup;
	private int heartPowerup;
	private int timerPowerup;

	private int coin;
	private bool isEnoughMoney;
	private float startMessageTime;
	public float messageInterval;

	void Start(){
		isEnoughMoney = true;
		messageInterval = 1.5f;

		destroyPowerup = PlayerPrefs.GetInt("destroyPowerup");
		heartPowerup = PlayerPrefs.GetInt("heartPowerup");
		timerPowerup = PlayerPrefs.GetInt("timerPowerup");
		timerPowerup = PlayerPrefs.GetInt("coin");

		if (destroyPowerup == null) {
			destroyPowerup = 0;
			PlayerPrefs.SetInt("destroyPowerup", destroyPowerup);
		}

		if (heartPowerup == null) {
			heartPowerup = 0;
			PlayerPrefs.SetInt("heartPowerup", heartPowerup);
		}

		if (timerPowerup == null) {
			timerPowerup = 0;
			PlayerPrefs.SetInt("timerPowerup", timerPowerup);
		}
		if (coin == null) {
			coin = 0;
			//PlayerPrefs.SetInt("timerPowerup", timerPowerup);
		}
	}
	
	void OnGUI(){
		Texture image = new Texture ();
		GUIContent content = new GUIContent ();
		// GUI for destroy power up
		content.image = image;// load image
		GUIStyle style = new GUIStyle ();
		style.fontSize = (int)(Screen.width * 0.1f);// set font size
		style.alignment = TextAnchor.MiddleCenter;// set alignment
		style.font = headerFont;
		GUI.Label (new Rect ( (Screen.width / 2) - (Screen.width * 0.5f) / 2, Screen.height * 0.1f, Screen.width * 0.5f, Screen.height * 0.2f), "Store", style);
		style.fontSize = (int)(Screen.width * 0.025f);
		style.font = bodyFont;
		style.normal.textColor = Color.black;
		image = (Texture)Resources.Load ("destroyPowerup");
		content.image = image;
		GUI.Label(new Rect (Screen.width / 8, Screen.height / 3.5f,Screen.width * 0.15f, Screen.height * 0.15f),"Destroy Power Up",style); // header 
		GUI.Label (new Rect (Screen.width / 7.3f, Screen.height / 2.5f, Screen.width * 0.15f, Screen.height * 0.1f), image);// image
		style.alignment = TextAnchor.MiddleLeft;
		style.fontSize = (int)(Screen.width * 0.02f);
		GUI.Label(new Rect (Screen.width / 7f, Screen.height / 2.2f,Screen.width * 0.15f, Screen.height * 0.15f),destroyPowerup.ToString(),style);
		GUI.Label(new Rect (Screen.width / 5f, Screen.height / 2.2f,Screen.width * 0.15f, Screen.height * 0.15f),"100",style);
		style.alignment = TextAnchor.MiddleCenter;
		style.fontSize = (int)(Screen.width * 0.025f);
		if (destroyPowerup == 0) {
			if(GUI.Button (new Rect (Screen.width /6f, Screen.height / 1.75f, Screen.width * 0.07f, Screen.height * 0.07f), "Buy")) {
				if (coin >= destroyPowerAmount){
					destroyPowerup += 1;
					PlayerPrefs.SetInt("destroyPowerup", destroyPowerup);
				} else{
					isEnoughMoney = false;
					startMessageTime = Time.time;
				}
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
			if(GUI.Button (new Rect (Screen.width /2.3f, Screen.height / 1.75f, Screen.width * 0.07f, Screen.height * 0.07f), "Buy")) {
				if (coin >= timerPowerAmount){
					timerPowerup += 1;
					PlayerPrefs.SetInt("timerPowerup", timerPowerup);
				} else{
					isEnoughMoney = false;
					startMessageTime = Time.time;
				}
			}
		}

		image = (Texture)Resources.Load ("HeartPowerUp");
		content.image = image;
		GUI.Label(new Rect (Screen.width / 1.38f, Screen.height / 3.5f,Screen.width * 0.15f, Screen.height * 0.15f),"Heart Power Up",style);
		GUI.Label (new Rect (Screen.width / 1.3f, Screen.height / 2.5f, Screen.width * 0.15f, Screen.height * 0.1f), image);
		style.alignment = TextAnchor.MiddleLeft;
		style.fontSize = (int)(Screen.width * 0.02f);
		GUI.Label(new Rect (Screen.width / 1.32f, Screen.height / 2.2f,Screen.width * 0.15f, Screen.height * 0.15f),heartPowerup.ToString(),style);
		GUI.Label(new Rect (Screen.width / 1.25f, Screen.height / 2.2f,Screen.width * 0.15f, Screen.height * 0.15f),"100",style);
		style.alignment = TextAnchor.MiddleCenter;
		style.fontSize = (int)(Screen.width * 0.025f);
		if (heartPowerup == 0) {
			if(GUI.Button (new Rect (Screen.width /1.32f, Screen.height / 1.75f, Screen.width * 0.07f, Screen.height * 0.07f), "Buy")) {
				if (coin >= heartPowerAmount){
					heartPowerup += 1;
					PlayerPrefs.SetInt("heartPowerup", heartPowerup);
				} else{
					isEnoughMoney = false;
					startMessageTime = Time.time;
				}
			}
		}
		if (!isEnoughMoney) {
			image = (Texture)Resources.Load ("warning_background");
			content.image = image;
			style.normal.textColor = Color.white;
			GUI.Box(new Rect((Screen.width /9.2f), Screen.height / 1.95f, Screen.width /1.5f, Screen.height * 0.1f),"");
			GUI.Label(new Rect((Screen.width / 5), Screen.height / 1.8f, Screen.width /2, Screen.height * 0.02f),"Sorry, you do not have enough money to buy this item", style);
			if((Time.time - startMessageTime) >= messageInterval){
				isEnoughMoney = true;
			}
		}
	}
}
