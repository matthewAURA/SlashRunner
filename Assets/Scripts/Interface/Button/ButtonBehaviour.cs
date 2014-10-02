using UnityEngine;
using System.Collections;

/// <summary>
/// Represents a component that performs some action when pressed.
/// Subclasses should implement specific functionality. 
/// </summary>
public abstract class ButtonBehaviour : MonoBehaviour {

	void OnMouseDown()
	{
		OnButtonPress ();
	}

	protected abstract void OnButtonPress();
}
