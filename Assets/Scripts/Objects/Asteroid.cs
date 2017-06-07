using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Asteroid : MonoBehaviour
{
    Rigidbody2D rb;

    Vector3 playerPosition;
    Vector3 direction;

    bool collided;
    bool collidedPlayer;

    GameObject miniAsteroid;
    bool isHit;

    Vector3 explosionPosition;

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
        if (isHit && !collidedPlayer)
        {
            Rigidbody2DExtension.AddExplosionForce(rb, 5, explosionPosition, 5);
        }
        else if (!collided)
        {
            rb.AddForce(direction.normalized * speed * Time.deltaTime, ForceMode2D.Force);
        }

        rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, Time.deltaTime);
    }

    // niet meer mee kloten :-)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (rb.velocity.magnitude >= 4)
            {
                collision.gameObject.GetComponent<PlayerHealth>().Health -= (int)rb.velocity.magnitude * 3;
            }

            collidedPlayer = true;
        }

        collided = true;
    }

    public void Break()
    {
        if (!isHit)
        {
            for (int i = 0; i < 1; i++)
            {
                miniAsteroid = Instantiate(gameObject);
                miniAsteroid.transform.localScale = transform.localScale / 2;
                miniAsteroid.GetComponent<Asteroid>().explosionPosition = transform.position;
                miniAsteroid.GetComponent<Asteroid>().isHit = true;

                Rigidbody2DExtension.AddExplosionForce(miniAsteroid.GetComponent<Rigidbody2D>(), 5, transform.position, 5);
            }
        }

        Destroy(gameObject);
    }
}
