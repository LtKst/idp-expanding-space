using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb;
	Vector3 mousePosition;

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

	public void LookAtCursor()
	{
		mousePosition = Input.mousePosition;           
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

		Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
		transform.rotation = rot;
		transform.eulerAngles = new Vector3(0, 0,transform.eulerAngles.z);
	}

	public void Move()
	{
		rb.AddRelativeForce (Vector2.up * Input.GetAxis ("Vertical") * speed);

		finalSlowDownSpeed = Input.GetKeyDown ? slowDownSpeed : brakeSpeed;

		rb.velocity = Vector2.Lerp (rb.velocity, Vector2.zero, Time.deltaTime * finalSlowDownSpeed);

		print (rb.velocity.ToString());

		//rb.AddRelativeForce (Vector2.right * Input.GetAxis ("Horizontal") * speed);
	}
}
