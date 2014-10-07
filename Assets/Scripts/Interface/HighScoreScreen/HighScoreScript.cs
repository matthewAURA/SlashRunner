using UnityEngine;
using System.Collections;

public class HighScoreScript : MonoBehaviour {
	private ScoringSystem scoring;
	// Use this for initialization
	void Start () {
		scoring = gameObject.GetComponent<ScoringSystem>();
	}
	
	// Update is called once per frame
	void OnGUI () {
		int y = 140;
		GUIStyle style = new GUIStyle();
		style.fontSize = 80;
		style.alignment = TextAnchor.MiddleCenter;
		GUI.Label (new Rect (Screen.width / 2 - 40, 50, 100, 50), "HIGH SCORES:", style);
		style.fontSize = 30;
		foreach(var i in scoring.highScores){
			GUI.Label (new Rect (Screen.width / 2 - 40, y, 100, 40),i.name + ": " + (int)i.score, style);
			y += 40;
			if (y >= 140 + 40 * 5){
				break;
			}
		}
	}
}
