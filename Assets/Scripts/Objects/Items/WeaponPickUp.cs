using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(AudioSource))]
public class WeaponPickUp : MonoBehaviour
{

    [SerializeField]
    float colorTransitionSpeed = 1;

    [SerializeField]
    float despawnTime = 15;
    bool despawned;

    [SerializeField]
    AudioClip pickUpClip;
    AudioSource audioSource;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = new Color(255, 255, 255, 0);

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, new Color(255, 255, 255, 1), colorTransitionSpeed * Time.deltaTime);

        if (spriteRenderer.color.a >= 0.93)
        {
            UpdateTimer();
        }

        if (despawned)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, new Color(255, 255, 255, 0), colorTransitionSpeed * Time.deltaTime * 20);

            if (spriteRenderer.color.a <= 0.05 && !audioSource.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerPowerUp>())
        {
            // implement picking up here

            audioSource.PlayOneShot(pickUpClip);

            despawned = true;
        }
    }

    private void UpdateTimer()
    {
        despawnTime -= Time.deltaTime;

        if (despawnTime <= 0)
        {
            despawned = true;
        }
    }
}
