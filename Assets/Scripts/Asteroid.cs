using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    [SerializeField]
    GameObject asteroid;
    GameObject miniAsteroid;
    [SerializeField]
    float forceOnHit;

    [HideInInspector]
    public bool isHit;

    Rigidbody2D rb;
    Vector2 force;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        force = new Vector2(Random.Range(-20, 20), Random.Range(-20, 20));
    }

    private void Update()
    {
        if (isHit)
        {
            rb.AddForce(force * forceOnHit * Time.deltaTime, ForceMode2D.Force);
        }
    }

    public void Break () {
		if (!isHit)
        {
            for (int i = 0; i < 4; i++)
            {
                miniAsteroid = Instantiate(asteroid);
                miniAsteroid.transform.localScale = transform.localScale / 2;
                miniAsteroid.GetComponent<Asteroid>().isHit = true;
            }
        }

        Destroy(gameObject);
    }
}
