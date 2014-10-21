﻿using UnityEngine;
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
	public void AddCoin(int amount){
		coin += amount;
	}

	void Update(){
		PlayerPrefs.SetInt("Coins", coin);
	}
	
	void OnDisable(){
		PlayerPrefs.SetInt ("Coins", coin);
	}
}