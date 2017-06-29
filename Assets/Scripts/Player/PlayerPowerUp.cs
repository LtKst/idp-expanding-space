using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerShoot))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerPowerUp : MonoBehaviour
{
    PlayerHealth playerHealth;
    PlayerMovement playerMovement;

    enum PowerUpTypes { regenarateHealth, speedUp, bubbleShield }
    PowerUpTypes currentPowerUp;

    [Header("Heal")]
    [SerializeField]
    int healAmount = 15;
    Sprite healSprite;

    [Header("Speed")]
    [SerializeField]
    float speedIncrement = 1.2f;
    Sprite speedSprite;


    /* Scale power up no longer used
    [Header("Scale")]
    [SerializeField]
    float scaleIncrement = 0.5f;
    Vector3 initialScale;
    Sprite scaleSprite;
    */

    [Header("UI")]
    PanelUI powerUpPanel;

    bool hasPowerUp = false;

    public bool HasPowerUp
    {
        get
        {
            return hasPowerUp;
        }
    }

    float powerUpDuration = 15;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerMovement = GetComponent<PlayerMovement>();

        //initialScale = transform.localScale;
    }

    private IEnumerator PowerUpDurationTimer()
    {
        hasPowerUp = true;

        yield return new WaitForSeconds(powerUpDuration);

        hasPowerUp = false;
    }

    public void GetPowerUp()
    {
        currentPowerUp = (PowerUpTypes)Random.Range(0, System.Enum.GetValues(typeof(PowerUpTypes)).Length);

        switch (currentPowerUp)
        {
            case PowerUpTypes.regenarateHealth:

                playerHealth.Heal(healAmount);

                break;

            case PowerUpTypes.speedUp:

                StartCoroutine(playerMovement.SpeedUpForSeconds(playerMovement.Speed * speedIncrement, powerUpDuration));

                break;

            case PowerUpTypes.bubbleShield:

                StartCoroutine(playerHealth.GetBubbleShield(powerUpDuration));

                break;

            default:

                StartCoroutine(PowerUpDurationTimer());

                break;
        }
    }
}
