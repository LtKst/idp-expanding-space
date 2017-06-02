using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;

    [Header("Speed variables")]
    public float speed = 700;
    [SerializeField]
    float rotationSpeed = 150;
    [SerializeField]
    float slowDownSpeed = 1.5f;
    [SerializeField]
    float manualSlowDownSpeed = 5;

    float finalSlowDownSpeed;

    [SerializeField]
    ParticleSystem particles;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void LookAtCursor(Vector3 mousePosition)
    {
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        // set rotation

        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
    }

    public void Move(float horizontalMovement, bool getForwardKey, bool getBrakeKey)
    {
        // movement

        if (getForwardKey)
        {
            rb.AddRelativeForce(Vector2.up * speed * Time.deltaTime);

            particles.Emit(2);
        }
        // rotation

        //rb.MoveRotation(rb.rotation + horizontalMovement * rotationSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, -horizontalMovement) * rotationSpeed * Time.deltaTime);

        // velocity

        finalSlowDownSpeed = getBrakeKey ? manualSlowDownSpeed : slowDownSpeed;
        rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, Time.deltaTime * finalSlowDownSpeed);
    }
}
