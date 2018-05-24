using UnityEngine;
using UnityEngine.UI;

public class PanelMainMenu : BasePanel {
	public PanelLastResult panelLastResult;
	public PanelGameSelection panelGameSelection;

	public override void Show ()
	{
		base.Show ();
	}

	public override void Hide ()
	{
		base.Hide ();
	}

	#region button
	public void ButtonLastResultOnClick()
	{
		Hide();
		panelLastResult.Show();
	}

	public void ButtonTrainOnClick()
	{
		PlayerData.Instance.IsTraining = true;
		Hide();
		panelGameSelection.Show();
	}

	public void ButtonChallengeOnClick()
	{
		PlayerData.Instance.IsTraining = false;
		Hide();
		panelGameSelection.Show();
	}
	#endregion

	
}
