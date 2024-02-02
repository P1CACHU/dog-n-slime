using TMPro;
using UnityEngine;

public class HudView : MonoBehaviour
{
	[SerializeField] private TMP_Text _playerLbl;
	[SerializeField] private TMP_Text _enemyLbl;

	public void RefreshScore(int dog, int slime)
	{
		_playerLbl.text = dog.ToString();
		_enemyLbl.text = slime.ToString();
	}

	public void OnMenuClick()
	{
		
	}
}
