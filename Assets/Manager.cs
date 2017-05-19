using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField]
    Text countDownText;
    [SerializeField]
    bool instaStart;

    float timer = 3;
    bool isCountingDown = false;

    static bool gameStarted = false;

    private void Start()
    {
        if (instaStart)
        {
            gameStarted = true;
            countDownText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (!isCountingDown && timer >= 1)
        {
            StartCoroutine(CountDown());
        }
        else if (timer < 1)
        {
            gameStarted = true;

            if (countDownText.color.a >= 0)
            {
                countDownText.text = "Go!";
                countDownText.color = Color.Lerp(countDownText.color, new Color(countDownText.color.r, countDownText.color.g, countDownText.color.b, 0), Time.deltaTime);

                countDownText.color = new Color(countDownText.color.r, countDownText.color.g, countDownText.color.b, countDownText.color.a - Time.deltaTime);
            }
            else if (countDownText.color.a <= 0)
            {
                countDownText.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator CountDown()
    {
        isCountingDown = true;

        yield return new WaitForSeconds(1);

        timer -= 1;

        countDownText.text = timer.ToString();

        isCountingDown = false;
    }

    public static bool GameStarted
    {
        get
        {
            return gameStarted;
        }
    }
}
