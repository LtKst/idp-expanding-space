using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStateManager : MonoBehaviour {

    static bool gameStarted;
    static bool inGame;
    static bool gameEnded;

    public void StartGame()
    {
        gameStarted = true;
    }

    public void StartInGame()
    {
        inGame = true;

        Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            go.SendMessage("OnStartInGame", SendMessageOptions.DontRequireReceiver);
        }
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
