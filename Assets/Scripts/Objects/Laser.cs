using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Laser : MonoBehaviour
{

    [SerializeField]
    float speed = 4000;

    [SerializeField]
    int damage;

    [SerializeField]
    float maxDistanceFromCamera = 200;

    [SerializeField]
    GameObject laserParticleSystem;

    Rigidbody2D rb;

    [HideInInspector]
    public GameObject belongsTo;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.AddRelativeForce(Vector2.up * speed);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Camera.main.transform.position) >= maxDistanceFromCamera)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject != belongsTo)
        {
            collision.GetComponent<PlayerHealth>().Damage(damage);

            Hit();
        }
        else if (collision.gameObject.GetComponent<Asteroid>())
        {
            collision.gameObject.GetComponent<Asteroid>().Break();

            Hit();
        }
    }

    void Hit()
    {
        GameObject laserSplahInstance = Instantiate(laserParticleSystem);
        laserSplahInstance.transform.position = transform.position;

        var main = laserSplahInstance.GetComponent<ParticleSystem>().main;
        main.startColor = GetComponent<SpriteRenderer>().color;

        Destroy(gameObject);
    }
}
