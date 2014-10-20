using UnityEngine;
using System.Collections;

public class PowerUpDisplay : MonoBehaviour {
	
	public Sprite empty;
	public Sprite time;
	public Sprite blast;
	public Sprite health;

	public void changePowerUp(Sprite sprite){
		GetComponent<SpriteRenderer>().sprite = sprite;	
	}
}
