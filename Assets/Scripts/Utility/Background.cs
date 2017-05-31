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

    int selectedBackground = 0;
    bool backgroundChanged = false;
    bool flippingBackground = false;

    bool flipped = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        selectedBackground = PlayerPrefs.GetInt("selectedBackground", 0);
        ChangeBackground();

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

    private void OnScreenResize()
    {
        ScaleBackground();
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
        flippingBackground = true;
    }

    void ChangeBackground()
    {
        previewImage.sprite = backgrounds[selectedBackground];
        backgroundChanged = true;

        PlayerPrefs.SetInt("selectedBackground", selectedBackground);
    }
}
