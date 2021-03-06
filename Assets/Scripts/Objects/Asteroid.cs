﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Asteroid : MonoBehaviour
{
    PlayersManager playersManager;

    Rigidbody2D rb;

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

    [SerializeField]
    GameObject breakParticle;

    private void Start()
    {
        playersManager = GameObject.FindWithTag("Manager").GetComponent<PlayersManager>();

        if (!GameState.InEndGame)
        {
            playerPosition = Utility.Random.RandomBool() ?
                playersManager.PlayerOne.transform.position :
                playersManager.PlayerTwo.transform.position;
        }

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

        rb.AddForce(direction.normalized * speed, ForceMode2D.Force);
    }

    private void Update()
    {
        if (collided)
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, Time.deltaTime);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (rb.velocity.magnitude >= 4)
            {
                collision.gameObject.GetComponent<PlayerHealth>().Damage((int)rb.velocity.magnitude * 3);
            }
        }

        collided = true;
    }

    public void Break()
    {
        if (!isHit)
        {
            for (int i = 0; i < 4; i++)
            {
                GameObject breakParticleInstance = Instantiate(breakParticle);
                breakParticleInstance.transform.position = transform.position;

                miniAsteroid = Instantiate(gameObject);
                miniAsteroid.transform.localScale = transform.localScale / 2;
                miniAsteroid.GetComponent<Asteroid>().isHit = true;

                Vector2 force = Random.insideUnitCircle;
                force.Normalize();

                miniAsteroid.GetComponent<Rigidbody2D>().AddForce(force * forceOnHit, ForceMode2D.Force);
            }
        }

        Destroy(gameObject);
    }
}
