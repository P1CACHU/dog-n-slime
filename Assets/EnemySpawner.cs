using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private float _timeToSpawn;
	[SerializeField] private GameObject _enemyPrefab;
	[SerializeField] private Transform[] _spawnPoints;

	private float _currentTimer;

	private void Start()
	{
		ResetTimer();
	}

	private void Update()
	{
		_currentTimer -= Time.deltaTime;

		if (_currentTimer <= 0.0f)
		{
			int index = Random.Range(0, _spawnPoints.Length);
			Instantiate(_enemyPrefab, _spawnPoints[index].position, _spawnPoints[index].rotation);
			ResetTimer();
		}
	}

	private void ResetTimer()
	{
		_currentTimer = _timeToSpawn;
	}
}
