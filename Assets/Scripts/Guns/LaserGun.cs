using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LaserGun : MonoBehaviour {

    [SerializeField]
    string laserGunName;
    
    [SerializeField]
    GameObject laser;
    GameObject laserInstance;

	[SerializeField]
    float fireRate = 0.35f;

    [SerializeField]
    int fireAmount = 1;
    [SerializeField]
    float burstDegree;

    float degree;
    
    [SerializeField]
    Color laserColor = new Color(0, 0, 0, 1);
    
    [SerializeField]
    AudioClip shootAudioClip;
    AudioSource audioSource;

    [SerializeField]
    Sprite gunSprite;
    
    bool canShoot = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        if (canShoot)
        {
            if (fireAmount > 0)
                degree = transform.rotation.z + burstDegree * (fireAmount / 2);
            else
                degree = transform.rotation.z;

            for (int i = 0; i < fireAmount; i++)
            {
                laserInstance = Instantiate(laser);
                laserInstance.transform.SetPositionAndRotation(transform.position, transform.rotation);
                laserInstance.GetComponent<Laser>().belongsTo = gameObject;

                laserInstance.transform.Rotate(new Vector3(0, 0, degree));

                laserInstance.GetComponent<SpriteRenderer>().color = laserColor;

                degree -= burstDegree;

                audioSource.pitch = Random.Range(0.9f, 1.1f);
                audioSource.PlayOneShot(shootAudioClip);
            }

            StartCoroutine(WaitForFireRate());
        }
    }

    IEnumerator WaitForFireRate()
    {
        canShoot = false;

        yield return new WaitForSeconds(fireRate);

        canShoot = true;
    }

    public Sprite GunSprite
    {
        get
        {
            return gunSprite;
        }
    }
}
