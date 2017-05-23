using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersManager : MonoBehaviour {

    [SerializeField]
    GameObject playerOne;
    [SerializeField]
    InputField playerOneName;
    [SerializeField]
    GameObject playerTwo;
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
            playerOne.GetComponent<PlayerManager>().playerName = playerOneName.text;
        }

        if (playerTwoName.text != string.Empty)
        {
            playerTwo.GetComponent<PlayerManager>().playerName = playerTwoName.text;
        }
    }
}
