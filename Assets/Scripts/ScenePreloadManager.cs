using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class ScenePreloadManager : MonoBehaviour {
	public Image loadingBar;
	public Text textProgress;

	AsyncOperation asyncOperation;

	bool doneLoading = false;

	IEnumerator Start()
	{
		doneLoading = false;

		asyncOperation = SceneManager.LoadSceneAsync(PlayerData.Instance.SceneToLoad);
		asyncOperation.allowSceneActivation = false;

		while(!doneLoading){
			float progress = Mathf.Clamp01(asyncOperation.progress/0.9f);

			loadingBar.fillAmount = progress;
			textProgress.text = (progress*100).ToString("## '%'");

			if(asyncOperation.progress >= 0.9f){
				loadingBar.fillAmount = 1f;
				textProgress.text = "100 %";
				doneLoading = true;
			}
		}

		yield return new WaitForSeconds(2f);
		asyncOperation.allowSceneActivation = true;
	}
}