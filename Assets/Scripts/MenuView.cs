using System;
using TMPro;
using UnityEngine;

public class MenuView : MonoBehaviour
{
	private const string HideAnimationName = "MenuViewHide";
	[SerializeField] private TMP_Text _winnerLabel;
	[SerializeField] private Animation _anim;

	private Action _closeClicked;

	public event Action RestartClicked;
	public event Action PauseClicked;

	public void SetCloseCallback(Action close)
	{
		_closeClicked = close;
	}

	public void SetWinner(string text)
	{
		_winnerLabel.text = text;
	}

	public void OnRestartClick()
	{
		RestartClicked?.Invoke();
	}

	public void OnPauseClick()
	{
		PauseClicked?.Invoke();
	}

	public void OnCloseClick()
	{
		Hide();
		_closeClicked?.Invoke();
	}

	private void Hide()
	{
		_anim.Play(HideAnimationName);
	}

	public void OnHideComplete()
	{
		Destroy(gameObject);
	}
}
