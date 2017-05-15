using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Missile : MonoBehaviour {

    [Header("Speed variables")]
    [SerializeField]
    float speed;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update () {
        rb.AddRelativeForce(Vector2.up * speed * Time.deltaTime);
	}
}
