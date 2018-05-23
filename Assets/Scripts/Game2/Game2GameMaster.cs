//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Game2GameMaster : MonoBehaviour {
	public Text textScore, textHighscore, textDiscount;
	public Game2MenuManager menuManager;

	private static int playerScore;

	void Awake () {
		playerScore = 0;
	}

	public void PlayerHitObstacle(Game2EnemyObstacle obj) {
		Time.timeScale = 0;

		DisplayScore ();
	}

	public void PlayerDodgeObstacle (Game2EnemyObstacle obj) {
		AddScore (1);
	}

	public void AddScore (int value) {
		playerScore += value;
		textScore.text = playerScore.ToString ();
	}

	void DisplayScore () {
		menuManager.gameoverUI.SetActive (true);
		int highScore = PlayerPrefs.GetInt ("HS", 0);

		if (playerScore > highScore) {
			PlayerPrefs.SetInt ("HS", playerScore);
			menuManager.newHighscore.SetActive (true);
		}

		textHighscore.text = playerScore.ToString ();

		if(!PlayerData.Instance.IsTraining){
			float discount = playerScore > 30 ? 30 : playerScore;

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
