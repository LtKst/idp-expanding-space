using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Missile : MonoBehaviour {
    
    [SerializeField]
    float speed;

    Rigidbody2D rb;
    GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");

        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), true);
    }

    void Update () {
        rb.AddRelativeForce(Vector2.up * speed * Time.deltaTime);
	}
}
