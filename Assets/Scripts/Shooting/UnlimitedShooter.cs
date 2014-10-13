using UnityEngine;
using System.Collections;

/// <summary>
/// Represents a projectile shooter with a cooldown on how often
/// it can shoot.
/// </summary>
public class UnlimitedShooter : Shooter
{
	/// <summary>
	/// Used for keeping track of how often an object could shoot.
	/// </summary>
	public double cooldown = 2;
	private double timer;

	/// <summary>
	/// Prefab that represents the projectile.
	/// </summary>
	public GameObject shotPrefab;

	public bool CanShoot
	{
		get { return timer <= 0; }
	}
	
	void Start () 
	{
		timer = 0;
	}

	void Update () 
	{
		// Update the shot timer
		if (timer > 0)
		{
			timer -= Time.deltaTime;
		}
	}

	/// <summary>
	/// Shoots the projectile and restarts the cooldown
	/// if the cooldown is ready.
	/// </summary>
	public override void Shoot()
	{
		if (CanShoot)
		{
			GameObject shot = (GameObject) Instantiate (shotPrefab, 
			             gameObject.transform.position,
			             shotPrefab.transform.rotation);
			timer = cooldown;
			Destroy(shot, destroyTime);
		}
	}
}
