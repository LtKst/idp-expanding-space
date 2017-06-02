using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerShoot))]
[RequireComponent(typeof(PlayerEngine))]
public class PlayerInput : MonoBehaviour
{

    PlayerManager playerManager;
    PlayerMovement playerMovement;
    PlayerShoot playerShoot;
    PlayerEngine playerEngine;

    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShoot = GetComponent<PlayerShoot>();
        playerEngine = GetComponent<PlayerEngine>();
    }

    private void Update()
    {
        if (GameStateManager.InGame && !PauseManager.IsPaused)
        {
            switch (playerManager.player)
            {
                case PlayerManager.Player.One:
                    playerMovement.Move(Input.GetAxis("PlayerOneHorizontal"), Input.GetKey(KeyCode.W), Input.GetKey(KeyCode.S));
                    playerEngine.UpdateEngineSound(Input.GetKey(KeyCode.W));

                    if (Input.GetKeyDown(KeyCode.LeftShift))
                    {
                        playerShoot.Shoot();
                    }
                    break;
                case PlayerManager.Player.Two:
                    playerMovement.Move(Input.GetAxis("PlayerTwoHorizontal"), Input.GetKey(KeyCode.UpArrow), Input.GetKey(KeyCode.DownArrow));
                    playerEngine.UpdateEngineSound(Input.GetKey(KeyCode.UpArrow));

                    if (Input.GetKeyDown(KeyCode.RightShift))
                    {
                        playerShoot.Shoot();
                    }
                    break;
            }
        }
    }
}
