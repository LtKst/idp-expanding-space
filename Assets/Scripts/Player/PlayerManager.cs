using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public enum Player { One, Two };
    public Player player;

    public string playerName;

    GameObject[] players;

    GameObject otherPlayer;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        players[0].GetComponent<PlayerManager>().player = Player.One;
        players[1].GetComponent<PlayerManager>().player = Player.Two;

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != gameObject)
                otherPlayer = players[i];
        }
    }

    public GameObject OtherPlayer
    {
        get
        {
            return otherPlayer;
        }
    }
}
