using System;
using UnityEngine;
using UnityEngine.UI;

public class PanelLastResult : BasePanel {
	public PanelMainMenu panelMainMenu;

	[Space(15f)]
	public GameObject validUntil;
	public Text textLastResultAmount;
	public Text textLastResultDate;

	public override void Show ()
	{
		if(!PlayerData.Instance.HasResult){
			ShowEmpty();
		}else{
			DateTime lastResultDay = new DateTime(
				PlayerData.Instance.LastResultDate.Year,
				PlayerData.Instance.LastResultDate.Month,
				PlayerData.Instance.LastResultDate.Day
			);

			DateTime today = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);

			if(lastResultDay.CompareTo(today) <= 0){
				ShowResult();
			}else{
				
				ShowEmpty();
			}
		}

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
	#endregion

	void ShowEmpty()
	{
		PlayerData.Instance.HasResult = false;

		validUntil.gameObject.SetActive(false);
		textLastResultDate.gameObject.SetActive(false);
		textLastResultAmount.text = "No Result";
	}

	void ShowResult()
	{
		validUntil.gameObject.SetActive(true);
		textLastResultDate.gameObject.SetActive(true);
		textLastResultAmount.text = PlayerData.Instance.LastResultAmount.ToString()+" %";

		DateTime dateFromData = PlayerData.Instance.LastResultDate;

		print(dateFromData.Month);
		string dateString = MonthString(dateFromData.Month) +" " + dateFromData.Day.ToString() + ", " + dateFromData.Year.ToString();
		textLastResultDate.text = dateString;
	}

	string MonthString(int mon)
	{
		string[] m = new string[12]{"Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"};
		return m[mon-1];
	}
}
