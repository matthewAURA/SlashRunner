using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {

	private float playerScore = 0;
	private int multiple = 1;
	void Update () {
		playerScore += Time.deltaTime * multiple;
	}
	
	public void IncreaseScoreByCollectable(int amount){
		playerScore += amount;
	}

	public void SetMultiple(int multiple){
		this.multiple = multiple;
	}

	
	void OnGUI(){
		GUI.Label (new Rect (0, 0, 100, 30), "Score: " + (int)(playerScore * 100));
	}
}
