using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField]
    GameObject preStartUI;
    [SerializeField]
    Text startCountDownText;
    [SerializeField]
    bool instaStart;
    [SerializeField]
    Text endCountDownText;

    float startTimer = 3;
    bool gameCountDownStarted = false;
    bool startCountDownBusy = false;

    string startText = "Go!";

    static bool gameStarted = false;

    float endTimer = 10;
    bool endCountDownBusy = false;
    bool gameEnded = false;

    string victoriousPlayerName;

    private void Start()
    {
        if (instaStart)
        {
            gameStarted = true;
            endCountDownText.gameObject.SetActive(false);
        }
        else
        {
            gameStarted = false;
        }
    }

    private void Update()
    {
        if (!startCountDownBusy && startTimer >= 1 && gameCountDownStarted)
        {
            StartCoroutine(StartCountDown());
        }
        else if (startTimer < 1)
        {
            gameStarted = true;

            if (startCountDownText.color.a >= 0)
            {
                startCountDownText.text = startText;

                startCountDownText.color = new Color(startCountDownText.color.r, startCountDownText.color.g, startCountDownText.color.b, startCountDownText.color.a - Time.deltaTime);
            }
            else if (startCountDownText.color.a <= 0)
            {
                startCountDownText.gameObject.SetActive(false);
            }
        }

        if (!endCountDownBusy && endTimer > 0 && gameEnded)
        {
            StartCoroutine(EndCountDown());
        }
        else if (endTimer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BeginGame()
    {
        preStartUI.SetActive(false);
        startCountDownText.gameObject.SetActive(true);
        gameCountDownStarted = true;
    }

    public void EndGame()
    {
        if (!gameEnded)
        {
            victoriousPlayerName = GameObject.FindWithTag("Player").GetComponent<PlayerManager>().playerName;

            gameEnded = true;
            endCountDownText.text = victoriousPlayerName + " is victorious!\nNew game starting in: " + endTimer;
            endCountDownText.gameObject.SetActive(true);
        }
    }

    IEnumerator StartCountDown()
    {
        startCountDownBusy = true;

        yield return new WaitForSeconds(1);

        startTimer -= 1;

        startCountDownText.text = startTimer.ToString();

        startCountDownBusy = false;
    }

    IEnumerator EndCountDown()
    {
        endCountDownBusy = true;

        yield return new WaitForSeconds(1);

        endTimer -= 1;

        endCountDownText.text = victoriousPlayerName + " is victorious!\nNew game starting in: " + endTimer;

        endCountDownBusy = false;
    }

    public static bool GameStarted
    {
        get
        {
            return gameStarted;
        }
    }
}
