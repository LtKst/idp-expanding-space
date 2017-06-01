using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStartPoint : MonoBehaviour {

    enum BelongsTo { One, Two }
    [SerializeField]
    BelongsTo belongsTo;

    [SerializeField]
    float moveSpeed = 2;

    Transform player;

    bool inPosition;

    PlayersManager playersManager;

    Vector2 horizontal;

    [SerializeField]
    UnityEvent onPlayerReachedStartPoints;

    private void Start()
    {
        playersManager = GameObject.FindWithTag("Manager").GetComponent<PlayersManager>();

        horizontal = new Vector2(
            Camera.main.ScreenToWorldPoint(Vector3.zero).x + 2,
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x - 2
        );

        switch (belongsTo)
        {
            case BelongsTo.One:
                player = playersManager.PlayerOne.transform;
                transform.position = new Vector3(horizontal.x, 0, 0);
                break;
            case BelongsTo.Two:
                player = playersManager.PlayerTwo.transform;
                transform.position = new Vector3(horizontal.y, 0, 0);
                break;
        }
    }

    private void Update()
    {
        if (GameStateManager.GameStarted && !inPosition)
        {
            player.position = Vector3.Lerp(player.position, transform.position, Time.deltaTime * moveSpeed);

            if (Vector3.Distance(transform.position, player.position) < 0.2f)
            {
                inPosition = true;

                if (onPlayerReachedStartPoints != null)
                    onPlayerReachedStartPoints.Invoke();

                Object[] objects = FindObjectsOfType(typeof(GameObject));
                foreach (GameObject go in objects)
                {
                    go.SendMessage("OnPlayerReachedStartPoint", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }

    void OnScreenResize()
    {
        if (!GameStateManager.GameStarted)
        {
            horizontal = new Vector2(
                Camera.main.ScreenToWorldPoint(Vector3.zero).x + 2,
                Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x - 2
            );

            switch (belongsTo)
            {
                case BelongsTo.One:
                    player.position = new Vector3(horizontal.x - 20, 0, 0);
                    transform.position = new Vector3(horizontal.x, 0, 0);
                    break;
                case BelongsTo.Two:
                    player.position = new Vector3(horizontal.y + 20, 0, 0);
                    transform.position = new Vector3(horizontal.y, 0, 0);
                    break;
            }
        }
    }
}
