using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Background : MonoBehaviour
{
    [SerializeField]
    bool randomizeBackground = true;
    [SerializeField]
    Sprite[] randomWallpaper;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (randomizeBackground)
        {
            spriteRenderer.sprite = randomWallpaper[Random.Range(0, randomWallpaper.Length)];
        }

        transform.position = Vector3.zero;
        transform.localScale = Vector3.one;

        float width = spriteRenderer.sprite.bounds.size.x;
        float height = spriteRenderer.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height, 0);
    }
}
