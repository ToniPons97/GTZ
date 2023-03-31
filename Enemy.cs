using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float health = 100f;

    public void CalculateDamage(float bulletDamage)
    {
        health -= bulletDamage;
        if (health <= 0)
            Destroy(gameObject);
    }
}