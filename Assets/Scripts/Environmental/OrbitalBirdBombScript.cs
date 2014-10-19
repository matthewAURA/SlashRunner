using UnityEngine;
using System.Collections;

/// <summary>
/// Summons the almighty bird bomb from the sky to
/// wreck havoc upon its enemies. Upon reaching its
/// destination it spawns the given prefab (e.g. 
/// a smouldering crater)
/// </summary>
public class OrbitalBirdBombScript : MonoBehaviour
{
	/// <summary>
	/// The bomb's landing target
	/// </summary>
	public float xTarget;
	public float yTarget;

	/// <summary>
	/// This sprite for the bomb
	/// </summary>
	public Sprite bomb;

	/// <summary>
	/// The prefab that should spawn when
	/// the bomb explodes
	/// </summary>
	public GameObject remains;

	/// <summary>
	/// Explosion animation
	/// </summary>
	public GameObject explosion;

	// Represents the bomb that will travel towards it's target
	private GameObject bombObj;

	// Magnitude of which the bomb travels towards its target
	private const float VELOCITY_MAGNITUDE = 4;
	
	void Start ()
	{
		// Spawn project far away from the actual target
		SpawnProjectile (new Vector3(xTarget-10, yTarget + 15));
	}
	

	void Update ()
	{
		// If bomb is close enough to target
		if (Vector3.Distance (bombObj.transform.position,
		                      new Vector3(xTarget, yTarget, 0)) < 1)
		{
			Destroy (bombObj);
			Destroy (GameObject.Find ("BombedEnemies"));

			SpawnRemains ();
			PlayAnimation ();
			PlaySound ();

			// The bomb going off should only happen max once
			Destroy (gameObject);
		}
	}

	void SpawnProjectile(Vector3 position)
	{
		// Set sprite of bomb
		bombObj = new GameObject ();
		var spriteRenderer = bombObj.AddComponent<SpriteRenderer> ();
		spriteRenderer.sprite = bomb;

		// Set position/size of bomb
		bombObj.transform.position = position;
		bombObj.transform.localScale = new Vector3 (3, 3);

		// Launch bomb towards target
		var rigbod = bombObj.AddComponent<Rigidbody2D> ();
		rigbod.velocity = new Vector3 (xTarget, yTarget) - position;
		rigbod.velocity *= VELOCITY_MAGNITUDE;
		rigbod.gravityScale = 0;
	}

	void SpawnRemains()
	{
		Instantiate (remains);
	}
	
	void PlayAnimation()
	{
		var explosionObj = (GameObject)Instantiate (explosion);
		explosionObj.transform.localScale = new Vector3 (40, 15);
		Destroy (explosionObj, 1);
	}

	void PlaySound()
	{
		// TODO
	}
}
