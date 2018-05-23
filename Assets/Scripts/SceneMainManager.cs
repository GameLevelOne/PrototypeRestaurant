using UnityEngine;
using System;

public class SceneMainManager : MonoBehaviour {
	public PanelMainMenu panelMainMenu;

	void Start()
	{
		LoadLastResult();
		DeviceOrientation.Instance.SetPortrait();
		panelMainMenu.Show();
	}

	void LoadLastResult()
	{
		print("LOAD LAST RESULT");
		if(PlayerData.Instance.HasResult){
			DateTime lastResultDay = new DateTime(
				PlayerData.Instance.LastResultDate.Year,
				PlayerData.Instance.LastResultDate.Month,
				PlayerData.Instance.LastResultDate.Day
			);

			DateTime today = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);

			if(lastResultDay.CompareTo(today) > 0){
				PlayerData.Instance.HasResult = false;
			}
		}
	}
}
