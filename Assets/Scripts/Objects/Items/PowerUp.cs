using UnityEngine;

public class PowerUp : PickUp
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerPowerUp>())
        {
            if (!collision.GetComponent<PlayerPowerUp>().HasPowerUp)
            {
                collision.GetComponent<PlayerPowerUp>().GetPowerUp();

                audioSource.PlayOneShot(pickUpClip);

                despawned = true;
            }
        }
    }
}
