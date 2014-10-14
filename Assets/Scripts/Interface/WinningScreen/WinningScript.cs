using UnityEngine;
using System.Collections;

public class WinningScript : MonoBehaviour {
	private int score;
	
	void Start(){
		score = PlayerPrefs.GetInt ("ScoreInt");
	}

	void OnGUI(){
		GUIStyle style = new GUIStyle();
		style.normal.textColor = Color.blue;
		style.fontSize = 80;
		style.alignment = TextAnchor.MiddleCenter;
		GUI.Label (new Rect (Screen.width / 2 - 40, 50, 80, 30), "CONGRATULATION",style);
		style.normal.textColor = Color.white;
		style.fontSize = 40;
		GUI.Label( new Rect (Screen.width / 2 - 40, Screen.height/2 - 40, 80, 30), "Score: " + score,style);

	}
}
