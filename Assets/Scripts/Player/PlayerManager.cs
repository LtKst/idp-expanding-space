using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    public enum Player { One, Two };
    public Player player;

    public string playerName;

    GameObject[] players;

    [SerializeField]
    GameObject otherPlayer;
    [HideInInspector]
    public string winningPlayerName;

    [SerializeField]
    InputField playerNameInputField;

    [SerializeField]
    PanelUI endScreen;
    [SerializeField]
    Text endScreenText;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    public void EndGame(GameObject winningPlayer)
    {
        if (GameStateManager.InGame)
        {
            //winningPlayerName = GameObject.FindWithTag("Player").GetComponent<PlayerManager>().playerName;

            winningPlayerName = winningPlayer.GetComponent<PlayerManager>().playerName;

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
