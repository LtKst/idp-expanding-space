using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public enum Player { One, Two };
    [Header("This player")]
    public Player player;

    public string playerName;

    [Header("Other player reference")]
    [SerializeField]
    GameObject otherPlayer;
    [HideInInspector]
    public string winningPlayerName;

    [Header("UI")]
    [SerializeField]
    InputField playerNameInputField;

    [SerializeField]
    PanelUI endScreen;
    [SerializeField]
    Text endScreenText;

    public void EndGame(GameObject winningPlayer)
    {
        if (GameStateManager.InGame)
        {
            //winningPlayerName = GameObject.FindWithTag("Player").GetComponent<PlayerManager>().playerName;

            winningPlayerName = winningPlayer.GetComponent<PlayerManager>().playerName;

            GameStateManager.GameEnded = true;

            endScreen.IsVisible = true;
            endScreenText.text = winningPlayerName + " is victorious!";
        }
    }

    public void SetName()
    {
        playerName = playerNameInputField.text;
    }

    public GameObject OtherPlayer
    {
        get
        {
            return otherPlayer;
        }
    }
}
