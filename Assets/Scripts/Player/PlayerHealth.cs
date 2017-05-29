using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
public class PlayerHealth : MonoBehaviour
{

    [SerializeField]
    int health = 100;
    int initialHealth;

    [SerializeField]
    bool godMode;

    private void Start()
    {
        initialHealth = health;
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
        GetComponent<PlayerManager>().EndGame(GetComponent<PlayerManager>().OtherPlayer);

        Destroy(gameObject);

        Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            go.SendMessage("OnPlayerDeath", SendMessageOptions.DontRequireReceiver);
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