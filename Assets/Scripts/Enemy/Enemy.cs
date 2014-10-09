using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Destructible, AvatarAttackListener
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
		Avatar.attackListenerList.Remove (this);

		GameObject scoreSystem = GameObject.FindGameObjectWithTag("MainCamera");
		ScoringSystem s = (ScoringSystem)scoreSystem.GetComponent("ScoringSystem");
		s.IncreaseScore(2000);

		//Destroy enemy group game object
		GameObject o = transform.parent == null ? this.gameObject : this.gameObject.transform.parent.gameObject;
		//if (gameObject.GetComponent<Destructible> () != null) {
		//	gameObject.GetComponent<Destructible> ().Destruct ();
		//}
		this.takeDamage (1);
	}

	public override void die(){
		GameObject o = this.gameObject.transform.parent == null ? this.gameObject : this.gameObject.transform.parent.gameObject;
		this.Destruct ();
		Destroy (o);
	}
}
