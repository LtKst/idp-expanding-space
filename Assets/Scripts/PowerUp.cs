using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class PowerUp : MonoBehaviour
{

    [SerializeField]
    float colorTransitionSpeed = 1;

    [SerializeField]
    float despawnTime = 15;
    bool despawned;

    SpriteRenderer spriteRenderer;
    Collider2D col;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        spriteRenderer.color = new Color(255, 255, 255, 0);
        col.enabled = false;
    }

    private void Update()
    {
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, new Color(255, 255, 255, 1), colorTransitionSpeed * Time.deltaTime);

        if (spriteRenderer.color.a >= 0.93)
        {
            col.enabled = true;
            UpdateTimer();
        }

        if (despawned)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, new Color(255, 255, 255, 0), colorTransitionSpeed * Time.deltaTime * 20);

            if (spriteRenderer.color.a <= 0.05)
            {
                Destroy(gameObject);
            }
        }
    }
<<<<<<< HEAD:Assets/Scripts/PowerUp.cs

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerPowerUp>())
        {
            collision.GetComponent<PlayerPowerUp>().GetPowerUp();

            despawned = true;
        }
    }
=======
>>>>>>> ec792f55fda1041e98791741b9328b1782982ceb:Assets/Scripts/PowerUp.cs

    private void UpdateTimer()
    {
        despawnTime -= Time.deltaTime;

        if (despawnTime <= 0)
        {
            despawned = true;
        }
    }
}
