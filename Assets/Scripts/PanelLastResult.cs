using System;
using UnityEngine;
using UnityEngine.UI;

public class PanelLastResult : BasePanel {
	public PanelMainMenu panelMainMenu;

	[Space(15f)]
	public RectTransform scrollContent;
	public GameObject redeemObject;
	public GameObject invalidatePrompt;
	public GameObject invalidateSuccessful;
	public Text textLastResultAmount;
	public Text textLastResultDate;

	Vector2 scrollContentOriginPos;

	void Awake()
	{
		scrollContentOriginPos = new Vector2(0,-232.85f);
	}

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
		scrollContent.anchoredPosition = scrollContentOriginPos;
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

		redeemObject.SetActive(false);
		textLastResultDate.gameObject.SetActive(false);
		textLastResultAmount.text = "No Result";
	}

	void ShowResult()
	{
		
		textLastResultDate.gameObject.SetActive(true);
		textLastResultAmount.text = PlayerData.Instance.LastResultAmount.ToString()+" %";

		DateTime dateFromData = PlayerData.Instance.LastResultDate;

		print(dateFromData.Month);
		string dateString = MonthString(dateFromData.Month) +" " + dateFromData.Day.ToString() + ", " + dateFromData.Year.ToString();
		textLastResultDate.text = dateString;

		redeemObject.SetActive(true);
		invalidatePrompt.SetActive(true);
		invalidateSuccessful.SetActive(false);
	}

	string MonthString(int mon)
	{
		string[] m = new string[12]{"Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"};
		return m[mon-1];
	}

	public void ButtonInvalidateOnClick()
	{
		PlayerData.Instance.HasResult = false;
		invalidatePrompt.SetActive(false);
		invalidateSuccessful.SetActive(true);
		//successful
	}
}
