using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	private bool isPickedUp= false;
	private int speed = 15;
	private int period=0;
	public int scoreReward=100;

	void Update(){
		if (isPickedUp) {
			transform.Translate(new Vector3(0,Time.deltaTime*speed,0));
			period++;
			if(period>40){
				Destroy(gameObject);
			}

		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.CompareTag("Player")){
			Destroy(GetComponent("CircleCollider2D"));
			isPickedUp=true;
			GameObject scoreSystem = GameObject.FindGameObjectWithTag("MainCamera");
			ScoringSystem s = (ScoringSystem)scoreSystem.GetComponent("ScoringSystem");
			s.IncreaseScore(scoreReward);

		}
	}
	}
