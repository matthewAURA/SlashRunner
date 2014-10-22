using UnityEngine;
using System.Collections;

/// <summary>
/// Loads the given scene when pressed.
/// </summary>
public class AchievementButton : ButtonBehaviour {

	protected override void OnButtonPress()
	{
		GameManager.Instance.ShowAchievementsUI();
	}
}
