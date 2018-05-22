using UnityEngine;
using UnityEngine.UI;

public class PanelGameSelection : BasePanel {
	PanelMainMenu panelMainMenu;

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
	#endregion
}
