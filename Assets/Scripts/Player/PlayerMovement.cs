﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb;

	[Header("Speed variables")]
	[SerializeField]
	float speed = 20;
	[SerializeField]
	float slowDownSpeed = 1;
	[SerializeField]
	float brakeSpeed = 10;

	float finalSlowDownSpeed;

	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	public void LookAtCursor(Vector3 mousePosition)
	{           
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

		Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
		transform.rotation = rot;
		transform.eulerAngles = new Vector3(0, 0,transform.eulerAngles.z);
	}

	public void Move(float horizontalMovement, float verticalMovement, bool getBrakeKey)
	{
		rb.AddRelativeForce (Vector2.up * verticalMovement * speed);

		finalSlowDownSpeed = getBrakeKey ? slowDownSpeed : brakeSpeed;

		rb.velocity = Vector2.Lerp (rb.velocity, Vector2.zero, Time.deltaTime * finalSlowDownSpeed);
	}
}
