using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersManager : MonoBehaviour {

    [SerializeField]
    PlayerManager playerOne;
    [SerializeField]
    InputField playerOneName;
    [SerializeField]
    PlayerManager playerTwo;
    [SerializeField]
    InputField playerTwoName;

    private void Start()
    {
        playerOne.GetComponent<PlayerManager>().playerName = "Player one";
        playerTwo.GetComponent<PlayerManager>().playerName = "Player two";
    }

    public void SetNames()
    {
        if (playerOneName.text != string.Empty)
        {
            playerOne.playerName = playerOneName.text;
        }

        if (playerTwoName.text != string.Empty)
        {
            playerTwo.playerName = playerTwoName.text;
        }
    }
}
