using UnityEngine;
using System.Collections;

/// <summary>
/// Shooting behaviour that constantly shoots the attached
/// Shooter every frame iff the target is close enough. 
/// </summary>
public class ProximityConstantShootBehaviour : MonoBehaviour
{

	/// <summary>
	/// Components activate when target is close enough
	/// </summary>
	public GameObject target;

	private Shooter shooter;
	
	/// <summary>
	/// Distance from the target at which the components activate
	/// </summary>
	public double activateDistance = 30;

	void Start ()
	{
		shooter = GetComponent<Shooter> ();
		if (shooter == null)
		{
			throw new MissingComponentException("Must have a Shooter script attached");
		}
	}

	void Update ()
	{
		// Activate components if target is close enough to this
		double distance = Vector3.Distance (target.transform.position,
		                                    gameObject.transform.position);
		Debug.Log (distance);
		if (distance <= activateDistance)
		{
			shooter.Shoot();
		}
	}
}
