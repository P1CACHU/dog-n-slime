using UnityEngine;
using UnityEngine.InputSystem;

public class Dog : MonoBehaviour
{
	[SerializeField] private float _movementSpeed;
	[SerializeField] private float _rotationSpeed;
	[SerializeField] private Transform _cameraMount;
	[SerializeField] private float _jumpHeight;
	[SerializeField] private Bullet _bullet;
	[SerializeField] private Transform _bulletSpawnPoint;
	[SerializeField] private float _shootingRate;

	private EnemySpawner _enemySpawner;
	private bool _isGrounded;
	private float _nextShoot;

	private Rigidbody _rb;

	public int Score { get; private set; }

	private void Start()
	{
		_rb = GetComponent<Rigidbody>();
	}

	private void OnCollisionEnter(Collision other)
	{
		var component = other.gameObject.GetComponent<Turtle>();
		if (component != null)
		{
			Score += component.Points;
			Destroy(other.gameObject);
		}

		if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			_isGrounded = true;
		}
	}

	private void OnCollisionExit(Collision other)
	{
		Debug.Log($"Dog collision exit {other.gameObject.name}");

		if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			_isGrounded = false;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		_enemySpawner.Spawn();
	}

	public void SetCamera(GameObject cam)
	{
		cam.transform.SetParent(_cameraMount, false);
	}

	public void SetSpawner(EnemySpawner spawner)
	{
		_enemySpawner = spawner;
	}

	public void OnJumpPressed(InputAction.CallbackContext context)
	{
		if (context.performed && _isGrounded)
		{
			Debug.Log("Dog jumped");
			_rb.AddForce(Vector3.up * _jumpHeight);
		}
	}

	public void OnMovePressed(InputAction.CallbackContext context)
	{
		transform.Translate(Vector3.forward * context.ReadValue<Vector2>().y * _movementSpeed);
		transform.Rotate(Vector3.up, _rotationSpeed * context.ReadValue<Vector2>().x);
	}

	public void OnFirePressed(InputAction.CallbackContext context)
	{
		if (!context.performed || !(_nextShoot <= Time.time))
		{
			return;
		}

		Instantiate(_bullet, _bulletSpawnPoint.position, _bulletSpawnPoint.localRotation).Shoot();
		_nextShoot = Time.time + _shootingRate;
	}
}
