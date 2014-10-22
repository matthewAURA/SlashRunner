using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
	
	private bool isPickedUp= false;
	private int speed = 15;
	private int period=0;
	public int scoreReward=100;
	public AudioClip coinSound;
	public int coinWorth = 1;

	void Update(){
		if (isPickedUp) {
			transform.Translate(new Vector3(0,Time.deltaTime*speed,0));
			period++;
			if(period>40){
				Destroy(gameObject);
			}
			
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision){
		if(collision.gameObject.CompareTag("Player")){
			audio.PlayOneShot(coinSound, 3.0f);	
			Destroy(GetComponent("CircleCollider2D"));
			isPickedUp=true;
			GameObject scoreSystem = GameObject.FindGameObjectWithTag("MainCamera");
			ScoringSystem s = (ScoringSystem)scoreSystem.GetComponent("ScoringSystem");
			s.IncreaseScore(scoreReward);

			GameObject coinSystem = GameObject.FindGameObjectWithTag("MainCamera");
			CoinSystemScript c = (CoinSystemScript)coinSystem.GetComponent("CoinSystemScript");
			c.AddCoin(coinWorth);
			
		}
	}
}
