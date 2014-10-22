using UnityEngine;
using System.Collections;

public class ProximityDisappear : MonoBehaviour {

	public Transform target;

	//boundary box for trigger
	float xLeft = 490.0f;
	float xRight = 500.0f;
	float yBottom = 2.5f;
	float yTop = 3.0f;

	//boundary for secondary trigger
	float xDone = 615.0f;

	//original alpha value
	float oldA;

	// Use this for initialization
	void Start () {
		foreach(SpriteRenderer renderer in GetComponentsInChildren<SpriteRenderer>()){
			Color color = renderer.material.color;
			oldA = color.a;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(target){
			Vector3 targetPos = target.transform.position;
			//Debug.Log("x: :" + targetPos.x);
			//Debug.Log("y: :" + targetPos.y);

			if(targetPos.x > xLeft && targetPos.x < xRight && targetPos.y > yBottom && targetPos.y < yTop){
				foreach(SpriteRenderer renderer in GetComponentsInChildren<SpriteRenderer>()){
					//decrease alpha of children while target is in the trigger area
					Color color = renderer.material.color;
					color.a -= 0.01f;
					renderer.material.color = color;
				}
			}

			if(targetPos.x > xDone){
				foreach(SpriteRenderer renderer in GetComponentsInChildren<SpriteRenderer>()){
					//revert children
					Color color = renderer.material.color;
					if(color.a < oldA){
						color.a += 0.01f;
					}
					renderer.material.color = color;
				}
			}
		}
	}
}
