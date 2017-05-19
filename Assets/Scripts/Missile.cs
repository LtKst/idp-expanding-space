using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Missile : MonoBehaviour
{

    [SerializeField]
    float speed = 400;

    [SerializeField]
    int damage;

    [SerializeField]
    float maxDistanceFromPlayer = 200;

    [SerializeField]
    GameObject explosionParticleSystem;

    Rigidbody2D rb;
<<<<<<< HEAD

    [HideInInspector]
    public GameObject belongsTo;

=======
    [HideInInspector]
    public GameObject player;

>>>>>>> ec792f55fda1041e98791741b9328b1782982ceb
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.AddRelativeForce(Vector2.up * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, Camera.main.transform.position) >= maxDistanceFromPlayer)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
<<<<<<< HEAD
        if (collision.gameObject.tag == "Player" && collision.gameObject != belongsTo)
=======
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().Health -= damage;
        }
        else if (collision.gameObject.GetComponent<Asteroid>())
>>>>>>> ec792f55fda1041e98791741b9328b1782982ceb
        {
            collision.GetComponent<PlayerHealth>().Health -= damage;

            BlowUp();
        }
        else if (collision.gameObject.GetComponent<Asteroid>())
        {
            collision.gameObject.GetComponent<Asteroid>().Break();

            BlowUp();
        }
    }

    void BlowUp()
    {
        GameObject explosionInstance = Instantiate(explosionParticleSystem);
        explosionInstance.transform.position = transform.position;

        Destroy(gameObject);
    }
}
