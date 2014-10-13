using UnityEngine;
using System.Collections;

/// <summary>
/// Loads the given scene when pressed.
/// </summary>
public class LoadPreviousScene : ButtonBehaviour {
	
	public string sceneName;
	
	protected override void OnButtonPress()
	{
		UnityEngine.Application.LoadLevel(Scene_Tracking.GetPreviousScene());
	}
}
