using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {

	private float playerScore = 0;
	
	void Update () {
		playerScore += Time.deltaTime;
	}
	
	public void IncreaseScoreByCollectable(int amount){
		playerScore += amount;
	}
	
	void OnGUI(){
		GUI.Label (new Rect (0, 0, 100, 30), "Score: " + (int)(playerScore * 100));
	}
}
