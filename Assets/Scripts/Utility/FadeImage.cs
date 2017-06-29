using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneFadeInOut : MonoBehaviour
{
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public IEnumerator FadeIn(float speed)
    {
        yield return StartCoroutine(Fade(image, speed, Color.black, Color.clear));
    }

    public IEnumerator FadeOut(float speed)
    {
        yield return StartCoroutine(Fade(image, speed, Color.clear, Color.black));
    }

    IEnumerator Fade(Image mat, float duration, Color startColor, Color endColor)
    {
        float start = Time.time;
        float elapsed = 0;

        while (elapsed < duration)
        {
            // calculate how far through we are
            elapsed = Time.time - start;
            float normalisedTime = Mathf.Clamp(elapsed / duration, 0, 1);
            mat.color = Color.Lerp(startColor, endColor, normalisedTime);
            // wait for the next frame
            yield return null;
        }
    }
}