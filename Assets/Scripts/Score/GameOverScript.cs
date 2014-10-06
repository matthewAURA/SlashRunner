using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOverScript : MonoBehaviour {
	private ScoringSystem scoring;
	private ScoringSystem.ScoreEntry scoreEntry;

	void Start () {
		Debug.Log ("Start Gameover");
		scoreEntry = new ScoringSystem.ScoreEntry ();
		scoreEntry.score = PlayerPrefs.GetFloat ("ScoreFloat");
		Debug.Log ((int)scoreEntry.score);
		scoreEntry.name = PlayerPrefs.GetString ("Name");
		scoring = gameObject.GetComponent<ScoringSystem>();
		scoring.InitializeHighScore ();
		scoring.AddScoreIntoHighScore (scoreEntry);
	}

	void OnGUI(){
		Debug.Log ("IN ON GUI");
		Debug.Log(scoring.highScores.Count);
		GUI.Label (new Rect (Screen.width / 2 - 40, 50, 80, 30), "GAME OVER");
		int y = 70;
		foreach(var i in scoring.highScores){
			GUI.Label (new Rect (Screen.width / 2 - 40, y, 100, 40), "High Scores: " + i.name + " " + (int)i.score);
			y += 40;
		}
		GUI.Label( new Rect (Screen.width / 2 - 40, 300, 80, 30), "Score: " + (int)scoreEntry.score);

		if (GUI.Button( new Rect( Screen.width / 2 - 30, 350, 60, 30), "Reply??")){
			Application.LoadLevel(0);
		}
	}

}
