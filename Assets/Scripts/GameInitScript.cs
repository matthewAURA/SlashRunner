using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GameInitScript : MonoBehaviour {

	private static bool sAutoAuthenticate = true;

	// Use this for initialization
	void Start () {
		// recommended for debugging:
	    PlayGamesPlatform.DebugLogEnabled = true;

	    if (sAutoAuthenticate) {
            GameManager.Instance.Authenticate();
            sAutoAuthenticate = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
