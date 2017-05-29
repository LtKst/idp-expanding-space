using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {

    static bool gameStarted;
    static bool inGame;
    static bool gameEnded;

    public void StartGame()
    {
        gameStarted = true;
    }

    void OnplayerDeath()
    {
        gameStarted = false;
        inGame = false;
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
