using UnityEngine;

public class Game : MonoBehaviour
{
	public GameObject _objectToInstantiate;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			Dog dog = FindObjectOfType<Dog>();
			if (dog != null)
			{
				Destroy(dog.gameObject);
			}
		}
		
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			Instantiate(_objectToInstantiate);
		}
	}
}
