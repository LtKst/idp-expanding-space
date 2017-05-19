using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public enum Player { One, Two };
    public Player player;

    GameObject[] players;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        players[0].GetComponent<PlayerManager>().player = Player.One;
        players[1].GetComponent<PlayerManager>().player = Player.Two;
    }
}
