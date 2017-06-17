using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevelManager : MonoBehaviour {

    [SerializeField]
    Image fadeImage;
    [SerializeField]
    float fadeSpeed = 5;

    bool loadingLevel;

    PauseManager pauseManager;

    private void Start()
    {
        pauseManager = GetComponent<PauseManager>();
    }

    private void Update()
    {
        if (loadingLevel)
        {
            fadeImage.color = Color.Lerp(fadeImage.color, Color.black, Time.unscaledDeltaTime * fadeSpeed);
            AudioListener.volume = Mathf.Lerp(AudioListener.volume, 0, Time.unscaledDeltaTime * fadeSpeed * 2);

            if (fadeImage.color.a >= 0.95f)
            {
                GameState.GameStarted = false;
                GameState.InGame = false;
                GameState.InEndGame = false;

                pauseManager.Resume();

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
