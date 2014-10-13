using UnityEngine;
using System.Collections;

public abstract class Shooter : MonoBehaviour
{
	/// <summary>
	/// Specifies how long the shot prefab will last in
	/// game world after being shot.
	/// </summary>
	public int destroyTime = 20;

	public abstract void Shoot();
}
