//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game3MenuManager : MonoBehaviour {
	public GameObject gameoverUI, menuUI, newHighscore, player, textTimer, gameplayUI;
	public Game3GameMaster Game3GameMaster;

	void Awake () {
		DeviceOrientation.Instance.SetPortrait();
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
		}
	}

	public void StartGame () {
		menuUI.SetActive (false);
		gameoverUI.SetActive (false);
		textTimer.SetActive (true);
		player.SetActive (true);
		gameplayUI.SetActive (true);

		Time.timeScale = 1;
	}

	public void ButtonExitOnClick()
	{
		PlayerData.Instance.SceneToLoad = Constants.SceneName.SCENE_MAIN;
		SceneManager.LoadScene(Constants.SceneName.SCENE_PRELOAD);
	}

	public void RestartGame () { //0 if back to Menu, 1 if Restart
//		#region Google Play Games Services
//		PlayGamesScript.AddScoreToLeaderboard (GPGSIds.leaderboard_players_leaderboard, Game3GameMaster.playerTime);
//		#endregion //Google Play Games Services

		//SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

		PlayerData.Instance.SceneToLoad = Constants.SceneName.SCENE_MAIN;
		SceneManager.LoadScene(Constants.SceneName.SCENE_PRELOAD);
	}

//	#region Google Play Games Services
//	public void ShowAchievements () {
//		PlayGamesScript.ShowAchievementsUI ();
//	}
//
//	public void ShowLeaderboards () {
//		PlayGamesScript.ShowLeaderboardsUI ();
//	}
//
//	public void UpdatePointsText () {
//		
//	}
//	#endregion //Google Play Games Services
}
