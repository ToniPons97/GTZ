using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    private float translation = 0f;

    [SerializeField]
    [Range(100f, 150f)]
    private float rotationSpeed = 10f;

    [Range(5f, 15f)]
    [SerializeField]
    private float speed = 11f;

    [Range(5f, 15f)]
    [SerializeField]
    private float slowSpeed = 11f;

    [Range(16f, 25f)]
    [SerializeField]
    private float boostSpeed = 18f;
    private bool hittedObstacle;

    // Update is called once per frame
    void Update()
    {
        translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;


        if (!hittedObstacle && Input.GetAxisRaw("Vertical") != 0f)
            transform.Translate(0, translation, 0);

        transform.Rotate(0, 0, -rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("speed-up"))
            speed = boostSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("obstacle"))
        {
            speed = slowSpeed;
            hittedObstacle = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
            hittedObstacle = false;
    }
}
