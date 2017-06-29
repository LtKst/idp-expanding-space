using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerShoot))]
[RequireComponent(typeof(PlayerEngine))]
public class PlayerInput : MonoBehaviour
{
    
    PlayerMovement playerMovement;
    PlayerShoot playerShoot;
    PlayerEngine playerEngine;

    // keys
    public string forward = "w";
    public string backward = "s";
    public string left = "a";
    public string right = "d";
    public string shoot = "left shift";

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerShoot = GetComponent<PlayerShoot>();
        playerEngine = GetComponent<PlayerEngine>();
    }

    private float GetPlayerAxis()
    {
        if (Input.GetKey(left))
            return -1;
        else if (Input.GetKey(right))
            return 1;
        else if (Input.GetKey(left) && Input.GetKey(right))
            return 0;
        else
            return 0;
    }

    private void Update()
    {
        if (GameState.InGame && !GameState.InCountdown && !PauseManager.IsPaused)
        {
            playerMovement.Move(GetPlayerAxis(), Input.GetKey(forward), Input.GetKey(backward));
            playerEngine.UpdateEngineSound(Input.GetKey(KeyCode.W));

            if (Input.GetKey(shoot))
            {
                playerShoot.Shoot();
            }
        }
    }
}
