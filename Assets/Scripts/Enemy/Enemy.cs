using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Destructible
{
	public enum ShieldPosition
	{
		Top=1,
		Middle=0,
		Bottom=-1
	};

	public enum ShieldType
	{
		None,
		Short,
		Tall
	};
	
	public GameObject shortShield;
	public GameObject tallShield;

	public ShieldType shieldType = ShieldType.Short;
	public ShieldPosition shieldPosition = ShieldPosition.Middle;

	private GameObject shieldObject;

	private bool shielded = true;
	
	void Start()
	{
		switch (shieldType)
		{
			case ShieldType.None:
			shielded = false;
				break;
			case ShieldType.Short:
				shieldObject = shortShield;
				break;
			case ShieldType.Tall:
				shieldObject = tallShield;
				break;
		}

		if (shielded) {
			GameObject shield = (GameObject) Instantiate (shieldObject, transform.position, transform.rotation);
			shield.transform.parent = transform;
			shield.transform.position = transform.position + new Vector3 (-2.0f, (float)shieldPosition, 0.0f);
			shield.transform.localScale = new Vector3(10.0f, 10.0f, 0.0f);
		}

	}

}
