using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundScale : MonoBehaviour {

    SpriteRenderer spriteRenderer;

    [SerializeField]
    bool scaleBackground = true;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        ScaleBackground();
    }

    private void ScaleBackground()
    {
        if (scaleBackground)
        {
            transform.position = Vector3.zero;
            transform.localScale = Vector3.one;

            float width = spriteRenderer.sprite.bounds.size.x;
            float height = spriteRenderer.sprite.bounds.size.y;

            float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
            float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

            transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height, 0);
        }
    }

    private void OnScreenResize()
    {
        ScaleBackground();
    }
}
