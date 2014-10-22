using UnityEngine;
using System.Collections;

public class SlashMenuButton : MonoBehaviour {

	private float startx;
	private float starty;
	private float endx;
	private float endy;

	private float objectx;
	private float objecty;


	void Start(){
		objectx = Camera.main.WorldToScreenPoint(transform.position).x;
		objecty = Camera.main.WorldToScreenPoint(transform.position).y;
	}

	void Update(){
		if (Input.touchCount > 0) {

			float veritcalSpace = 50;

			Touch touch = Input.touches [0];
		
			switch (touch.phase) {

			case(TouchPhase.Began):
				startx = Input.GetTouch(0).position.x;
				starty = Input.GetTouch(0).position.y;
				//	Debug.Log(starty);
				break;
			
			case(TouchPhase.Ended):
				endx = Input.GetTouch(0).position.x;
				endy = Input.GetTouch(0).position.y;

				if(startx < objectx && endx > objectx && (starty > objecty-veritcalSpace && endy < objecty+veritcalSpace) || (starty < objecty+veritcalSpace && endy > objecty-veritcalSpace)){
					gameObject.GetComponent<DestructButton>().Wait();
				}

				else if(startx > objectx && endx < objectx && (starty > objecty-veritcalSpace && endy < objecty+veritcalSpace) || (starty < objecty+veritcalSpace && endy > objecty-veritcalSpace)){
					gameObject.GetComponent<DestructButton>().Wait();
				}

				break;
			}



		}
	}


}
