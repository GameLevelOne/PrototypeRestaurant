using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum ErrorCode{
	Success,
	WrongCode
}

public class PopupCodeError : BasePopup {
	public Text textError;
	[Space(15f)]
	public string[] errorString;
	public int errCode = -1;
	public void Show (ErrorCode errorCode)
	{
		errCode = (int)errorCode;
		textError.text = errorString[(int)errorCode];
		Show ();
	}

	public void ButtonOkOnClick()
	{
		Hide();

		if(errCode == 0){
			SceneManager.LoadScene(Constants.SceneName.SCENE_PRELOAD);
		}
	}

}
