using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

    enum BelongsTo { One, Two }
    [SerializeField]
    BelongsTo belongsTo;

    [SerializeField]
    float moveSpeed = 2;

    Transform player;

    bool inPosition;

    PlayersManager playersManager;

    private void Start()
    {
        playersManager = GameObject.FindWithTag("Manager").GetComponent<PlayersManager>();

        switch (belongsTo)
        {
            case BelongsTo.One:
                player = playersManager.PlayerOne.transform;
                break;
            case BelongsTo.Two:
                player = playersManager.PlayerTwo.transform;
                break;
        }
    }

    private void Update()
    {
        if (GameStateManager.GameStarted && !GameStateManager.InGame)
        {
            player.position = Vector3.Lerp(player.position, transform.position, Time.deltaTime * moveSpeed);

            if (Vector3.Distance(transform.position, player.position) < 0.1f)
            {
                GameStateManager.InGame = true;

                Object[] objects = FindObjectsOfType(typeof(GameObject));
                foreach (GameObject go in objects)
                {
                    go.SendMessage("OnPlayerReachedStartPoint", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
