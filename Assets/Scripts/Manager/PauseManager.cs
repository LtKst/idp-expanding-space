using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    [SerializeField]
    uiPanel pausePanel;

    static bool isPaused;

    uiManager managerUI;

    private void Start()
    {
        managerUI = GameObject.FindWithTag("Manager").GetComponent<uiManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        isPaused = true;

        pausePanel.IsVisible = true;
    }

    public void Resume()
    {
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
