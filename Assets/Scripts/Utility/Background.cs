using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class Background : MonoBehaviour
{
    [SerializeField]
    Sprite[] backgrounds;
    [SerializeField]
    bool scaleBackground = true;

    [SerializeField]
    Image previewImage;

    int currentBackground = 0;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

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

    public void NextBackground()
    {
        if (currentBackground >= backgrounds.Length - 1)
            currentBackground = 0;
        else
            currentBackground++;

        ChangeBackground();
    }

    public void PreviousBackground()
    {
        if (currentBackground <= 0)
            currentBackground = backgrounds.Length - 1;
        else
            currentBackground--;

        ChangeBackground();
    }

    void ChangeBackground()
    {
        spriteRenderer.sprite = backgrounds[currentBackground];
        previewImage.sprite = backgrounds[currentBackground];
    }
}
