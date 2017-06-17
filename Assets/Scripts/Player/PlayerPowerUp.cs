using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerShoot))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerPowerUp : MonoBehaviour
{
    PlayerHealth playerHealth;
    PlayerMovement playerMovement;

    enum PowerUpTypes { regenarateHealth, speedUp, small }
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

    bool hasPowerUp = false;

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
        playerMovement = GetComponent<PlayerMovement>();

        initialSpeed = playerMovement.speed;
        initialScale = transform.localScale;

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
