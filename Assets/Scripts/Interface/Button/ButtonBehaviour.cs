using UnityEngine;
using System.Collections;

/// <summary>
/// Represents a component that performs some action when pressed.
/// Subclasses should implement specific functionality.
/// Gameobjects that have this component must have BoxCollider2D.
/// </summary>
public abstract class ButtonBehaviour : MonoBehaviour {

	void Start()
	{
		if (gameObject.GetComponent<BoxCollider2D>() == null)
		{
			throw new MissingComponentException("Need to have BoxCollider2D for" +
				"button to function properly");
		}
	}

	void OnMouseDown()
	{
		OnButtonPress ();
	}

	protected abstract void OnButtonPress();
}
