using UnityEngine;
using System.Collections;

public class BoxHealth : MonoBehaviour ,AvatarAttackListener {
	
	public bool isEnemy = false;
	public int hp;

	//For test purposes only
	public int buttonx = 15;
	public int buttony = 15;
	private GameObject heart;

	void Start(){
		hp = 1;
		if (!isEnemy) {
			heart = GameObject.Find ("Heart");
		}
	}

	public void takeDamage(int amount){
		hp -= amount;
	}

	public void OnAvatarAttack(Avatar.Attack attack){
		takeDamage(1);
	}

	public void OnEnemyAttack() {
		Debug.Log ("attack");
		takeDamage(1);
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
			gameObject.GetComponent<Destructible>().Destruct();
			//Enemy died, Do something
			Destroy(gameObject);
		} else {
			//Player died, Do something
			Destroy(gameObject);
		}
	}
}
