﻿using UnityEngine;

[RequireComponent(typeof(PlayerWeapon))]
public class PlayerShoot : MonoBehaviour
{

    [SerializeField]
    GameObject missile;
    GameObject missileInstance;

    [SerializeField]
    Transform shootPoint;

    [SerializeField]
    float fireRate = 0.5f;
    float initialFireRate;

    int burstAmount = 3;
    [SerializeField]
    float burstDegree = 30;

    [Header("Audio")]
    [SerializeField]
    AudioClip[] shootAudioClips;
    AudioSource audioSource;

    PlayerWeapon playerWeapon;

    [HideInInspector]
    public bool shootKeyDown;

    bool canShoot = true;

    private void Start()
    {
        initialFireRate = fireRate;

        audioSource = GetComponent<AudioSource>();
        playerWeapon = GetComponent<PlayerWeapon>();
    }

    private void Update()
    {
        if (fireRate >= 0 && !canShoot)
        {
            fireRate -= Time.deltaTime;
        }
        else if (fireRate <= 0)
        {
            canShoot = true;
            fireRate = initialFireRate;
        }

        if (playerWeapon.currentWeapon == PlayerWeapon.WeaponTypes.automatic && shootKeyDown)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        shootKeyDown = true;

        if (canShoot)
        {
            switch (playerWeapon.currentWeapon)
            {
                case PlayerWeapon.WeaponTypes.normal:

                    initialFireRate = 0.35f;

                    missileInstance = Instantiate(missile);
                    missileInstance.transform.SetPositionAndRotation(shootPoint.position, transform.rotation);
                    missileInstance.GetComponent<Laser>().belongsTo = gameObject;

                    missileInstance.GetComponent<SpriteRenderer>().color = Color.red;

                    audioSource.PlayOneShot(shootAudioClips[Random.Range(0, shootAudioClips.Length)]);

                    canShoot = false;

                    break;

                case PlayerWeapon.WeaponTypes.burst:
                    
                    initialFireRate = 0.35f * 4;

                    float degree = transform.rotation.z + burstDegree * (burstAmount/2);

                    print(degree);

                    for (int i = 0; i < burstAmount; i++)
                    {
                        missileInstance = Instantiate(missile);
                        missileInstance.transform.SetPositionAndRotation(shootPoint.position, transform.rotation);
                        missileInstance.GetComponent<Laser>().belongsTo = gameObject;

                        missileInstance.transform.Rotate(new Vector3(0, 0, degree));

                        missileInstance.GetComponent<SpriteRenderer>().color = Color.green;

                        degree -= burstDegree;

                        audioSource.PlayOneShot(shootAudioClips[Random.Range(0, shootAudioClips.Length)]);
                    }

                    canShoot = false;

                    break;

                case PlayerWeapon.WeaponTypes.automatic:

                    initialFireRate = 0.35f;

                    missileInstance = Instantiate(missile);
                    missileInstance.transform.SetPositionAndRotation(shootPoint.position, transform.rotation);
                    missileInstance.GetComponent<Laser>().belongsTo = gameObject;

                    missileInstance.GetComponent<SpriteRenderer>().color = Color.cyan;

                    audioSource.PlayOneShot(shootAudioClips[Random.Range(0, shootAudioClips.Length)]);

                    canShoot = false;

                    break;
            }
        }
    }
}