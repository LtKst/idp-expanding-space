using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundSprite : MonoBehaviour {

    SpriteRenderer spriteRenderer;

    int selectedBackground = 0;
    bool backgroundChanged = false;
    bool flippingBackground = false;

    bool flipped = false;

    [SerializeField]
    Sprite[] backgrounds;
    [SerializeField]
    float colorLerpSpeed = 5;

    [Header("UI")]
    [SerializeField]
    Image previewImage;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Load and set the selected background from PlayerPrefs
        selectedBackground = PlayerPrefs.GetInt("selectedBackground", 0);
        spriteRenderer.sprite = backgrounds[selectedBackground];
        previewImage.sprite = backgrounds[selectedBackground];

        // Load and set flip from PlayerPrefs
        flipped = System.Convert.ToBoolean(PlayerPrefs.GetInt("flippedBackground"));
        spriteRenderer.flipX = flipped;
    }

    private void Update()
    {
        if (backgroundChanged || flippingBackground)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, Color.black, Time.unscaledDeltaTime * colorLerpSpeed);

            if (spriteRenderer.color.r <= 0.05f)
            {
                spriteRenderer.sprite = backgrounds[selectedBackground];
                spriteRenderer.flipX = flipped;

                backgroundChanged = false;
                flippingBackground = false;
            }
        }
        else
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, Color.white, Time.unscaledDeltaTime * colorLerpSpeed);
        }
    }

    public void NextBackground()
    {
        if (selectedBackground >= backgrounds.Length - 1)
        {
            selectedBackground = 0;
        }
        else
        {
            selectedBackground++;
        }

        ChangeBackground();
    }

    public void PreviousBackground()
    {
        if (selectedBackground <= 0)
        {
            selectedBackground = backgrounds.Length - 1;
        }
        else
        {
            selectedBackground--;
        }

        ChangeBackground();
    }

    public void RandomBackground()
    {
        int oldBackgroundIndex = selectedBackground;

        while (oldBackgroundIndex == selectedBackground)
        {
            selectedBackground = Random.Range(0, backgrounds.Length);
        }

        ChangeBackground();
    }

    public void FlipBackground()
    {
        flipped = !flipped;

        PlayerPrefs.SetInt("flippedBackground", System.Convert.ToInt32(flipped));

        flippingBackground = true;
    }

    void ChangeBackground()
    {
        previewImage.sprite = backgrounds[selectedBackground];
        backgroundChanged = true;

        PlayerPrefs.SetInt("selectedBackground", selectedBackground);
    }
}
