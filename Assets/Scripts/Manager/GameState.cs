using UnityEngine;

public class GameState : MonoBehaviour {

    static bool gameStarted;

    static bool inGame;
    static bool inCountdown;
    static bool inEndGame;

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

    void OnplayerLost()
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

    public static bool InCountdown
    {
        get
        {
            return inCountdown;
        }
        set
        {
            inCountdown = value;
        }
    }

    public static bool InEndGame
    {
        get
        {
            return inEndGame;
        }
        set
        {
            inEndGame = value;
        }
    }
}
