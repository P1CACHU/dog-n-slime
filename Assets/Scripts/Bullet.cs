using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private float _lifetime;
	[SerializeField] private Rigidbody _rb;

	private void Start()
	{
		Destroy(gameObject, _lifetime);
	}

	public void Shoot()
	{
		_rb.AddForce((transform.position + Vector3.forward) * _speed);
	}
}
