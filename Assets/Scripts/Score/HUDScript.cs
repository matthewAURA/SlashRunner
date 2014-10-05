using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {
	private ScoringSystem.ScoreEntry scoreEntry;
	private ScoringSystem scoringSystem;
	private float playerScore = 0;

	void Start(){
		scoreEntry = new ScoringSystem.ScoreEntry();
		scoringSystem = gameObject.GetComponent<ScoringSystem>();
	}
	void Update () {
		playerScore += Time.deltaTime * 100;
	}
	
	public void IncreaseScore(int amount){
		playerScore += amount;
	}

	void OnDisable(){
		Debug.Log("OnDisable");
		scoreEntry.name = "Player 1";
		scoreEntry.score = (int)playerScore;
		scoringSystem.highScores.Add (scoreEntry);
		Debug.Log (scoringSystem.highScores.Count);
		scoringSystem.SaveScores ();
	}

	void OnGUI(){
		GUI.Label (new Rect (0, 0, 100, 30), "Score: " + (int)(playerScore));
	}
}