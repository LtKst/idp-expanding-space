using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    PlayerShoot playerShoot;

    enum WeaponTypes { def, burst, automatic }
    WeaponTypes currentWeapon = WeaponTypes.def;

    private void Start()
    {
        playerShoot = GetComponent<PlayerShoot>();
    }

    public void GetNewWeapon()
    {
        currentWeapon = (WeaponTypes)Random.Range(0, System.Enum.GetValues(typeof(WeaponTypes)).Length);
    }
}