using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(AudioSource))]
public class PickUp : MonoBehaviour
{

    [SerializeField]
    float colorTransitionSpeed = 1;

    [SerializeField]
    float despawnTime = 15;
    [HideInInspector]
    public bool despawned;
    
    public AudioClip pickUpClip;
    [HideInInspector]
    public AudioSource audioSource;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = new Color(255, 255, 255, 0);

        audioSource = gameObject.GetComponent<AudioSource>();

        StartCoroutine(DespawnTimer());
    }

    private void Update()
    {
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, new Color(1, 1, 1, 1), colorTransitionSpeed * Time.deltaTime);

        if (despawned)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, new Color(1, 1, 1, 0), colorTransitionSpeed * Time.deltaTime * 20);

            if (spriteRenderer.color.a <= 0.05 && !audioSource.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator DespawnTimer()
    {
        yield return new WaitForSeconds(despawnTime);

        despawned = true;
    }
}
