﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Moves the camera to a new target on press.
/// </summary>
public class ModifyCameraTargetButton : ButtonBehaviour {
	
	/// <summary>
	/// Camera 
	/// </summary>
	public GameObject cam;
	
	/// <summary>
	/// The new camera target after button press
	/// </summary>
	public Transform target;
	
	protected override void OnButtonPress()
	{
		var dampScript = cam.GetComponent<DampenedCamera>();
		if (dampScript != null)
		{
			dampScript.target = this.target;
		}
		else
		{
			cam.transform.position = target.position;
		}
	}
}
