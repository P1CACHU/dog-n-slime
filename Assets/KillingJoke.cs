using UnityEngine;
using UnityEngine.InputSystem;

public class KillingJoke : MonoBehaviour
{
	[SerializeField] private Rigidbody _rb;
	[SerializeField] private float _force;

	private void Update()
	{
		if (Keyboard.current.oKey.isPressed)
		{
			_rb.AddForce(Vector3.up * _force);
		}
	}
}
