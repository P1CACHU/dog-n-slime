using System;
using TMPro;
using UnityEngine;

public class MenuView : MonoBehaviour
{
	[SerializeField] private TMP_Text _winnerLabel;

	public event Action RestartClicked;
	public event Action PauseClicked;

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
}
