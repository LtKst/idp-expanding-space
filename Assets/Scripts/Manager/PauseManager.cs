using UnityEngine;

public class PauseManager : MonoBehaviour {

    [SerializeField]
    PanelUI pausePanel;

    static bool isPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameState.InGame && !GameState.InEndGame)
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;

        pausePanel.IsVisible = true;

        isPaused = true;

        Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            go.SendMessage("OnPaused", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;

        isPaused = false;

        UIManager.HideAllPanels();

        Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            go.SendMessage("OnResumed", SendMessageOptions.DontRequireReceiver);
        }
    }

    public static bool IsPaused
    {
        get
        {
            return isPaused;
        }
    }
}
