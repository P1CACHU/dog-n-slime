using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private GameObject[] _enemyPrefabs;
	[SerializeField] private Transform[] _spawnPoints;
	[SerializeField] private Slime _slime;

	private void Start()
	{
		InvokeRepeating(nameof(Spawn), 2.0f, 2.0f);
	}

	public void Spawn()
	{
		var spawnPointIndex = Random.Range(0, _spawnPoints.Length);
		var prefabIndex = Random.Range(0, _enemyPrefabs.Length);
		var go = Instantiate(_enemyPrefabs[prefabIndex], _spawnPoints[spawnPointIndex].position,
			_spawnPoints[spawnPointIndex].rotation);
		
		_slime.SetTarget(go.transform);
	}
}
