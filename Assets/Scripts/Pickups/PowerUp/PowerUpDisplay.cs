using UnityEngine;
using System.Collections;

public class PowerUpDisplay : MonoBehaviour, IPowerUpChangeListener {
	
	public Sprite empty;
	public Sprite time;
	public Sprite blast;
	public Sprite health;

	public void Start() {
		Avatar.powerUpChangeListenerList.Add (this);
	}

	public void OnAvatarPowereUpChange(IPowerUp powerUp){
		if (powerUp == null) {
			GetComponent<SpriteRenderer> ().sprite = empty;
		} else if (powerUp.GetType() == typeof(PowerBirdSpawn)) {
			GetComponent<SpriteRenderer> ().sprite = health;
		} else if (powerUp.GetType() == typeof(PowerSlowMotion)) {
			GetComponent<SpriteRenderer>().sprite = time;
		}else if (powerUp.GetType() == typeof(DoPowerBlast)) {
			GetComponent<SpriteRenderer>().sprite = blast;
		}
	}
}
