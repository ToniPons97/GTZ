using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        GameObject explotionInstance = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(explotionInstance, 0.5f);

    }
}
