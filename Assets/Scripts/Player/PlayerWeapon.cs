using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    public enum WeaponTypes { normal, burst, automatic }
    public WeaponTypes currentWeapon = WeaponTypes.normal;

    public void GetNewWeapon()
    {
        currentWeapon = (WeaponTypes)Random.Range(0, System.Enum.GetValues(typeof(WeaponTypes)).Length);
    }
}