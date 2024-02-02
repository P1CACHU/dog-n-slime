using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
	private const string NewGameSceneName = "TEWCPL_Scene";

	[SerializeField] private GameObject _objectToInstantiate;
	[SerializeField] private Transform _spawnPoint;
	[SerializeField] private GameObject _camera;
	[SerializeField] private EnemySpawner _enemySpawner;
	[SerializeField] private int _maxScore;
	[SerializeField] private Slime _slime;
	[SerializeField] private MenuView _menu;
	[SerializeField] private HudView _hud;

	private readonly List<GameObject> _objectsToDestroy = new();
	private Dog _dog;
	private bool _isPaused;
	private Vector3 _vector;

	private void Awake()
	{
		Time.timeScale = 1;
		var go = Instantiate(_objectToInstantiate, _spawnPoint.position, _spawnPoint.rotation);
		_dog = go.GetComponent<Dog>();
		if (_dog != null)
		{
			_dog.SetCamera(_camera);
			_dog.SetSpawner(_enemySpawner);
		}

		Register(go);

		_menu.RestartClicked += OnRestartClicked;
		_menu.PauseClicked += OnPauseClicked;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.H))
		{
			if (_objectsToDestroy.Count > 0)
			{
				Destroy(_objectsToDestroy[0]);
				_objectsToDestroy.RemoveAt(0);
			}
		}

		if (_dog.Score >= _maxScore)
		{
			_menu.SetWinner("<color=green>DOG WINS</color>");
			_hud.gameObject.SetActive(false);
			_menu.gameObject.SetActive(true);
			Time.timeScale = 0;
		}

		if (_slime.Score >= _maxScore)
		{
			_menu.SetWinner("<color=red>SLIME WINS</color>");
			_hud.gameObject.SetActive(false);
			_menu.gameObject.SetActive(true);
			Time.timeScale = 0;
		}

		_hud.RefreshScore(_dog.Score, _slime.Score);
	}

	private void OnDestroy()
	{
		_menu.RestartClicked -= OnRestartClicked;
		_menu.PauseClicked -= OnPauseClicked;
	}

	private void OnPauseClicked()
	{
		TogglePause();
	}

	private void TogglePause()
	{
		if (_isPaused)
		{
			_isPaused = false;
		}
		else
		{
			_isPaused = true;
		}

		if (_isPaused)
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}
	}

	private void OnRestartClicked()
	{
		SceneManager.LoadScene(NewGameSceneName);
	}

	private void Register(GameObject objectToDestroy)
	{
		_objectsToDestroy.Add(objectToDestroy);
	}
}
