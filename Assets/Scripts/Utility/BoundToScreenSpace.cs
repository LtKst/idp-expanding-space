using UnityEngine;

public class BoundToScreenSpace : MonoBehaviour
{
    [SerializeField]
    float offset = 2.5f;

    [SerializeField]
    bool boundIfInGame;

    private void Update()
    {
        if (GameState.InGame || !boundIfInGame)
        {
            // horizontal
            if (transform.position.x <= ScreenToWorld.Left - offset)
            {
                transform.position = new Vector3(ScreenToWorld.Right + offset, transform.position.y);
            }
            else if (transform.position.x >= ScreenToWorld.Right + offset)
            {
                transform.position = new Vector3(ScreenToWorld.Left - offset, transform.position.y);
            }

            // vertical
            if (transform.position.y >= ScreenToWorld.Top + offset)
            {
                transform.position = new Vector3(transform.position.x, ScreenToWorld.Bottom - offset);
            }
            else if (transform.position.y <= ScreenToWorld.Bottom - offset)
            {
                transform.position = new Vector3(transform.position.x, ScreenToWorld.Top + offset);
            }
        }
    }
}