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

	public GameObject child;
	
	void Start(){

	}
	
	public void takeDamage(int amount){
		hp -= amount;
	}
	
	void Update(){
		if (target != null) {
			transform.position = new Vector3 (target.position.x + xOffset, target.position.y + yOffset);
		} else {
			Debug.Log ("******* SHOULD ATTACH TO A TARGET *******");
		}

		if (hp == 3) {
			child.GetComponent<SpriteRenderer>().sprite = heart3;	
		}
		else if (hp == 2) {
			child.GetComponent<SpriteRenderer>().sprite = heart2;	
		}
		else if (hp == 1) {
			child.GetComponent<SpriteRenderer>().sprite = heart1;	
		}
		else if (hp == 0) {
			child.GetComponent<SpriteRenderer>().sprite = heart0;
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
	
	void die(){
		GameObject o = this.gameObject.transform.parent == null ? this.gameObject : this.gameObject.transform.parent.gameObject;
		Destroy (o);
		Application.LoadLevel ("Gameover");
	}
}
