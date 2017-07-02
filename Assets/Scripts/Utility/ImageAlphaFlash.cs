using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageAlphaFlash : MonoBehaviour
{

    Image image;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float amplitude;

    private float initialAlpha;

    public bool playAutomatically;

    bool isPlaying;

    private void Start()
    {
        image = GetComponent<Image>();

        initialAlpha = image.color.a;

        isPlaying = playAutomatically;
    }

    private void Update()
    {
        if (isPlaying)
        {
            float alpha = initialAlpha + amplitude * Mathf.Sin(speed * Time.time);

            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
        }
    }

    public void Play()
    {
        initialAlpha = image.color.a;
        isPlaying = true;
    }

    public void Stop()
    {
        isPlaying = false;
        image.color = new Color(image.color.r, image.color.g, image.color.b, initialAlpha);
    }

    public bool IsPlaying
    {
        get
        {
            return isPlaying;
        }
    }
}
