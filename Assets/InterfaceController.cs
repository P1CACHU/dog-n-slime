using UnityEngine;

public class InterfaceController : MonoBehaviour
{
	[SerializeField] private MenuView _menu;
	[SerializeField] private HudView _hud;

	private bool _isGameMode = true;


	public void OnCancelClick()
	{
		if (_isGameMode)
		{
			_isGameMode = false;
			_hud.Hide();
			_menu.Show();
		}
		else
		{
			_isGameMode = true;
			_hud.Show();
			_menu.Hide();
		}
	}
}
