using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerHealthUI : MonoBehaviour
{

    PlayerHealth playerHealth;
    PanelUI panel;

    [SerializeField]
    Image healthBar;
    [SerializeField]
    float healthBarSizeLerpSpeed = 5;
    float initialHealthBarWidth;
    
    [SerializeField]
    Color[] healthColors;
    [SerializeField]
    float healthBarColorLerpSpeed = 5;
    int currentColor;

    [SerializeField]
    bool right;

    [SerializeField]
    Text livesText;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();

        panel = healthBar.GetComponent<PanelUI>();

        initialHealthBarWidth = healthBar.rectTransform.sizeDelta.x;
    }

    private void Update()
    {
        // size
        healthBar.rectTransform.sizeDelta = Vector2.Lerp(healthBar.rectTransform.sizeDelta, new Vector2((float)initialHealthBarWidth / 100f * (float)playerHealth.Health / (float)playerHealth.InitialHealth * 100f, healthBar.rectTransform.sizeDelta.y), Time.deltaTime * healthBarSizeLerpSpeed);

        Vector2 position = Vector2.zero;
        float hiddenX = 0;

        if (right)
        {
            position = new Vector2(healthBar.rectTransform.sizeDelta.x / 2, healthBar.rectTransform.anchoredPosition.y);

            hiddenX = -position.x - (initialHealthBarWidth - healthBar.rectTransform.sizeDelta.x);
        }
        else
        {
            position = new Vector2(-(healthBar.rectTransform.sizeDelta.x / 2), healthBar.rectTransform.anchoredPosition.y);

            hiddenX = -position.x + (initialHealthBarWidth - healthBar.rectTransform.sizeDelta.x);
        }

        // visibility positions
        panel.SetVisibilityPositions(position, new Vector2(hiddenX, position.y));

        // position
        if (GameState.InGame && !GameState.InEndGame && !PauseManager.IsPaused)
        {
            healthBar.rectTransform.anchoredPosition = position; //Vector2.Lerp(healthBar.rectTransform.anchoredPosition, position, Time.deltaTime * panel.SlideSpeed);
        }

        // color
        currentColor = (int)((float)healthColors.Length / 100f * (float)playerHealth.Health / (float)playerHealth.InitialHealth * 100f);

        currentColor = Mathf.Clamp(currentColor, 0, healthColors.Length-1);

        healthBar.color = Color.Lerp(healthBar.color, healthColors[currentColor], Time.deltaTime * healthBarColorLerpSpeed);

        // stat text
        livesText.text = GetComponent<PlayerManager>().playerName + ": lives " + playerHealth.Lives + "/" + playerHealth.InitialLives;
    }

    private void OnPlayerLost()
    {
        panel.enabled = true;
        panel.IsVisible = false;
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
