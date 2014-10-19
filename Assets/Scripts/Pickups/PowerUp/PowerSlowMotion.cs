using UnityEngine;
using System.Collections;

public class PowerSlowMotion : MonoBehaviour, IPowerUp {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Time.timeScale);
	}

	public void UsePowerUp(Avatar target) {
		Time.timeScale = 0.5F;
		waitTime ();
	}

	public IEnumerator waitTime() {
		yield return new WaitForSeconds(5f);// waits 5 seconds
		Time.timeScale = 1.0F;
		Destroy (this.gameObject);
	}
}
