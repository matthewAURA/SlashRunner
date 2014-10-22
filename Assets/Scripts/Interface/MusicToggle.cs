using UnityEngine;
using System.Collections;

public class MusicToggle : ButtonBehaviour {
	public bool musicMode;
	public Sprite onButtonSprite;
	public Sprite offButtonSprite;
	
	void Start(){
		if (AudioListener.volume == 100) {

			musicMode = false;
			GetComponent<SpriteRenderer> ().sprite = onButtonSprite;
		} else {
			Debug.Log("TRUEEEEEE");
			musicMode=true;
			GetComponent<SpriteRenderer> ().sprite = offButtonSprite;
		}
	}
	
	protected override void OnButtonPress(){
		musicMode = !musicMode;
		
		if (musicMode) {
			AudioListener.volume = 100;
			GetComponent<SpriteRenderer> ().sprite = onButtonSprite;
		} else {
			AudioListener.volume = 0;
			GetComponent<SpriteRenderer> ().sprite = offButtonSprite;
		}
	}

}
