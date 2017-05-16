using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	PlayerMovement playerMovement;
    PlayerShoot playerShoot;

    [SerializeField]
    bool lookAtCursor;

	void Start () {
		playerMovement = GetComponent<PlayerMovement>();
        playerShoot = GetComponent<PlayerShoot>();
	}

	void Update () {
		//playerMovement.LookAtCursor(Input.mousePosition);

		playerMovement.Move(Input.GetAxis("PlayerOneHorizontal"), Input.GetAxis("PlayerOneVertical"), Input.GetKey(KeyCode.Space));

        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerShoot.Shoot();
        }
	}
}
