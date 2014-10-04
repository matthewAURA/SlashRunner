using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int hp = 1;
	public bool isEnemy = false;


	//For test purposes only
	public int buttonx = 15;
	public int buttony = 15;
	private GameObject heart;

	void Start(){

		if (!isEnemy) {
			heart = GameObject.Find ("Heart");
		}
	}

	public void takeDamage(int amount){
		hp -= amount;
	}


	void Update(){
		if (hp <= 0) {
			//hpText.text = "Player is Dead";
			die();
		}

		if (!isEnemy) {
			heart.gameObject.GetComponent<Heart>().renderHeart(hp);
		}
	}

	void OnGUI(){
		if (GUI.Button (new Rect (buttonx, buttony, 100, 50), "Take Damage")) {
			takeDamage(1);	
		}
	}



	void die(){
		if (isEnemy) {
			//Enemy died, Do something
			Destroy(gameObject);
		} else {
			//Player died, Do something
			Destroy(gameObject);
		}
	}
}
