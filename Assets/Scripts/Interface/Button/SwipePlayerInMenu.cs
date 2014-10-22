﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Moves the camera to a new target on press.
/// </summary>
public class SwipePlayerInMenu : MonoBehaviour {
	
	/// <summary>
	/// Camera 
	/// </summary>
	public GameObject cam;
	public GameObject playButton;
	
	/// <summary>
	/// The new camera target after button press
	/// </summary>
	public Transform target;
	
	
	public string sceneName;
	public GameObject remains;
	
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
				
				if(startx < objectx && endx > objectx && ((starty > objecty-veritcalSpace && endy < objecty+veritcalSpace) || (starty < objecty+veritcalSpace && endy > objecty-veritcalSpace))){
					Wait ();
				}
				
				else if(startx > objectx && endx < objectx && ((starty > objecty-veritcalSpace && endy < objecty+veritcalSpace) || (starty < objecty+veritcalSpace && endy > objecty-veritcalSpace))){
					Wait ();
				}
				
				break;
			}
			
			
			
		}
	}
	
	public void Wait() 
	{
		StartCoroutine(WaitToDie(0.5f));
	}
	
	IEnumerator WaitToDie(float waitTime) 
	{
		GameObject o = this.gameObject.transform.parent == null ? this.gameObject : this.gameObject.transform.parent.gameObject;
		//Hide avatar sprite
		Renderer renderer = o.GetComponentInChildren< Renderer >();
		renderer.enabled = false;
		
		if (remains != null) {
			Instantiate (remains, new Vector3 (transform.position.x, transform.position.y, transform.position.z + 5), transform.rotation);
		}
		//Wait for destruction animation
		yield return new WaitForSeconds(waitTime);
		//Continue with after death scene
		var dampScript = cam.GetComponent<DampenedCamera>();
		if (dampScript != null)
		{
			dampScript.target = this.target;
		}
		else
		{
			cam.transform.position = target.position;
		}

		renderer.enabled = true;
		Instantiate(playButton, this.transform.position, this.transform.rotation);

	}
	
	
}
