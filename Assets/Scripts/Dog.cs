using UnityEngine;

public class Dog : MonoBehaviour
{
	[SerializeField] private float _movementSpeed;
	[SerializeField] private float _rotationSpeed;
	[SerializeField] private Transform _cameraMount;

	private void Awake()
	{
		Debug.Log("Dog awaked");
	}

	private void Start()
	{
		Debug.Log("Dog started");
	}

	private void Update()
	{
		transform.Translate(Vector3.forward * (Input.GetAxis("Vertical") * _movementSpeed));
		transform.Rotate(Vector3.up, _rotationSpeed * Input.GetAxis("Horizontal"));
	}

	private void OnDestroy()
	{
		Debug.Log("Dog destroyed");
	}

	public void SetCamera(GameObject cam)
	{
		cam.transform.SetParent(_cameraMount, false);
	}
}
