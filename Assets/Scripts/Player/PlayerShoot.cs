using UnityEngine;

[RequireComponent(typeof(PlayerWeapon))]
public class PlayerShoot : MonoBehaviour
{

    [SerializeField]
    GameObject missile;
    GameObject missileInstance;

    [SerializeField]
    Transform shootPoint;

    [Header("Normal")]
    [SerializeField]
    float normalFireRate = 0.35f;
    [SerializeField]
    Color normalLaserColor;

    [Header("Burst")]
    [SerializeField]
    float burstFireRate = 1.4f;
    [SerializeField]
    int burstAmount = 3;
    [SerializeField]
    float burstDegree = 30;
    [SerializeField]
    Color burstColor;

    [Header("Automatic")]
    [SerializeField]
    float automaticFireRate = 0.20f;
    [SerializeField]
    Color automaticColor;

    [Header("God gun")]
    [SerializeField]
    float godFireRate = 0.02f;
    [SerializeField]
    Color godColor;

    float fireRate;
    float initialFireRate;

    [Header("Audio")]
    [SerializeField]
    AudioClip[] shootAudioClips;
    AudioSource audioSource;

    PlayerWeapon playerWeapon;

    bool canShoot = true;

    private void Start()
    {
        initialFireRate = normalFireRate;

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
    }

    public void Shoot()
    {
        if (canShoot)
        {
            switch (playerWeapon.currentWeapon)
            {
                case PlayerWeapon.Weapons.normal:

                    missileInstance = Instantiate(missile);
                    missileInstance.transform.SetPositionAndRotation(shootPoint.position, transform.rotation);
                    missileInstance.GetComponent<Laser>().belongsTo = gameObject;

                    missileInstance.GetComponent<SpriteRenderer>().color = normalLaserColor;

                    audioSource.PlayOneShot(shootAudioClips[Random.Range(0, shootAudioClips.Length)]);

                    break;

                case PlayerWeapon.Weapons.burst:

                    float degree = transform.rotation.z + burstDegree * (burstAmount/2);

                    for (int i = 0; i < burstAmount; i++)
                    {
                        missileInstance = Instantiate(missile);
                        missileInstance.transform.SetPositionAndRotation(shootPoint.position, transform.rotation);
                        missileInstance.GetComponent<Laser>().belongsTo = gameObject;

                        missileInstance.transform.Rotate(new Vector3(0, 0, degree));

                        missileInstance.GetComponent<SpriteRenderer>().color = burstColor;

                        degree -= burstDegree;

                        audioSource.PlayOneShot(shootAudioClips[Random.Range(0, shootAudioClips.Length)]);
                    }

                    break;

                case PlayerWeapon.Weapons.automatic:

                    missileInstance = Instantiate(missile);
                    missileInstance.transform.SetPositionAndRotation(shootPoint.position, transform.rotation);
                    missileInstance.GetComponent<Laser>().belongsTo = gameObject;

                    missileInstance.GetComponent<SpriteRenderer>().color = automaticColor;

                    audioSource.PlayOneShot(shootAudioClips[Random.Range(0, shootAudioClips.Length)]);

                    break;

                case PlayerWeapon.Weapons.god:

                    missileInstance = Instantiate(missile);
                    missileInstance.transform.SetPositionAndRotation(shootPoint.position, transform.rotation);
                    missileInstance.GetComponent<Laser>().belongsTo = gameObject;

                    missileInstance.GetComponent<SpriteRenderer>().color = godColor;

                    audioSource.PlayOneShot(shootAudioClips[Random.Range(0, shootAudioClips.Length)]);

                    break;
            }

            canShoot = false;
        }
    }

    public void UpdateFireRate()
    {
        switch (playerWeapon.currentWeapon)
        {
            case PlayerWeapon.Weapons.normal:

                initialFireRate = normalFireRate;

                break;

            case PlayerWeapon.Weapons.burst:

                initialFireRate = burstFireRate;

                break;

            case PlayerWeapon.Weapons.automatic:

                initialFireRate = automaticFireRate;

                break;

            case PlayerWeapon.Weapons.god:

                initialFireRate = godFireRate;

                break;
        }
    }
}