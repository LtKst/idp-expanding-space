using UnityEngine;
using UnityEngine.UI;

public class PlayersManager : MonoBehaviour {

    [Header("Players")]
    [SerializeField]
    GameObject playerOne;
    [SerializeField]
    GameObject playerTwo;

    [Header("Name Input Fields")]
    [SerializeField]
    InputField playerOneNameInputField;
    [SerializeField]
    InputField playerTwoNameInputField;

    private void Start()
    {
        playerOne.GetComponent<PlayerManager>().playerName = "Player one";
        playerTwo.GetComponent<PlayerManager>().playerName = "Player two";
    }

    public void SetNames()
    {
        if (playerOneNameInputField.text != string.Empty)
        {
            playerOne.GetComponent<PlayerManager>().playerName = playerOneNameInputField.text;
        }

        if (playerTwoNameInputField.text != string.Empty)
        {
            playerTwo.GetComponent<PlayerManager>().playerName = playerTwoNameInputField.text;
        }
    }

    public GameObject PlayerOne
    {
        get
        {
            return playerOne;
        }
    }

    public GameObject PlayerTwo
    {
        get
        {
            return playerTwo;
        }
    }
}
