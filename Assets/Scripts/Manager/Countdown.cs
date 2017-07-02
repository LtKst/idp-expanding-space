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

        countdownText.text = "New round starting in " + seconds;

        for (int i = seconds - 1; i > -1; i--)
        {
            yield return new WaitForSeconds(1);

            countdownText.text = "New round starting in " + i;
        }

        GameState.InCountdown = false;
        inCountdown = false;
    }
}
