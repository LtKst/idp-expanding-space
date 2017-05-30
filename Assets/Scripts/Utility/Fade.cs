using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Fade : MonoBehaviour {
    
    [SerializeField]
    float lerpSpeed = 4;

    [SerializeField]
    Color startColor;

    [SerializeField]
    bool fade = true;
    bool doneFading = false;

    Image image;

    [SerializeField]
    UnityEvent onFinishFade;

    private void Start()
    {
        image = GetComponent<Image>();

        image.color = startColor;
    }

    private void Update()
    {
        if (!doneFading && fade)
        {
            image.color = Color.Lerp(image.color, new Color(startColor.r, startColor.g, startColor.b, 0), Time.unscaledDeltaTime * lerpSpeed);

            if (image.color.a <= 0.007)
            {
                if (onFinishFade != null)
                {
                    onFinishFade.Invoke();
                }
                doneFading = true;
            }
        }
    }

    public void StartFade()
    {
        fade = true;
    }
}
