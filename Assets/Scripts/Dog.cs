using System;
using Unity.VisualScripting;
using UnityEngine;

public class Dog : MonoBehaviour
{
	private void Awake()
	{
		Debug.Log("Dog awaked");
	}

	private void Start()
	{
		Debug.Log("Dog started");
	}

	// private void Update()
	// {
	// 	Debug.Log("Dog updated");
	// }
	//
	// private void FixedUpdate()
	// {
	// 	Debug.Log("Dog fixed updated");
	// }
	//
	// private void LateUpdate()
	// {
	// 	Debug.Log("Dog late updated");
	// }

	// private void OnEnable()
	// {
	// 	Debug.Log("Dog enabled");
	// }
	//
	// private void OnDisable()
	// {
	// 	Debug.Log("Dog disabled");
	// }

	private void OnDestroy()
	{
		Debug.Log("Dog destroyed");
	}
}
