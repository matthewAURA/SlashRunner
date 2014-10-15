using UnityEngine;
using System.Collections;

public class BoxHealth : MonoBehaviour ,AvatarAttackListener {
	
	public bool isEnemy = false;
	public int hp;

	void Start(){
		hp = 1;
	}

	public void takeDamage(int amount){
		hp -= amount;
	}

	public void OnAvatarAttack(Avatar.Attack attack){
		takeDamage(1);
	}

	public void OnEnemyAttack() {
		// Debug.Log ("attack");
		takeDamage(1);
	}


	void Update(){
		if (hp <= 0) {
			//hpText.text = "Player is Dead";
			die();
		}
	}

	void die(){
		gameObject.GetComponent<Destructible>().Destruct();
		//Enemy died, Do something
		Destroy(gameObject);
	}
}
