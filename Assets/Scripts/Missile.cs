using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Missile : MonoBehaviour {
    
    [SerializeField]
    float speed = 400;

    [SerializeField]
    GameObject explosionParticleSystem;

    [SerializeField]
    float maxDistanceFromPlayer = 200;

    Rigidbody2D rb;
    GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    void Update () {
        rb.AddRelativeForce(Vector2.up * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, player.transform.position) >= maxDistanceFromPlayer)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Asteroid>())
        {
            collision.gameObject.GetComponent<Asteroid>().Break();

            GameObject explosionInstance = Instantiate(explosionParticleSystem);
            explosionInstance.transform.position = transform.position;

            Destroy(gameObject);
        }
    }
}
