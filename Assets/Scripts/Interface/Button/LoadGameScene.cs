using UnityEngine;
using System.Collections;

/// <summary>
/// Loads the given scene when pressed.
/// </summary>
public class LoadGameScene : ButtonBehaviour {
	
	public string sceneName;

	public void Awake() {
		if (!PlayerPrefs.HasKey (sceneName)) {
			SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
			Color color = renderer.material.color;
			color.a -= 0.5f;
			renderer.material.color = color;
		}
	}

	protected override void OnButtonPress()
	{
		if (PlayerPrefs.HasKey (sceneName)) {
			Application.LoadLevel (sceneName);
		}
	}
}