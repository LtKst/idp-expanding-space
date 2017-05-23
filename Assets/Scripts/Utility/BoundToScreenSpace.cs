using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundToScreenSpace : MonoBehaviour
{

    [SerializeField]
    float offset = 2.5f;

    Vector2 horizontal;
    Vector2 vertical;

    private void Start()
    {
        horizontal = new Vector2(
            Camera.main.ScreenToWorldPoint(Vector3.zero).x - offset,
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x + offset
        );

        vertical = new Vector2(
            Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height)).y + offset,
            Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).y - offset
        );
    }

    private void Update()
    {
        // horizontal
        if (transform.position.x <= horizontal.x)
        {
            transform.position = new Vector3(horizontal.y, transform.position.y);
        }
        else if (transform.position.x >= horizontal.y)
        {
            transform.position = new Vector3(horizontal.x, transform.position.y);
        }

        // vertical
        if (transform.position.y >= vertical.x)
        {
            transform.position = new Vector3(transform.position.x, vertical.y);
        }
        else if (transform.position.y <= vertical.y)
        {
            transform.position = new Vector3(transform.position.x, vertical.x);
        }
    }
}