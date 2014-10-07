using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour {

	public Sprite heart0;
	public Sprite heart1;
	public Sprite heart2;
	public Sprite heart3;

	public void renderHeart(int lives){
		if (lives == 3) {
			GetComponent<SpriteRenderer>().sprite = heart3;	
		}
		if (lives == 2) {
			GetComponent<SpriteRenderer>().sprite = heart2;	
		}
		if (lives == 1) {
			GetComponent<SpriteRenderer>().sprite = heart1;	
		}
		if (lives == 0) {
			GetComponent<SpriteRenderer>().sprite = heart0;	
		}
	}
}
