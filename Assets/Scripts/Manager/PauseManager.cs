using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    [SerializeField]
    uiPanel pausePanel;

    static bool isPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            pausePanel.IsVisible = isPaused;
            //Time.timeScale = isPaused ? 1 : 0;
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
