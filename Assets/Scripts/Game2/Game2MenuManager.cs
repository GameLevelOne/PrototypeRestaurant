//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game2MenuManager : MonoBehaviour {
	public GameObject gameoverUI, menuUI, newHighscore, player, textScore;

	void Awake () {
		DeviceOrientation.Instance.SetLandscape();
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
		}
	}

	public void StartGame () {
		menuUI.SetActive (false);
		gameoverUI.SetActive (false);
		textScore.SetActive (true);
		player.SetActive (true);

		Time.timeScale = 1;
	}

	public void ButtonExitOnClick()
	{
		PlayerData.Instance.SceneToLoad = Constants.SceneName.SCENE_MAIN;
		SceneManager.LoadScene(Constants.SceneName.SCENE_PRELOAD);
	}

	public void RestartGame () { //0 if back to Menu, 1 if Restart
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
