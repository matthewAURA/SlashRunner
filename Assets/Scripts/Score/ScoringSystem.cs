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
		if (highScores.Count == 0) {
			highScores.Add(entry);
		}else if (highScores.Count == 1) {
			if((int)highScores[0].score < (int)entry.score){
				highScores.Insert(0,entry);
			}else{
				highScores.Add(entry);
			}
		}else{
			for (int i = 0; i < highScores.Count; i++) { 
				if ((int)highScores[i].score < (int)entry.score){
					if(highScores.Count < MAX_NUMBER_OF_HIGH_SCORE){
						highScores.Insert(i, entry);
						break;
					}else{
						if (i == MAX_NUMBER_OF_HIGH_SCORE - 1){
							highScores[i] = entry;
						}else{
							highScores[i + 1] = entry;
						}
						break;
					}
				}
			}
		}
		SaveScores ();
	}


	void Start(){
		playerScore = new ScoringSystem.ScoreEntry ();
		playerScore.name = "Player 1";
		playerScore.score = 0;
		InitializeHighScore ();



	}

	void Update(){
		playerScore.score += Time.deltaTime * 100;
		PlayerPrefs.SetInt ("Score", (int)playerScore.score);
	}

	void OnDisable(){
		PlayerPrefs.SetFloat ("Score", playerScore.score);
		PlayerPrefs.SetString ("Name", playerScore.name);
		PlayerPrefs.SetInt ("Score", (int)playerScore.score);
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
		PlayerPrefs.DeleteAll ();
	}
}