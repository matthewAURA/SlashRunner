using UnityEngine;
using System.Collections;
using System; //only using for Maths.Abs

/**
 * Listens for andoid touch events, interpretes
 * the type of swipe to one of the multiplePlatformInputs
 * and calls all functions associated with that input listed
 * in the InputMap.
*/
public class AndroidInputListener : MonoBehaviour {
	
	//The Direction the swipe is currently moving
	private CurrentDir currentDir;
	
	//The distance currently moved in a particular direction
	private float currentDist = 0;
	
	//List of directions that the user swipes in a single movement
	private ArrayList directionList = new ArrayList();
	
	/**
	 * Minimum distance in pixels in a particular
	 * direction for a swipe direction to be added
	 * to the direction list.
	*/
	private float minSwipeDist = 50;
	
	private InputMap inputMap = InputMap.getInputMap();
	
	//Set of possible swipe directions
	private enum CurrentDir { up, down, left, right }
	
	// Use this for initialization
	void Start () {
		
	}
	
	/**
	 * Update is called once per frame
	 * Builds list of Swipes
	*/ 
	void Update () {
		if (UnityEngine.Application.platform == RuntimePlatform.Android) {
			if (Input.touchCount > 0) {
				Touch touch = Input.touches [0];
				
				switch (touch.phase) {
					
					//Clears all data when swipe begins
				case TouchPhase.Began:
					directionList.Clear();
					currentDist = 0;
					break;
					
					//Builds list of directions swiped
				case TouchPhase.Moved:
					
					//Right swiping
					if(Math.Abs(touch.deltaPosition.x) > Math.Abs(touch.deltaPosition.y) && touch.deltaPosition.x > 0) {
						if(currentDir != CurrentDir.right) {
							if (currentDist > minSwipeDist) {
								directionList.Add(currentDir);
							}
							currentDir = CurrentDir.right;
							currentDist = 0;
						}
						currentDist += touch.deltaPosition.x;
					}
					
					//Up swiping
					if(Math.Abs(touch.deltaPosition.y) > Math.Abs(touch.deltaPosition.x) && touch.deltaPosition.y > 0) {
						if(currentDir != CurrentDir.up) {
							if (currentDist > minSwipeDist) {
								directionList.Add(currentDir);
							}
							currentDir = CurrentDir.up;
							currentDist = 0;
						}
						currentDist += touch.deltaPosition.y;
					}
					
					//Left swiping
					if(Math.Abs(touch.deltaPosition.x) > Math.Abs(touch.deltaPosition.y) && touch.deltaPosition.x < 0) {
						if(currentDir != CurrentDir.left) {
							if (currentDist > minSwipeDist) {
								directionList.Add(currentDir);
							}
							currentDir = CurrentDir.left;
							currentDist = 0;
						}
						currentDist += -touch.deltaPosition.x;
					}
					
					//Down swiping
					if(Math.Abs(touch.deltaPosition.y) > Math.Abs(touch.deltaPosition.x) && touch.deltaPosition.y < 0) {
						if(currentDir != CurrentDir.down) {
							if (currentDist > minSwipeDist) {
								directionList.Add(currentDir);
							}
							currentDir = CurrentDir.down;
							currentDist = 0;
						}
						currentDist += -touch.deltaPosition.y;
					}
					
					break;
					
				case TouchPhase.Ended:
					//Adds the last direction swiped to the list
					if (currentDist > minSwipeDist) {
						directionList.Add(currentDir);
					}
					this.FireSwipeEvents();
					break;
				}
			}
		}
	}
	
	/**
	 * Calls to inputMap class to fire events for the 
	 * listeners of the given input.
	*/ 
	private void FireSwipeEvents() {
		//Swipe Up then Right then Down Input
		if (directionList.Count > 2 && directionList[0].Equals(CurrentDir.up) && directionList[1].Equals(CurrentDir.right) && directionList[2].Equals(CurrentDir.down)) {
			inputMap.FireInputEvents(MultiPlatformInputs.SwipeUpRightDown);
		}
		//Swipe Right then Down Input
		else if (directionList.Count > 1 && directionList[0].Equals(CurrentDir.right) && directionList[1].Equals(CurrentDir.down)) {
			inputMap.FireInputEvents(MultiPlatformInputs.SwipeRightDown);
		}
		//Swipe Down then Right Input
		else if(directionList.Count > 1 && directionList[0].Equals(CurrentDir.down) && directionList[1].Equals(CurrentDir.right)) {
			inputMap.FireInputEvents(MultiPlatformInputs.SwipeDownRight);
		}
		//Swipe Right Input
		else if (directionList.Count > 0 && directionList[0].Equals(CurrentDir.right)) {
			inputMap.FireInputEvents(MultiPlatformInputs.SwipeRight);
		}
		//Swipe Up Input
		else if (directionList.Count > 0 && directionList[0].Equals(CurrentDir.up)) {
			inputMap.FireInputEvents(MultiPlatformInputs.SwipeUp);
		}
	}
}
