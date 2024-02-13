using UnityEngine;

public class InterfaceController : MonoBehaviour
{
	[SerializeField] private HudView _hud;
	[SerializeField] private MenuView _menu;

	public void OnCancelClick()
	{
		_hud.Hide();
		Instantiate(_menu, transform).SetCloseCallback(OnMenuClosed);
	}

	private void OnMenuClosed()
	{
		_hud.Show();
	}
}
