using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOverScript : MonoBehaviour {
	private ScoringSystem scoring;
	int score = 0;

	void Start () {
		Debug.Log ("Start Gameover");
		score = PlayerPrefs.GetInt ("Score");
		scoring = gameObject.GetComponent<ScoringSystem>();
		scoring.InitializeHighScore ();
	}

	void OnGUI(){
		Debug.Log ("IN ON GUI");
		Debug.Log(scoring.highScores.Count);
		GUI.Label (new Rect (Screen.width / 2 - 40, 50, 80, 30), "GAME OVER");
		int y = 70;
		foreach(ScoringSystem.ScoreEntry i in scoring.highScores){
			GUI.Label (new Rect (Screen.width / 2 - 40, y, 100, 40), "High Scores: " + i.name + " " + (int)i.score);
			y += 40;
		}
		GUI.Label( new Rect (Screen.width / 2 - 40, 300, 80, 30), "Score: " + score);

		if (GUI.Button( new Rect( Screen.width / 2 - 30, 350, 60, 30), "Reply??")){
			Application.LoadLevel(0);
		}
	}

}
