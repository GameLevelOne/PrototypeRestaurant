using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceOrientation : MonoBehaviour {
	private static DeviceOrientation instance = null;
	public static DeviceOrientation Instance{
		get{ return instance; }
	}

	protected void Awake()
	{
		if(instance != null && instance != this) Destroy(gameObject);
		else instance = this;

		DontDestroyOnLoad(this.gameObject);
	}

	IEnumerator Start()
	{
		while(true) {
			if(Screen.orientation != ScreenOrientation.Portrait){
				if( Input.deviceOrientation == UnityEngine.DeviceOrientation.LandscapeLeft && Screen.orientation != ScreenOrientation.LandscapeLeft )
					Screen.orientation = ScreenOrientation.LandscapeLeft;
				if( Input.deviceOrientation == UnityEngine.DeviceOrientation.LandscapeRight && Screen.orientation != ScreenOrientation.LandscapeRight )
					Screen.orientation = ScreenOrientation.LandscapeRight;
			}
			yield return new WaitForSeconds(0.5f);
		}
	}

	public void SetPortrait()
	{
		Screen.orientation = ScreenOrientation.Portrait;
	}

	public void SetLandscape()
	{
		if(Input.deviceOrientation == UnityEngine.DeviceOrientation.LandscapeLeft)
			Screen.orientation = ScreenOrientation.LandscapeLeft;
		else 
			Screen.orientation = ScreenOrientation.LandscapeRight;
	}
}