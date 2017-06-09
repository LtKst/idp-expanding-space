using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{

    PlayerHealth playerHealth;

    [SerializeField]
    Image healthBar;
    [SerializeField]
    bool right;

    float healthBarLerpSpeed = 5;

    [SerializeField]
    Text statText;

    PanelUI panel;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();

        panel = healthBar.GetComponent<PanelUI>();
    }

    private void Update()
    {
        // size
        healthBar.rectTransform.sizeDelta = Vector2.Lerp(healthBar.rectTransform.sizeDelta, new Vector2(250 - (250 / playerHealth.InitialHealth) * (playerHealth.InitialHealth - playerHealth.Health), healthBar.rectTransform.sizeDelta.y), Time.deltaTime);

        Vector3 position = Vector3.zero;

        if (right)
        {
            position = new Vector2(healthBar.rectTransform.sizeDelta.x / 2, healthBar.rectTransform.anchoredPosition.y);
        }
        else
        {
            position = new Vector2(-(healthBar.rectTransform.sizeDelta.x / 2), healthBar.rectTransform.anchoredPosition.y);
        }

        // position
        if (GameStateManager.InGame && !GameStateManager.GameEnded && !PauseManager.IsPaused)
        {
            healthBar.rectTransform.anchoredPosition = position;
        }

        // colours
        if (playerHealth.Health <= playerHealth.InitialHealth && playerHealth.Health > 80)
        {
            healthBar.color = Color.Lerp(healthBar.color, Color.green, Time.deltaTime * healthBarLerpSpeed);
        }
        else if (playerHealth.Health <= 80 && playerHealth.Health > 60)
        {
            healthBar.color = Color.Lerp(healthBar.color, new Color(0.95f, 0.6f, 0.06f), Time.deltaTime * healthBarLerpSpeed);
        }
        else if (playerHealth.Health <= 40 && playerHealth.Health > 20)
        {
            healthBar.color = Color.Lerp(healthBar.color, Color.yellow, Time.deltaTime * healthBarLerpSpeed);
        }
        else if (playerHealth.Health <= 20)
        {
            healthBar.color = Color.Lerp(healthBar.color, Color.red, Time.deltaTime * healthBarLerpSpeed);
        }


        statText.text = GetComponent<PlayerManager>().playerName + ": lives " + playerHealth.Lives + "/" + playerHealth.InitialLives;


        panel.SetVisibilityPositions(position, new Vector2(-(position.x), position.y));

        if (GameStateManager.GameEnded)
        {
            panel.enabled = true;
            panel.IsVisible = false;
        }
    }

    private void OnResumed()
    {
        panel.enabled = false;
    }

    private void OnPaused()
    {
        panel.enabled = true;
        panel.IsVisible = false;
    }
    
    private void OnStartInGame()
    {
        panel.enabled = false;
    }
}
