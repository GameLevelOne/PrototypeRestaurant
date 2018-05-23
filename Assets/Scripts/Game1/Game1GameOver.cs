//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Game1GameOver : MonoBehaviour {
	public Text textScore;
	public Text textDiscount;
	public GameObject newHS;

	private int highScore;

	void Awake () {
		textScore.text = Game1Data.score.ToString ();
		highScore = PlayerPrefs.GetInt ("HS", 0);

		if (Game1Data.score > highScore) {
			highScore = Game1Data.score;
			PlayerPrefs.SetInt ("HS", highScore);
			newHS.SetActive (true);
		}

		if(!PlayerData.Instance.IsTraining)
		{
			float discount = Game1Data.score > 10 ? 30 : Game1Data.score*3;

			PlayerData.Instance.LastResultAmount = discount;
			PlayerData.Instance.LastResultDate = DateTime.Today;

			textDiscount.text = "DISCOUNT = "+ discount.ToString() + "%";
			textDiscount.gameObject.SetActive(true);

			PlayerData.Instance.HasResult = true;
		}else{
			textDiscount.gameObject.SetActive(false);
		}

	}

	public void RestartGame () {
		SceneManager.LoadScene ("Game1Gameplay");
	}

	public void BackToMenu () {
		PlayerData.Instance.SceneToLoad = Constants.SceneName.SCENE_MAIN;
		SceneManager.LoadScene(Constants.SceneName.SCENE_PRELOAD);
	}
}
