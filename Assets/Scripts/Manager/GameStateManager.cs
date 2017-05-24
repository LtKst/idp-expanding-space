using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {

    static bool gameStarted;
    static bool inGame;
    static bool gameEnded;

    [SerializeField]
    PanelUI mainPanel;
    [SerializeField]
    GameObject startUI;
    [SerializeField]
    GameObject pauseUI;

    public void StartGame()
    {
        gameStarted = true;

        mainPanel.ChangeAfterDisappear(startUI, pauseUI);
    }


    public static bool GameStarted
    {
        get
        {
            return gameStarted;
        }
        set
        {
            gameStarted = value;
        }
    }

    public static bool InGame
    {
        get
        {
            return inGame;
        }
        set
        {
            inGame = value;
        }
    }

    public static bool GameEnded
    {
        get
        {
            return gameEnded;
        }
        set
        {
            gameEnded = value;
        }
    }
}
