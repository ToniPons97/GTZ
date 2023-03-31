using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    private float damage = 25f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            DamageEnemy(enemy);
        }


        Destroy(gameObject);
        GameObject explotionInstance = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(explotionInstance, 0.5f);
    }

    private void DamageEnemy(Enemy enemy)
    {
        enemy.CalculateDamage(damage);
    }
}