using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitManager : MonoBehaviour
{
    [SerializeField]
    Image fadeImage;
    [SerializeField]
    float fadeSpeed = 5;

    bool quitting;

    private void Update()
    {
        if (quitting)
        {
            fadeImage.color = Color.Lerp(fadeImage.color, Color.black, Time.deltaTime * fadeSpeed);

            if (fadeImage.color.a >= 0.95f)
            {
                AppHelper.Quit();

            }
        }
    }

    public void QuitGame()
    {
        quitting = true;
    }
}
