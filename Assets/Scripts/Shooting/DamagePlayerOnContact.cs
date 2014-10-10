using UnityEngine;
using System.Collections;

/// <summary>
/// Represents how much damage a player should take on contact
/// with this object. This object should have both Rigidbody2D
/// and BoxCollider2D attached, and should be a trigger. The player
/// should handle damage-taken logic, and should also be associated
/// with a BoxCollider2D.
/// </summary>
public class DamagePlayerOnContact : MonoBehaviour
{
	/// <summary>
	/// The damage to be deducted from the player.
	/// </summary>
	public int damage = 1;

	void Start()
	{
		if (GetComponent<BoxCollider2D> () == null ||
			GetComponent<Rigidbody2D> () == null)
		{
			throw new MissingComponentException("Must have both BoxCollider2D and Rigidbody2D" +
			                                    "components attached.");
		}
	}
}
