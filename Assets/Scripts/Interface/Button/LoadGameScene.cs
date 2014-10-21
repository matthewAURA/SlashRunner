using UnityEngine;
using System.Collections;

/// <summary>
/// Loads the given scene when pressed.
/// </summary>
public class LoadGameScene : ButtonBehaviour {
	
	public string sceneName;
	
	protected override void OnButtonPress()
	{
		if (PlayerPrefs.HasKey(sceneName)) {
			Application.LoadLevel(sceneName);
		}
	}
}