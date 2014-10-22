using UnityEngine;
using System.Collections;

/// <summary>
/// Loads the given scene when pressed.
/// </summary>
public class HighScoreButton : ButtonBehaviour {

	protected override void OnButtonPress()
	{
		GameManager.Instance.ShowLeaderboardUI();
	}
}
