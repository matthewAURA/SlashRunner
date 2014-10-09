using UnityEngine;
using System.Collections;

/// <summary>
/// Represents how much damage a player should take on contact
/// with this object. This object should have both RigidBody2D
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
}
