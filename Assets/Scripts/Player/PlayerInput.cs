using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	PlayerMovement playerMovement;

	void Start () {
		playerMovement = GetComponent<PlayerMovement> ();
	}

	void Update () {
		playerMovement.LookAtCursor (Input.mousePosition);
		playerMovement.Move (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Input.GetKey(KeyCode.Space));
	}
}
