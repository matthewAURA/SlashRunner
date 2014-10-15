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
		None=0,
		Short=1,
		Tall=2
	};
	
	public GameObject shortShield;
	public GameObject tallShield;

	public bool randomise = false;

	public ShieldType shieldType = ShieldType.Short;
	public ShieldPosition shieldPosition = ShieldPosition.Middle;

	private GameObject shieldObject;

	private bool shielded = true;

	void Awake()
	{
		Debug.Log ("started " + this.name);
		if (randomise)
		{
			// Debug.Log("Randomising.");
			System.Random random = new System.Random();

			int randomType = random.Next(1, 300);

			// Debug.Log(randomType);

			if (randomType < 125)
			{
				shieldType = ShieldType.Short;
			}
			else if (randomType > 175)
			{
				shieldType = ShieldType.Tall;
			}
			else
			{
				shieldType = ShieldType.None;
			}

			int randomPosition = 0;

			if (shieldType == ShieldType.Short)
			{
				randomPosition = random.Next(1, 300);
			}
			else if (shieldType == ShieldType.Tall)
			{
				randomPosition = random.Next(1, 200);
			}

			// Debug.Log(randomPosition);

			if (randomPosition < 100)
			{
				shieldPosition = ShieldPosition.Bottom;
			}
			else if (randomPosition > 200)
			{
				shieldPosition = ShieldPosition.Middle;
			}
			else
			{
				shieldPosition = ShieldPosition.Top;
			}

			// Debug.Log("Position:");
			// Debug.Log(shieldPosition.ToString());
			// Debug.Log("Type:");
			// Debug.Log(shieldType.ToString());

		}

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
	
	public override void OnAvatarAttack(Avatar.Attack attack)
	{
		// Debug.Log ("Avatar Attacked Enemy");

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
		this.takeDamage (1);
	}
	
	protected override void AfterDeath(){
	
		GameObject scoreSystem = GameObject.FindGameObjectWithTag("MainCamera");
		ScoringSystem s = (ScoringSystem)scoreSystem.GetComponent("ScoringSystem");
		s.IncreaseScore(2000);
	}



}
