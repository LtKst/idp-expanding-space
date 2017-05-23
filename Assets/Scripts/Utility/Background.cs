using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class Background : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Sprite[] backgrounds;
    [SerializeField]
    bool scaleBackground = true;

    [SerializeField]
    Image previewImage;

    [SerializeField]
    float colorLerpSpeed = 5;

    int currentBackground = 0;
    bool backgroundChanged = false;

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

    private void Update()
    {
        if (backgroundChanged)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, Color.black, Time.deltaTime * colorLerpSpeed);

            if (spriteRenderer.color.r <= 0.05f)
            {
                spriteRenderer.sprite = backgrounds[currentBackground];
                backgroundChanged = false;
            }
        }
        else
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, Color.white, Time.deltaTime * colorLerpSpeed);
        }
    }

    public void NextBackground()
    {
        if (currentBackground >= backgrounds.Length - 1)
        {
            currentBackground = 0;
        }
        else
        {
            currentBackground++;
        }

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
        previewImage.sprite = backgrounds[currentBackground];
        backgroundChanged = true;
    }
}
