using UnityEngine;

namespace Utility
{
    public class DestroyObjects : MonoBehaviour
    {

        public static void DestroyAllObject()
        {
            Laser[] lasers = FindObjectsOfType<Laser>();

            if (lasers != null)
            {
                for (int i = 0; i < lasers.Length; i++)
                {
                    Destroy(lasers[i].gameObject);
                }
            }

            Asteroid[] asteroids = FindObjectsOfType<Asteroid>();

            if (asteroids != null)
            {
                for (int i = 0; i < asteroids.Length; i++)
                {
                    Destroy(asteroids[i].gameObject);
                }
            }

            PowerUp[] powerUps = FindObjectsOfType<PowerUp>();

            if (powerUps != null)
            {
                for (int i = 0; i < powerUps.Length; i++)
                {
                    Destroy(powerUps[i].gameObject);
                }
            }

            WeaponPickUp[] weapons = FindObjectsOfType<WeaponPickUp>();

            if (weapons == null)
            {
                for (int i = 0; i < weapons.Length; i++)
                {
                    Destroy(weapons[i].gameObject);
                }
            }
        }
    }
}