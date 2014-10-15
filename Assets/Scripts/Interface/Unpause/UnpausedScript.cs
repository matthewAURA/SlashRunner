using UnityEngine;
using System.Collections;

public class UnpausedScript : MonoBehaviour {

	void OnLevelWasLoaded(){
		Time.timeScale = 1;
	}
}
