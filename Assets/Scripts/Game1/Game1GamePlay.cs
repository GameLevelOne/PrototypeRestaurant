//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game1GamePlay : MonoBehaviour {
	public GameObject panelPause, buttonPause;

	public void PauseGame () {
		Time.timeScale = 0;
		buttonPause.SetActive (false);
		panelPause.SetActive (true);
	}

	public void ResumeGame () {
		panelPause.SetActive (false);
		buttonPause.SetActive (true);
		Time.timeScale = 1;
	}

	public void BackToMenu () {
		SceneManager.LoadScene ("Game1");
	}
}
