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
	
	//High score entry
	[System.Serializable]
	public class ScoreEntry{
		//Players name
		public string name;
		//Score
		public int score;
	}
	//High score table
	public List<ScoreEntry> highScores = new List<ScoreEntry>();
	
	public void SaveScores(){
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
	
	void Start(){
		Debug.Log ("Start");
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