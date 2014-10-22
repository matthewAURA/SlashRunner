using UnityEngine;
using System.Collections;

public class CoinSystemScript : MonoBehaviour {
	private int coin;
	// Use this for initialization
	void Start () {
		coin = PlayerPrefs.GetInt ("Coins");
		if (coin == null) {
			coin = 0;
		}
	}

	public int GetCoin(){
		return coin;
	}
	public void AddCoin(int amount){
		coin += amount;

		if (coin >= 10 && coin < 100) {
			Social.ReportProgress("CgkI3OiBg-AbEAIQAw", 100.0f, (bool success) => {
				Debug.Log("Successfully sent Achievement!");
        	});
		} else if (coin > 100) {
			Social.ReportProgress("CgkI3OiBg-AbEAIQBA", 100.0f, (bool success) => {
				Debug.Log("Successfully sent Achievement!");
        	});
		}

		Debug.Log (coin);
	}

	public void TakeOutCoin(int amount){
		coin -= amount;
		Debug.Log (coin);
	}

	void Update(){
		PlayerPrefs.SetInt("Coins", coin);
	}
	
	void OnDisable(){
		PlayerPrefs.SetInt ("Coins", coin);
	}
}
