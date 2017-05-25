using UnityEngine;

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

    [Header("Audio")]
    [SerializeField]
    AudioClip[] shootAudioClips;
    AudioSource audioSource;

    bool canShoot = true;

    private void Start()
    {
        initialFireRate = fireRate;

        audioSource = GetComponent<AudioSource>();
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
            missileInstance = Instantiate(missile);
            missileInstance.transform.SetPositionAndRotation(shootPoint.position, transform.rotation);
            missileInstance.GetComponent<Missile>().belongsTo = gameObject;

            audioSource.PlayOneShot(shootAudioClips[Random.Range(0, shootAudioClips.Length)]);

            canShoot = false;
        }
    }

    public float FireRate
    {
        get
        {
            return fireRate;
        }
        set
        {
            fireRate = value;
        }
    }
}