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
	private int multiple = 1;
	public bool isEndless;
	public List<ScoreEntry> highScores = new List<ScoreEntry>();

	[System.Serializable]
	public class ScoreEntry{
		public string name;
		public float score;
	}

	public void IncreaseScore(int amount){
		playerScore.score += amount * multiple;
	}

	private void SaveScores(){
		var binaryFormmater = new BinaryFormatter();
		var memoryStream = new MemoryStream();
		//Save the scores
		binaryFormmater.Serialize(memoryStream, highScores);
		//Add it to player prefs
		PlayerPrefs.SetString("HighScores", Convert.ToBase64String(
			memoryStream.GetBuffer()));
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
		if (isEndless) {
			playerScore.score += Time.deltaTime * 10 * multiple;
		}
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
		var data = PlayerPrefs.GetString("HighScores");
		if(!string.IsNullOrEmpty(data)){
			var b = new BinaryFormatter();
			var m = new MemoryStream(Convert.FromBase64String(data));
			//Load back the scores
			highScores = (List<ScoreEntry>)b.Deserialize(m);
			// Debug.Log(highScores.Count);
			
		}
	}

	public void ClearHighScore(){
		PlayerPrefs.DeleteAll();
		InitializeHighScore ();
	}
}