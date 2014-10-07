using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOverScript : MonoBehaviour {
	private ScoringSystem scoring;
	private ScoringSystem.ScoreEntry scoreEntry;

	void Start () {
		scoreEntry = new ScoringSystem.ScoreEntry ();
		scoring = gameObject.GetComponent<ScoringSystem>();
		scoreEntry.name = PlayerPrefs.GetString("Name");
		scoreEntry.score = PlayerPrefs.GetFloat ("ScoreFloat");
		scoring.AddScoreIntoHighScore (scoreEntry);
	}

	void OnGUI(){
		GUI.Label (new Rect (Screen.width / 2 - 40, 50, 80, 30), "GAME OVER");
		GUI.Label( new Rect (Screen.width / 2 - 40, Screen.height/2 - 40, 80, 30), "Score: " + (int)scoreEntry.score);
	}

}
