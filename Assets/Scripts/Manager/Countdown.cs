using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    [SerializeField]
    int seconds;
    bool inCountdown;

    [SerializeField]
    Text countdownText;
    [SerializeField]
    PanelUI countdownPanel;

    private void Update()
    {
        if (GameState.InCountdown && !inCountdown)
        {
            StartCoroutine(StartCountdown());
            countdownPanel.SetVisibilityForSeconds(seconds);
        }
    }

    IEnumerator StartCountdown()
    {
        inCountdown = true;

        Utility.DestroyObjects.DestroyAllObject();

        string playerStats = GameObject.FindWithTag("Manager").GetComponent<PlayersManager>().PlayerOne.GetComponent<PlayerManager>().playerName + "\n"
            + GameObject.FindWithTag("Manager").GetComponent<PlayersManager>().PlayerOne.GetComponent<PlayerHealth>().Lives + " lives left\n\n"
            + GameObject.FindWithTag("Manager").GetComponent<PlayersManager>().PlayerTwo.GetComponent<PlayerManager>().playerName + "\n"
            + GameObject.FindWithTag("Manager").GetComponent<PlayersManager>().PlayerTwo.GetComponent<PlayerHealth>().Lives + " lives left";

        countdownText.text = playerStats + "\n\nNew round starting in " + seconds;

        for (int i = seconds - 1; i > -1; i--)
        {
            yield return new WaitForSeconds(1);

            countdownText.text = playerStats + "\n\nNew round starting in " + i;
        }

        GameState.InCountdown = false;
        inCountdown = false;
    }
}
