using UnityEngine;
using System.Collections;

/// <summary>
/// Exits application when pressed. 
/// </summary>
public class ExitApplicationButton : ButtonBehaviour
{
	protected override void OnButtonPress()
	{
		Application.Quit ();
	}
}
