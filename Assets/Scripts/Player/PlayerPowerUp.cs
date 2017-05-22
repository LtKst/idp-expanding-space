using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerShoot))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerPowerUp : MonoBehaviour
{
    PlayerHealth playerHealth;
    PlayerShoot playerShoot;
    PlayerMovement playerMovement;

    [SerializeField]
    int healAmount = 15;
    [SerializeField]
    float speedIncrement = 1.2f;
    float initialSpeed;

    [SerializeField]
    float scaleIncrement = 0.5f;
    Vector3 initialScale;

    enum PowerUpTypes { small, speedUp, fireRateUp, regenarateHealth }
    PowerUpTypes currentPowerUp;

    bool playerHasPowerUp = false;

    float powerUpDuration = 15;
    float initialPowerUpDuration;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerShoot = GetComponent<PlayerShoot>();
        playerMovement = GetComponent<PlayerMovement>();

        initialSpeed = playerMovement.speed;
        initialScale = transform.localScale;

        initialPowerUpDuration = powerUpDuration;
    }

    private void Update()
    {
        ResetPowerUps();

        if (playerHasPowerUp)
        {
            switch (currentPowerUp)
            {
                case PowerUpTypes.fireRateUp:

                    break;

                case PowerUpTypes.regenarateHealth:
                    playerHealth.Health += healAmount;
                    break;

                case PowerUpTypes.small:
                    transform.localScale = Vector3.Lerp(transform.localScale, initialScale * scaleIncrement, Time.deltaTime);
                    break;

                case PowerUpTypes.speedUp:
                    playerMovement.speed = initialSpeed * speedIncrement;
                    break;
            }

            UpdateTimer();
        }
    }

    void ResetPowerUps()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, initialScale, Time.deltaTime);
        playerMovement.speed = initialSpeed;
    }

    public void GetPowerUp()
    {
        currentPowerUp = (PowerUpTypes)Random.Range(0, System.Enum.GetValues(typeof(PowerUpTypes)).Length);

        playerHasPowerUp = true;
    }

    void UpdateTimer()
    {
        powerUpDuration -= Time.deltaTime;

        if (powerUpDuration <= 0)
        {
            playerHasPowerUp = false;
            powerUpDuration = initialPowerUpDuration;
        }
    }
}
