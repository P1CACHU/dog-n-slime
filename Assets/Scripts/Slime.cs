using System;
using UnityEngine;
using UnityEngine.AI;

public class Slime : MonoBehaviour
{
	[SerializeField] private NavMeshAgent _agent;

	private Transform _target;
	private int _score;
	
	public int Score => _score;

	private void Update()
	{
		if (Time.frameCount % 10 != 0)
		{
			return;
		}


		if (_target != null)
		{
			_agent.SetDestination(_target.position);
		}
	}

	public void SetTarget(Transform target)
	{
		if (_target != null)
		{
			return;
		}

		_target = target;
	}

	private void OnCollisionEnter(Collision other)
	{
		var component = other.gameObject.GetComponent<Turtle>();
		if (component != null)
		{
			_score += component.Points;
			Debug.Log($"Actual Slime score is {_score}");
			Destroy(other.gameObject);
		}

	}
}
