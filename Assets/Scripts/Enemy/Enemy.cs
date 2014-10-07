using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour, AvatarAttackListener
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

	public void OnAvatarAttack(Avatar.Attack attack)
	{
		Debug.Log ("Avatar Attacked Enemy");
		Avatar.attackListenerList.Remove (this);
		Destroy (shield);

		//Destroy enemy group game object
		GameObject o = this.gameObject.transform.parent == null ? this.gameObject : this.gameObject.transform.parent.gameObject;
		Destroy (o);
	}
}
