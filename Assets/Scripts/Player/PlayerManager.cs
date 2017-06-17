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

    [SerializeField]
    PanelUI statsPanel;

    public void EndGame(GameObject winningPlayer)
    {
        if (GameState.InGame)
        {
            winningPlayerName = winningPlayer.GetComponent<PlayerManager>().playerName;

            GameState.InEndGame = true;

            statsPanel.IsVisible = false;

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
