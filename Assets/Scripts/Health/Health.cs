using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour, EnemyAttackListener {
	
	public int hp;
	public Transform target;
	public int yOffset;
	public int xOffset;

	public Sprite heart0;
	public Sprite heart1;
	public Sprite heart2;
	public Sprite heart3;

	//public GameObject child;
	
	void Start(){

	}
	
	public void takeDamage(int amount){
		Debug.Log ("TOOK DAMAGE");
		hp -= amount;
		Debug.Log (hp);
	}
	
	void Update(){

		if (target != null) {
			transform.position = new Vector3 (target.position.x + xOffset, target.position.y + yOffset);
		}
		if (hp <= 0) {
			//hpText.text = "Player is Dead";
			die();
		}
	}
	
	public void OnEnemyAttack() {
		takeDamage(1);
	}

	public void Kill() {
		hp = 0;
	}
	
	public virtual void die(){

	}
}
