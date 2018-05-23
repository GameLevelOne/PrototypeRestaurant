//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game1MainMenu : MonoBehaviour {
	public Text textHighScore;

	void Awake () {
		DeviceOrientation.Instance.SetLandscape();
		textHighScore.text = "High Score = " + PlayerPrefs.GetInt ("HS", 0).ToString ();
	}

	public void PlayGame () {
		SceneManager.LoadScene ("Game1Gameplay");
	}
	public void ButtonExitOnClick()
	{
		PlayerData.Instance.SceneToLoad = Constants.SceneName.SCENE_MAIN;
		SceneManager.LoadScene(Constants.SceneName.SCENE_PRELOAD);
	}
}
