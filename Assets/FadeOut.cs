using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

    float lerpSpeed = 4;

    Color currentColor;

    bool fadedOut = false;

    private void Start()
    {
        currentColor = GetComponent<Image>().color;
    }

    private void Update()
    {
        if (!fadedOut)
        {
            GetComponent<Image>().color = Color.Lerp(GetComponent<Image>().color, new Color(currentColor.r, currentColor.g, currentColor.b, 0), Time.unscaledDeltaTime * lerpSpeed);

            if (GetComponent<Image>().color.a <= 0.007)
                fadedOut = true;
        }
    }
}
