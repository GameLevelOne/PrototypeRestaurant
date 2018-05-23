//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game1GameMaster : MonoBehaviour {
	public Text textScore;

	public static Game1GameMaster Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType<Game1GameMaster> ();
			}
			return instance;	
		}
	}
	private static Game1GameMaster instance;

	void Awake () {
		Game1Data.score = 0;

		if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}
	}

	public void GhostHitByPlayer(Game1GhostHit obj) {
		if (!obj.isSave) {
			PlayerLose ();
			return;
		}
		AddScore (1);
	}

	public void AddScore (int value) {
		Game1Data.score += value;
		textScore.text = Game1Data.score.ToString ();
	}

	public void PlayerLose () {
		SceneManager.LoadScene ("Game1Gameover");
	}
}
