using TMPro;
using UnityEngine;

public class HudView : MonoBehaviour
{
	[SerializeField] private TMP_Text _playerLbl;
	[SerializeField] private TMP_Text _enemyLbl;
	[SerializeField] private Animation _anim;

	private const string HudViewShowName = "HudViewShow";
	private const string HudViewHideName = "HudViewHide";

	public void RefreshScore(int dog, int slime)
	{
		_playerLbl.text = dog.ToString();
		_enemyLbl.text = slime.ToString();
	}

	public void Hide()
	{
		_anim.Play(HudViewHideName);
	}

	public void Show()
	{
		_anim.Play(HudViewShowName);
	}
}
