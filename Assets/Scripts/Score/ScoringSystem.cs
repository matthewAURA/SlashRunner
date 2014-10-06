using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
[System.Serializable]
public class ScoringSystem : MonoBehaviour {
	private ScoreEntry playerScore;
	private int MAX_NUMBER_OF_HIGH_SCORE = 5;
	private int multiple = 1;
	
	//High score entry
	[System.Serializable]
	public class ScoreEntry{
		//Players name
		public string name;
		//Score
		public float score;
	}
	//High score table
	public List<ScoreEntry> highScores = new List<ScoreEntry>();
	
	private void SaveScores(){
		Debug.Log ("SaveScores");
		Debug.Log (highScores.Count);
		//Get a binary formatter
		var b = new BinaryFormatter();
		//Create an in memory stream
		var m = new MemoryStream();
		//Save the scores
		b.Serialize(m, highScores);
		//Add it to player prefs
		PlayerPrefs.SetString("HighScores", Convert.ToBase64String(
			m.GetBuffer()));
	}

	public void AddScoreIntoHighScore(ScoreEntry entry){
		highScores.Add (entry);
		SaveScores ();
		InitializeHighScore ();
	}
	
	void Start(){
		playerScore = new ScoringSystem.ScoreEntry ();
		playerScore.name = "Player 1";
		playerScore.score = 0;
		InitializeHighScore ();
	}

	void Update(){
		playerScore.score += Time.deltaTime * 100 * multiple;
		PlayerPrefs.SetInt ("ScoreInt", (int)playerScore.score);
	}

	public void setMultiple(int multiple){
		this.multiple = multiple;
	}

	void OnDisable(){
		PlayerPrefs.SetFloat ("ScoreFloat", playerScore.score);
		PlayerPrefs.SetString ("Name", playerScore.name);
		PlayerPrefs.SetInt ("ScoreInt", (int)playerScore.score);
	}
	public void InitializeHighScore(){
		//Get the data
		var data = PlayerPrefs.GetString("HighScores");
		//If not blank then load it
		if(!string.IsNullOrEmpty(data))
		{
			Debug.Log("Doing check");
			//Binary formatter for loading back
			var b = new BinaryFormatter();
			//Create a memory stream with the data
			var m = new MemoryStream(Convert.FromBase64String(data));
			//Load back the scores
			highScores = (List<ScoreEntry>)b.Deserialize(m);
			Debug.Log(highScores.Count);
			
		}
	}
	public void ClearHighScore(){
		highScores = new List<ScoreEntry>();
	}
}