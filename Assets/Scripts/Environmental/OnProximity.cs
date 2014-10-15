using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Activates the specified components when this object
/// is close enough to the target object.
/// </summary>
public class OnProximity : MonoBehaviour
{
	/// <summary>
	/// Components activate when target is close enough
	/// </summary>
	public GameObject target;

	/// <summary>
	/// Semicolon-seperated class component names that are
	/// to be activated on a certain distance from target
	/// </summary>
	public string componentNames;
	private ICollection<MonoBehaviour> components;

	/// <summary>
	/// Distance from the target at which the components activate
	/// </summary>
	public double activateDistance = 30;
	
	void Start ()
	{
		PopulateComponentList ();
		SetComponents (false);
	}

	void Update ()
	{
		if (target != null)
		{
			// Activate components if target is close enough to this
			double distance = Vector3.Distance (target.transform.position,
			                                    gameObject.transform.position);
			if (distance <= activateDistance) {
				SetComponents (true);
			}
		}
	}

	/// <summary>
	/// Parses the string of components and acquires references to
	/// these components, throwing an exception if one cannot be found
	/// </summary>
	private void PopulateComponentList()
	{
		// Get component names
		components = new LinkedList<MonoBehaviour> ();
		string[] tokens = componentNames.Split (';');

		// Acquire references to components
		foreach (string token in tokens)
		{
			MonoBehaviour component = (MonoBehaviour)GetComponent(token);
			if (component == null)
			{
				throw new MissingComponentException("Component " + token + " not found.");
			}
			components.Add (component);
		}
	}

	/// <summary>
	/// Enables/disables all on-proximity components
	/// </summary>
	private void SetComponents(bool option)
	{
		foreach (MonoBehaviour component in components) {
			component.enabled = option;
		}
	}
}
