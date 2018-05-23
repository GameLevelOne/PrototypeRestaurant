//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Game3GameMaster : MonoBehaviour {
	public Text textTimer, textHighscore, textDiscount;
	public Game3MenuManager Game3MenuManager;

	public int playerTime;
	private float timer;

	void Awake () {
		playerTime = 0;
		timer = 0;
	}

	void FixedUpdate () {
		timer += Time.deltaTime;

		playerTime = Mathf.FloorToInt (timer);

//		#region Google Play Games Services
//		PlayGamesScript.IncrementAchievement (GPGSIds.achievement_survive_100_seconds, playerTime);
//		#endregion //Google Play Games Services

		textTimer.text = playerTime.ToString ();
	}

	public void PlayerHitGame3Rain (Game3Rain obj) {
		Time.timeScale = 0;

		DisplayScore ();
	}

	void DisplayScore () {
		Game3MenuManager.gameoverUI.SetActive (true);
		int highScore = PlayerPrefs.GetInt ("HS", 0);

		if (playerTime > highScore) {
			PlayerPrefs.SetInt ("HS", playerTime);
			Game3MenuManager.newHighscore.SetActive (true);
		}

		textHighscore.text = playerTime.ToString ();

		if(!PlayerData.Instance.IsTraining){
			float discount = (float) ( playerTime > 30 ? 30 : playerTime);

			PlayerData.Instance.LastResultAmount = discount;
			PlayerData.Instance.LastResultDate = DateTime.Today;

			textDiscount.text = "DISCOUNT = " + discount.ToString() + "%";
			textDiscount.gameObject.SetActive(true);

			PlayerData.Instance.HasResult = true;
		}else{
			textDiscount.gameObject.SetActive(false);
		}
	}
}
