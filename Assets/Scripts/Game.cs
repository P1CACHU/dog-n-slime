using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField] private GameObject _objectToInstantiate;
	[SerializeField] private Transform _spawnPoint;
	[SerializeField] private GameObject _camera;

	private readonly List<GameObject> _objectsToDestroy = new();

	private Vector3 _vector;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			if (_objectsToDestroy.Count > 0)
			{
				Destroy(_objectsToDestroy[0]);
				_objectsToDestroy.RemoveAt(0);
			}
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			var go = Instantiate(_objectToInstantiate, _spawnPoint.position, _spawnPoint.rotation);
			var component = go.GetComponent<Dog>();
			if (component != null)
			{
				component.SetCamera(_camera);
			}
			Register(go);
		}
	}

	private void Register(GameObject objectToDestroy)
	{
		_objectsToDestroy.Add(objectToDestroy);
	}
}
