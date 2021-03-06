﻿using UnityEngine;
using UnityEngine.UI;

public class QuitManager : MonoBehaviour
{
    [SerializeField]
    Image fadeImage;
    [SerializeField]
    float fadeSpeed = 5;

    static bool quitting;

    private void Update()
    {
        if (quitting)
        {
            fadeImage.color = Color.Lerp(fadeImage.color, Color.black, Time.unscaledDeltaTime * fadeSpeed);
            AudioListener.volume = Mathf.Lerp(AudioListener.volume, 0, Time.unscaledDeltaTime * fadeSpeed * 2);

            if (fadeImage.color.a >= 0.95f)
            {
                ApplicationHelper.Quit();
            }
        }
    }

    public void QuitGame()
    {
        quitting = true;
    }

    public static bool IsQuitting
    {
        get
        {
            return quitting;
        }
    }
}
