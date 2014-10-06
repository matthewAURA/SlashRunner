using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
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
	
	public Transform shortShield;
	public Transform tallShield;

	public ShieldType shieldType = ShieldType.Short;
	public ShieldPosition shieldPosition = ShieldPosition.Middle;

	private Transform shieldObject;
	private GameObject shield;

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
			shield = (GameObject) Instantiate (shieldObject, transform.position + new Vector3 (-1.0f, (float)shieldPosition, 0.0f), transform.rotation);
		}

	}

	void FixedUpdate()
	{
		if (shielded) {
			shield.transform.position = transform.position + new Vector3 (-1.0f, (float)shieldPosition, 0.0f);
		}
	}
}
