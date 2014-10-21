using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOverScript : MonoBehaviour {
	private ScoringSystem scoring;
	private ScoringSystem.ScoreEntry scoreEntry;
	private string asd = "asdasd";

	void Start () {
		scoreEntry = new ScoringSystem.ScoreEntry ();
		scoring = gameObject.GetComponent<ScoringSystem>();
		scoreEntry.name = PlayerPrefs.GetString("Name");
		scoreEntry.score = PlayerPrefs.GetFloat ("ScoreFloat");
		scoring.AddScoreIntoHighScore (scoreEntry);

		//on Death Triggers 
		//remove time powerup on death
		Time.timeScale = 1.0F;
	}

	void OnGUI(){
		GUIStyle style = new GUIStyle();
		style.normal.textColor = Color.red;
		style.fontSize = 80;
		style.alignment = TextAnchor.MiddleCenter;
		//GUI.Label (new Rect (Screen.width / 2 - 40, 50, 80, 30), "GAME OVER",style);
		style.normal.textColor = Color.white;
		style.fontSize = 40;
		GUI.Label( new Rect (Screen.width / 2 - 40, Screen.height/2 - 40, 80, 30), "Score: " + (int)scoreEntry.score,style);
	}

}
