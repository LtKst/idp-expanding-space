using System.Collections;
using UnityEngine;

public class WeaponPickUp : PickUp
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerShoot>() && !collision.GetComponent<PlayerShoot>().HasSpecialGun && !despawned)
        {
            collision.GetComponent<PlayerShoot>().GetSpecialWeapon();

            audioSource.PlayOneShot(pickUpClip);

            despawned = true;
        }
    }
}
