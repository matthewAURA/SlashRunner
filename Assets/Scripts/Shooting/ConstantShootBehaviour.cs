using UnityEngine;
using System.Collections;

/// <summary>
/// Shooting behaviour that constantly shoots the attached
/// Shooter every frame.  
/// </summary>
public class ConstantShootBehaviour : MonoBehaviour
{
	private Shooter shooter;
	
	void Start ()
	{
		shooter = GetComponent<Shooter> ();
		if (shooter == null)
		{
			throw new MissingComponentException("Must have a Shooter script attached");
		}
	}

	void Update () {
		shooter.Shoot();
	}
}
