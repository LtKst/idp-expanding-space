using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerShoot))]
public class PlayerInput : MonoBehaviour {

    PlayerManager playerManager;
	PlayerMovement playerMovement;
    PlayerShoot playerShoot;

	void Start () {
        playerManager = GetComponent<PlayerManager>();
		playerMovement = GetComponent<PlayerMovement>();
        playerShoot = GetComponent<PlayerShoot>();
	}

    void Update() {
        //playerMovement.LookAtCursor(Input.mousePosition);
        switch (playerManager.player)
        {
            case PlayerManager.Player.One:
                playerMovement.Move(Input.GetAxis("PlayerOneHorizontal"), Input.GetAxis("PlayerOneVertical"), Input.GetKey(KeyCode.Space));
                break;
            case PlayerManager.Player.Two:
                playerMovement.Move(Input.GetAxis("PlayerTwoHorizontal"), Input.GetAxis("PlayerTwoVertical"), Input.GetKey(KeyCode.Keypad0));
                break;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerShoot.Shoot();
        }
	}
}
