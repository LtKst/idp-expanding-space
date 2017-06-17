using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerShoot))]
public class PlayerWeapon : MonoBehaviour
{
    PlayerShoot playerShoot;

    public enum Weapons { normal, burst, automatic, god }
    public Weapons currentWeapon = Weapons.normal;

    bool hasSpecialWeapon;

    [SerializeField]
    int specialWeaponDuration = 15;

    private void Start()
    {
        playerShoot = GetComponent<PlayerShoot>();
    }

    public void GetNewWeapon()
    {
        StartCoroutine(ChangeWeapon());
    }

    IEnumerator ChangeWeapon()
    {
        hasSpecialWeapon = true;

        currentWeapon = (Weapons)Random.Range(1, System.Enum.GetValues(typeof(Weapons)).Length);
        playerShoot.UpdateFireRate();

        yield return new WaitForSeconds(specialWeaponDuration);

        currentWeapon = Weapons.normal;
        playerShoot.UpdateFireRate();

        hasSpecialWeapon = false;
    }
}