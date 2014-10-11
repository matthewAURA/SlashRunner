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

	public void OnAvatarAttack(Avatar.Attack attack)
	{
		Debug.Log ("Avatar Attacked Enemy");

		if (shielded) {
			switch (attack)
			{
				case Avatar.Attack.JUMPSTOMP:
				case Avatar.Attack.JUMPSWIPE:
				case Avatar.Attack.OVERHEADSWIPE:
					if (shieldPosition == ShieldPosition.Top) {
						return;
					}
					break;
				case Avatar.Attack.PIERCE:
					if (shieldType == ShieldType.Tall || shieldPosition == ShieldPosition.Middle) {
						return;
					}
					break;
				case Avatar.Attack.LOWSWIPE:
					if (shieldPosition == ShieldPosition.Bottom) {
						return;
					}
					break;
			}
		}

		Avatar.attackListenerList.Remove (this);

		GameObject scoreSystem = GameObject.FindGameObjectWithTag("MainCamera");
		ScoringSystem s = (ScoringSystem)scoreSystem.GetComponent("ScoringSystem");
		s.IncreaseScore(2000);

		//Destroy enemy group game object
		GameObject o = transform.parent == null ? this.gameObject : this.gameObject.transform.parent.gameObject;
		Destroy (o);
	}
}
