using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LaserGun))]
public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    LaserGun laserGun;
    LaserGun defaultGun;
    [SerializeField]
    LaserGun[] specialGuns;

    [SerializeField]
    float specialWeaponDuration = 15;

    [Header("UI")]
    [SerializeField]
    PanelUI specialGunNotificationPanel;
    [SerializeField]
    Image specialGunNotificationImage;
    [SerializeField]
    float specialGunNotificationTime = 5;

    bool hasSpecialGun;

    private void Start()
    {
        defaultGun = laserGun;
    }

    public void Shoot()
    {
        laserGun.Shoot();
    }

    public void GetSpecialWeapon()
    {
        StartCoroutine(ChangeWeapon());

        specialGunNotificationImage.sprite = laserGun.GunSprite;
        specialGunNotificationPanel.SetVisibilityForSeconds(specialGunNotificationTime);
    }

    IEnumerator ChangeWeapon()
    {
        hasSpecialGun = true;

        laserGun = specialGuns[Random.Range(0, specialGuns.Length)];

        yield return new WaitForSeconds(specialWeaponDuration);

        laserGun = defaultGun;

        hasSpecialGun = false;
    }

    private void OnPlayerDeath()
    {
        laserGun = defaultGun;
    }

    public bool HasSpecialGun
    {
        get
        {
            return hasSpecialGun;
        }
    }
}