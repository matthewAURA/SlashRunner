using UnityEngine;
using System.Collections;

/// <summary>
/// Loads the given scene when pressed.
/// </summary>
public class LoadMenuButton : ButtonBehaviour {
	
	public string sceneName;
	
	protected override void OnButtonPress()
	{
		Application.LoadLevel("Menus");
	}
}