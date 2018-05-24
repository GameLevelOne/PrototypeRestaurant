using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelGameSelection : BasePanel {
	public PanelMainMenu panelMainMenu;
	public PopupInputCode popupInputCode;

	public override void Show ()
	{
		base.Show ();
	}

	public override void Hide ()
	{
		panelMainMenu.Show();
		base.Hide ();
	}

	#region button
	public void ButtonBackOnClick()
	{
		Hide();
	}

	public void ButtonGame(int index)
	{
		switch(index){
		case 1: PlayerData.Instance.SceneToLoad = Constants.SceneName.SCENE_GAME1; break;
		case 2: PlayerData.Instance.SceneToLoad = Constants.SceneName.SCENE_GAME2; break;
		case 3: PlayerData.Instance.SceneToLoad = Constants.SceneName.SCENE_GAME3; break;
		default: break;
		}

		if(PlayerData.Instance.IsTraining){
			SceneManager.LoadScene(Constants.SceneName.SCENE_PRELOAD);
		}else{
			popupInputCode.Show();
		}
	}
	#endregion
}
