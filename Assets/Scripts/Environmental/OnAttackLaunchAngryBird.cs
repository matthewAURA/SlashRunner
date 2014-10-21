using UnityEngine;
using System.Collections;

/// <summary>
/// Launches the bird off into the distance when attacked,
/// destroying a bunch of enemies at a hardcoded impact point
/// and releasing a whole bunch of coins! This is a one-off
/// script so excuse the tight coupling.
/// </summary>
public class OnAttackLaunchAngryBird : MonoBehaviour, AvatarAttackListener 
{
	/// <summary>
	/// The bomb's landing target
	/// </summary>
	public float xTarget = 0f;
	public float yTarget = 0f;

	public AudioClip angryBirdSound;
	public AudioClip explosionSound;

	/// <summary>
	/// Prefab of the remains after explosion
	/// i.e. crater, coins, dead enemies
	/// </summary>
	public GameObject remains;

	/// <summary>
	/// Explosion animation prefab
	/// </summary>
	public GameObject explosion;

	/// <summary>
	/// Launches the bird towards the right
	/// </summary>
	public void OnAvatarAttack(Avatar.Attack attack)
	{

		if (angryBirdSound != null) {
			AudioSource.PlayClipAtPoint (angryBirdSound, transform.position);	
		}

		Avatar.attackListenerList.Remove (this);

		// Launched bird should be affected by physics
		rigidbody2D.gravityScale = 2;
		rigidbody2D.AddForce(new Vector3(1500, 5000));

		PrepareProximityBomb ();

		Destroy (gameObject, 1);
	}

	void PrepareProximityBomb()
	{
		GameObject proximityTrigger = new GameObject ();
		proximityTrigger.transform.position = new Vector3 (xTarget, yTarget, 10);

		// Configure bomb script
		var bombScript = proximityTrigger.AddComponent<OrbitalBirdBombScript> ();
		((MonoBehaviour)bombScript).enabled = false;
		bombScript.xTarget = xTarget;
		bombScript.yTarget = yTarget;
		bombScript.bomb = gameObject.GetComponent<SpriteRenderer> ().sprite;
		bombScript.remains = remains;
		bombScript.explosion = explosion;
		bombScript.explosionSound = explosionSound;

		// Configure bomb animation to play on a set distance
		var onProximity = proximityTrigger.AddComponent<OnProximity> ();
		onProximity.target = GameObject.Find ("Character");
		onProximity.componentNames = "OrbitalBirdBombScript";
		onProximity.activateDistance = 22;
	}
}
