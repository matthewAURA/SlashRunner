using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour, IAvatarHeathChangeListener {

	public Sprite heart0;
	public Sprite heart1;
	public Sprite heart2;
	public Sprite heart3;

	public void Start() {
		Avatar.healthChangeListenerList.Add (this);
	}

	public void OnAvatarHealthChange(int health){
		if (health >= 3) {
			GetComponent<SpriteRenderer>().sprite = heart3;	
		}
		if (health == 2) {
			GetComponent<SpriteRenderer>().sprite = heart2;	
		}
		if (health == 1) {
			GetComponent<SpriteRenderer>().sprite = heart1;	
		}
		if (health <= 0) {
			GetComponent<SpriteRenderer>().sprite = heart0;	
		}
	}
}
