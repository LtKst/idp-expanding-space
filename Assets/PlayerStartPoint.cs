using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

    enum BelongsTo { One, Two }
    [SerializeField]
    BelongsTo belongsTo;

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
        player.LookAt(transform);
    }
}
