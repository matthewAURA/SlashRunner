using UnityEngine;
using System.Collections;

public class Enemy
{
	public enum Shield
	{
		None,
		SmallTop,
		SmallMiddle,
		SmallBottom,
		BigTop,
		BigBottom
	};
	
	public Shield shield = Shield.None;
	public string shiledGraphic = "Some URL to a graphic";
	public Rigidbody shiledPrefab;
	public Transform shildRealPosition;
	
	void Start()
	{
		Rigidbody shieldInstance;
		shieldInstance = Instantiate(shildPrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
		shieldInstance.AddForce(barrelEnd.forward * 5000);


	}
}

