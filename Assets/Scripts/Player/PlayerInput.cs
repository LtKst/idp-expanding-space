using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	PlayerMovement playerMovement;

	void Start () {
		playerMovement = GetComponent<PlayerMovement> ();
	}

	void Update () {
		playerMovement.LookAtCursor ();
		playerMovement.Move ();
	}
}
