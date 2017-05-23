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

    PlayerManager playerManager;
    Manager manager;

    private void Start()
    {
        initialHealth = health;

        playerManager = GetComponent<PlayerManager>();
        manager = GameObject.FindWithTag("Manager").GetComponent<Manager>();
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
        Destroy(gameObject);

        manager.EndGame(playerManager.OtherPlayer.GetComponent<PlayerManager>().playerName);
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