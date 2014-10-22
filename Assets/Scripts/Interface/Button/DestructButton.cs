using UnityEngine;
using System.Collections;

/// <summary>
/// Loads the given scene when pressed.
/// </summary>
public class DestructButton : ButtonBehaviour {
	
	public string sceneName;
	public GameObject remains;

	protected override void OnButtonPress()
	{
		Wait ();
	}

	void Wait() 
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
		Application.LoadLevel(sceneName);
	}
}

