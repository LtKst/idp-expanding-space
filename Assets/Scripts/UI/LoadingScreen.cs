using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour {

    [SerializeField]
    Image loadingBackground;
    [SerializeField]
    RectTransform loadingAnimation;

    [SerializeField]
    float rotationSpeed = 5;

    private void Start()
    {

    }

    private void Update()
    {
        if (Application.isLoadingLevel)
        {
            loadingAnimation.Rotate(new Vector3(0, 0, -1) * Time.unscaledDeltaTime * rotationSpeed);
        }
        else
        {
            loadingBackground.color = Color.Lerp(loadingBackground.color, new Color(loadingBackground.color.r, loadingBackground.color.g, loadingBackground.color.b, 0), Time.unscaledDeltaTime);

            if (loadingBackground.color.a <= 0.09f)
            {
                gameObject.SetActive(false);
            }
        }
    }
}