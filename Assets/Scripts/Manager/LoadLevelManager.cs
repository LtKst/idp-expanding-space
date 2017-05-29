using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevelManager : MonoBehaviour {

    [SerializeField]
    Image fadeImage;
    [SerializeField]
    float fadeSpeed = 5;

    bool loadingLevel;

    private void Update()
    {
        if (loadingLevel)
        {
            fadeImage.color = Color.Lerp(fadeImage.color, Color.black, Time.unscaledDeltaTime * fadeSpeed);
            AudioListener.volume = Mathf.Lerp(AudioListener.volume, 0, Time.unscaledDeltaTime * fadeSpeed * 2);

            if (fadeImage.color.a >= 0.95f)
            {
                GameStateManager.GameStarted = false;
                GameStateManager.InGame = false;
                GameStateManager.GameEnded = false;

                GameObject.FindWithTag("Manager").GetComponent<PauseManager>().Resume();

                SceneManager.LoadScene(0);
            }
        }
    }

    public void LoadScene()
    {
        loadingLevel = true;
    }

    public bool IsLoading
    {
        get
        {
            return loadingLevel;
        }
    }
}
