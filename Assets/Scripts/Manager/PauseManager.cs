using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    [SerializeField]
    PanelUI pausePanel;

    static bool isPaused;

    uiManager managerUI;

    private void Start()
    {
        managerUI = GameObject.FindWithTag("Manager").GetComponent<uiManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameStateManager.InGame)
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
    }

    public void Resume()
    {
        Time.timeScale = 1;
        managerUI.HideAllPanels();

        isPaused = false;
    }

    public static bool IsPaused
    {
        get
        {
            return isPaused;
        }
    }
}
