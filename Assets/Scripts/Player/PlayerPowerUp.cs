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

    enum PowerUpTypes { regenarateHealth, speedUp, small, fireRateUp }
    PowerUpTypes currentPowerUp;

    [Header("Heal")]
    [SerializeField]
    int healAmount = 15;

    [Header("Speed")]
    [SerializeField]
    float speedIncrement = 1.2f;
    float initialSpeed;

    [Header("Scale")]
    [SerializeField]
    float scaleIncrement = 0.5f;
    Vector3 initialScale;

    [Header("Fire rate")]
    [SerializeField]
    float fireRateIncrement = 0.5f;
    float initialFireRate;

    bool hasPowerUp = false;
    bool resetPowerUps = false;

    public bool HasPowerUp
    {
        get
        {
            return hasPowerUp;
        }
    }

    float powerUpDuration = 15;
    float initialPowerUpDuration;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerShoot = GetComponent<PlayerShoot>();
        playerMovement = GetComponent<PlayerMovement>();

        initialSpeed = playerMovement.speed;
        initialScale = transform.localScale;
        initialFireRate = playerShoot.FireRate;

        initialPowerUpDuration = powerUpDuration;
    }

    private void Update()
    {
        if (hasPowerUp)
        {
            switch (currentPowerUp)
            {
                case PowerUpTypes.speedUp:
                    playerMovement.speed = initialSpeed * speedIncrement;
                    break;

                case PowerUpTypes.small:
                    transform.localScale = Vector3.Lerp(transform.localScale, initialScale * scaleIncrement, Time.deltaTime);
                    break;

                /*case PowerUpTypes.fireRateUp:
                    playerShoot.FireRate = initialFireRate * fireRateIncrement;
                    print("firerate");
                    break;*/
            }

            UpdateTimer();
        }
        else
        {
            ResetPowerUps();
        }
    }

    void ResetPowerUps()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, initialScale, Time.deltaTime);
        playerMovement.speed = initialSpeed;

        /*if (resetPowerUps)
        {
            playerShoot.FireRate = initialFireRate;
            resetPowerUps = false;
        }*/
    }

    public void GetPowerUp()
    {
        if (!hasPowerUp)
        {
            currentPowerUp = (PowerUpTypes)Random.Range(0, System.Enum.GetValues(typeof(PowerUpTypes)).Length);

            powerUpDuration = initialPowerUpDuration;

            if (currentPowerUp == PowerUpTypes.regenarateHealth)
            {
                playerHealth.Health += healAmount;
                return;
            }

            resetPowerUps = true;
            hasPowerUp = true;
        }
    }

    void UpdateTimer()
    {
        powerUpDuration -= Time.deltaTime;

        if (powerUpDuration <= 0)
        {
            hasPowerUp = false;
            powerUpDuration = initialPowerUpDuration;
        }
    }
}
