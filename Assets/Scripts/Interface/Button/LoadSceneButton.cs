using UnityEngine;
using System.Collections;

/// <summary>
/// Loads the given scene when pressed.
/// </summary>
public class LoadSceneButton : ButtonBehaviour {

	public string sceneName;

	protected override void OnButtonPress()
	{
		UnityEngine.Application.LoadLevel(sceneName);
	}
}
