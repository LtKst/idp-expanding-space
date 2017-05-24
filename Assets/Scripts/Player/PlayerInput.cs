using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerShoot))]
public class PlayerInput : MonoBehaviour
{

    PlayerManager playerManager;
    PlayerMovement playerMovement;
    PlayerShoot playerShoot;

    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShoot = GetComponent<PlayerShoot>();
    }

    private void Update()
    {
        if (GameStateManager.InGame && !PauseManager.IsPaused)
        {
            switch (playerManager.player)
            {
                case PlayerManager.Player.One:
                    playerMovement.Move(Input.GetAxis("PlayerOneHorizontal"), Input.GetKey(KeyCode.W), Input.GetKey(KeyCode.S));

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        playerShoot.Shoot();
                    }
                    break;
                case PlayerManager.Player.Two:
                    playerMovement.Move(Input.GetAxis("PlayerTwoHorizontal"), Input.GetKey(KeyCode.Keypad8), Input.GetKey(KeyCode.Keypad5));

                    if (Input.GetKeyDown(KeyCode.Keypad0))
                    {
                        playerShoot.Shoot();
                    }
                    break;
            }
        }
    }
}
