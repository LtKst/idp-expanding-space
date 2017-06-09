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

        transform.SetPositionAndRotation(startPoint.position, startRotation);

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