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

    [SerializeField]
    UnityEvent onPlayerReachedStartPoints;

    private void Start()
    {
        playersManager = GameObject.FindWithTag("Manager").GetComponent<PlayersManager>();

        switch (belongsTo)
        {
            case BelongsTo.One:
                player = playersManager.PlayerOne.transform;
                transform.position = new Vector3(ScreenToWorld.Left + 3, 0, 0);
                break;
            case BelongsTo.Two:
                player = playersManager.PlayerTwo.transform;
                transform.position = new Vector3(ScreenToWorld.Right - 3, 0, 0);
                break;
        }
    }

    private void Update()
    {
        if (GameState.GameStarted && !inPosition)
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
}
