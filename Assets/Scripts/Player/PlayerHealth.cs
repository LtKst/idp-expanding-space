using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    bool godMode;

    [SerializeField]
    Transform startPoint;

    [SerializeField]
    GameObject explosion;

    [SerializeField]
    Image healthBar;
    [SerializeField]
    Sprite[] healthBarSprites;

    [SerializeField]
    Text statText;

    private void Start()
    {
        initialHealth = health;
        initialLives = lives;
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

        if (health <= initialHealth && health > 80)
        {
            healthBar.sprite = healthBarSprites[4];
        }
        else if (health <= 80 && health > 60)
        {
            healthBar.sprite = healthBarSprites[3];
        }
        else if (health <= 60 && health > 40)
        {
            healthBar.sprite = healthBarSprites[2];
        }
        else if (health <= 40 && health > 20)
        {
            healthBar.sprite = healthBarSprites[1];
        }
        else if (health <= 20)
        {
            healthBar.sprite = healthBarSprites[0];
        }


        statText.text = GetComponent<PlayerManager>().playerName + ": lives " + lives + "/" + initialLives;
    }

    private void Die()
    {
        lives--;
        health = initialHealth;

        GameObject explosionInst = Instantiate(explosion);
        explosionInst.transform.position = transform.position;

        Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            go.SendMessage("OnPlayerDeath", SendMessageOptions.DontRequireReceiver);
        }

        transform.position = startPoint.position;

        if (lives <= 0)
        {
            GetComponent<PlayerManager>().EndGame(GetComponent<PlayerManager>().OtherPlayer);

            Object[] objs = FindObjectsOfType(typeof(GameObject));
            foreach (GameObject go in objs)
            {
                go.SendMessage("OnPlayerLost", SendMessageOptions.DontRequireReceiver);
            }

            Destroy(gameObject);
        }
    }

    public int Health
    {
        set
        {
            health = value;
        }
        get
        {
            return health;
        }
    }
}