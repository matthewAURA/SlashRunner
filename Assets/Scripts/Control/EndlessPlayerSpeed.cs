using UnityEngine;
using System.Collections;

namespace Platform {

	public class EndlessPlayerSpeed : SpeedUpAvatarScript {

		private ScoringSystem s;
		public float SpeedUpScore;

		void Start(){
			GameObject scoreSystem = GameObject.FindGameObjectWithTag("MainCamera");
			this.s = (ScoringSystem)scoreSystem.GetComponent("ScoringSystem");
		}

		void Update(){
			if (s.GetScore () > SpeedUpScore) {
				SpeedUpScore = s.GetScore() + SpeedUpScore;
				this.speedUp ();
				Debug.Log("speedup!");
			}
		}
	}
}