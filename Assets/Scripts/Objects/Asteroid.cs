using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Asteroid : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 force;

    Vector3 playerPosition;
    Vector3 direction;

    bool collided;

    GameObject miniAsteroid;
    bool isHit;

    [SerializeField]
    float speed = 50;

    [SerializeField]
    float forceOnHit;

    [SerializeField]
    bool randomSprite;
    [SerializeField]
    Sprite[] sprites;

    private void Start()
    {
        playerPosition = GameObject.FindWithTag("Manager").GetComponent<PlayersManager>().PlayerOne.transform.position;
        direction = playerPosition - transform.position;

        rb = GetComponent<Rigidbody2D>();
        force = new Vector2(Random.Range(-20, 20), Random.Range(-20, 20));

        if (randomSprite)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
            if (GetComponent<PolygonCollider2D>())
            {
                Destroy(GetComponent<PolygonCollider2D>());
                gameObject.AddComponent<PolygonCollider2D>();
            }
        }
    }

    private void Update()
    {
        if (isHit)
        {
            rb.AddForce(force * forceOnHit * Time.deltaTime, ForceMode2D.Force);
        }
        else if (!collided)
        {
            rb.AddForce(direction.normalized * speed * Time.deltaTime, ForceMode2D.Force);
        }

        rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;
    }

    public void Break()
    {
        if (!isHit)
        {
            for (int i = 0; i < 4; i++)
            {
                miniAsteroid = Instantiate(gameObject);
                miniAsteroid.transform.localScale = transform.localScale / 2;
                miniAsteroid.GetComponent<Asteroid>().isHit = true;
            }
        }

        Destroy(gameObject);
    }
}
