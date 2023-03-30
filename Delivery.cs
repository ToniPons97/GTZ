using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    // This is set to false by default.
    private bool hasPackage;
    [SerializeField]
    private float destroyDelay;

    [SerializeField]
    Color32 hasPackageColor = new(1, 1, 1, 1);

    [SerializeField]
    Color32 noPackageColor = new(1, 1, 1, 1);

    private SpriteRenderer carSpriteRenderer;

    private void Start()
    {
        carSpriteRenderer = GetComponent<SpriteRenderer>();
        carSpriteRenderer.color = noPackageColor;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        string name = collision.gameObject.name;
        Debug.Log("Collided with " + name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tagName = collision.gameObject.tag;
        Debug.Log("Passed through " + tagName);

        if (collision.CompareTag("package") && !hasPackage)
        {
            Debug.Log(tagName + " picked up.");
            hasPackage = true;
            Destroy(collision.gameObject, destroyDelay);

            // Change color when package is picked up.
            carSpriteRenderer.color = hasPackageColor;
        }
        else if (collision.CompareTag("customer") && hasPackage)
        {
            Debug.Log("Delivered package.");
            hasPackage = false;

            // Reset color when package delivered.
            carSpriteRenderer.color = noPackageColor;
        }
    }
}