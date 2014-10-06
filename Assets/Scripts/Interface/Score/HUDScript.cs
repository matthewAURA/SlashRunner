using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {
	private float playerScore = 0;

	void Start(){
		playerScore = PlayerPrefs.GetInt ("Score");
	}

	void Update(){
		playerScore = PlayerPrefs.GetInt ("ScoreInt");
	}

	void OnGUI(){
		GUI.Label (new Rect (0, 0, 100, 30), "Score: " + (playerScore));
	}
}