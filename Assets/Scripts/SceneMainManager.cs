using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneMainManager : MonoBehaviour {
	public GameObject landscapeDisp, portraitDisp;
	public Text textOrientation;
	public void ButtonLandscapeOnClick()
	{
		Screen.orientation = ScreenOrientation.Landscape;
		landscapeDisp.SetActive(true);
		portraitDisp.SetActive(false);
	}

	public void ButtonPortraitOnClick()
	{
		Screen.orientation = ScreenOrientation.Portrait;
		landscapeDisp.SetActive(false);
		portraitDisp.SetActive(true);
	}

	void OnRectTransformDimensionsChange()
	{
		textOrientation.text = Input.deviceOrientation.ToString();	
	}
}
