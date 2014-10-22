using UnityEngine;
using System.Collections;

public class SettingScreen : MonoBehaviour {
	public Font headerFont;
	void OnGUI(){
		GUIStyle style = new GUIStyle ();
		style.fontSize = (int)(Screen.width * 0.1f);// set font size
		style.alignment = TextAnchor.MiddleCenter;// set alignment
		style.font = headerFont;
		GUI.Label (new Rect ( (Screen.width / 2) - (Screen.width * 0.5f) / 2, Screen.height * 0.1f, Screen.width * 0.5f, Screen.height * 0.2f), "Setting", style);
	}
}
