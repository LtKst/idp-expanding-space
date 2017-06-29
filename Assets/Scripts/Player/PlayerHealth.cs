using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
public class PlayerHealth : MonoBehaviour
{

    [SerializeField]
    int health = 100;
    int initialHealth;

    [SerializeField]
    int lives = 3;
    int initialLives;

    [SerializeField]
    GameObject bubbleShield;
    [SerializeField]
    bool hasBubbleShield;

    [SerializeField]
    bool godMode;

    [SerializeField]
    Transform startPoint;

    [SerializeField]
    GameObject explosion;

    Quaternion startRotation;

    private void Start()
    {
        initialHealth = health;
        initialLives = lives;

        startRotation = transform.rotation;
    }

    private void Update()
    {
        health = Mathf.Clamp(health, 0, initialHealth);

        if (godMode)
        {
            health = initialHealth;
        }

        if (health <= 0)
        {
            Die();
        }

        bubbleShield.SetActive(hasBubbleShield);
    }

    private void Die()
    {
        lives--;

        GameObject explosionInst = Instantiate(explosion);
        explosionInst.transform.position = transform.position;

        if (lives > 0)
        {
            Object[] objects = FindObjectsOfType(typeof(GameObject));
            foreach (GameObject go in objects)
            {
                go.SendMessage("OnPlayerDeath", SendMessageOptions.DontRequireReceiver);
            }
        }
        else if (lives <= 0)
        {
            GetComponent<PlayerManager>().EndGame(GetComponent<PlayerManager>().OtherPlayer);

            Object[] objs = FindObjectsOfType(typeof(GameObject));
            foreach (GameObject go in objs)
            {
                go.SendMessage("OnPlayerLost", SendMessageOptions.DontRequireReceiver);
            }

            gameObject.SetActive(false);
        }
    }

    private void OnPlayerDeath()
    {
        GameState.InCountdown = true;

        health = initialHealth;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.SetPositionAndRotation(startPoint.position, startRotation);
    }

    public void Heal(int amount)
    {
        health += amount;
    }

    public void Damage(int amount)
    {
        if (hasBubbleShield)
        {
            health -= amount / 2;
        }
        else
        {
            health -= amount;
        }
    }

    public IEnumerator GetBubbleShield(float duration)
    {
        hasBubbleShield = true;

        yield return new WaitForSeconds(duration);

        hasBubbleShield = false;
    }

    public int Health
    {
        get
        {
            return health;
        }
    }

    public int InitialHealth
    {
        get
        {
            return initialHealth;
        }
    }

    public int Lives
    {
        get
        {
            return lives;
        }
    }

    public int InitialLives
    {
        get
        {
            return initialLives;
        }
    }
}