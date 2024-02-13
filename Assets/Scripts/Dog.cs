using UnityEngine;
using UnityEngine.InputSystem;

public class Dog : MonoBehaviour
{
	private static readonly int Speed = Animator.StringToHash("Speed");
	private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
	private static readonly int Attack = Animator.StringToHash("Attack");

	[SerializeField] private float _movementSpeed;
	[SerializeField] private float _rotationSpeed;
	[SerializeField] private Transform _cameraMount;
	[SerializeField] private float _jumpHeight;
	[SerializeField] private Bullet _bullet;
	[SerializeField] private Transform _bulletSpawnPoint;
	[SerializeField] private float _shootingRate;
	[SerializeField] private Animator _anim;

	private EnemySpawner _enemySpawner;
	private bool _isGrounded;
	private float _nextShoot;

	private Rigidbody _rb;

	private float _xLook;
	private float _xMove;
	private float _yMove;

	public int Score { get; private set; }

	private void Start()
	{
		_rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		_rb.AddRelativeForce(Vector3.forward * (_movementSpeed * _yMove));
		_rb.AddRelativeForce(Vector3.right * (_movementSpeed * _xMove));
		_rb.AddRelativeTorque(Vector3.up * (_rotationSpeed * _xLook));
		_anim.SetFloat(Speed, _rb.velocity.magnitude);
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
			_anim.SetBool(IsGrounded, _isGrounded);
		}
	}

	private void OnCollisionExit(Collision other)
	{
		Debug.Log($"Dog collision exit {other.gameObject.name}");

		if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			_isGrounded = false;
			_anim.SetBool(IsGrounded, _isGrounded);
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
		_xMove = context.ReadValue<Vector2>().x;
		_yMove = context.ReadValue<Vector2>().y;
	}

	public void OnFirePressed(InputAction.CallbackContext context)
	{
		_anim.SetTrigger(Attack);
	}

	public void OnLookPressed(InputAction.CallbackContext context)
	{
		_xLook = context.ReadValue<Vector2>().x;
	}
}
