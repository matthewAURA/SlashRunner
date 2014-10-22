using UnityEngine;
using System.Collections;

public class WinningScript : MonoBehaviour {
	private int score;
	public Font headerFont;
	public Font bodyFont;
	
	void Start(){
		score = PlayerPrefs.GetInt ("ScoreInt");
	}

	void OnGUI(){
		GUIStyle style = new GUIStyle();
		style.normal.textColor = Color.black;
		style.fontSize = (int)(Screen.width *0.07f);
		style.alignment = TextAnchor.MiddleCenter;
		style.font = headerFont;
		GUI.Label (new Rect ( (Screen.width / 2) - (Screen.width * 0.5f) / 2, Screen.height * 0.1f, Screen.width * 0.5f, Screen.height * 0.2f), "Level Completed!",style);
		style.normal.textColor = Color.white;
		style.fontSize =(int) (Screen.width * 0.04f);
		style.font = bodyFont;
		GUI.Label( new Rect (Screen.width / 2 - 40, Screen.height/2 - 40, 80, 30), "Score: " + score,style);

	}
}
